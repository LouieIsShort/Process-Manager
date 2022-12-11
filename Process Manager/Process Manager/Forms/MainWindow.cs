using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.Diagnostics;

namespace Process_Manager.Forms
{
    public partial class MainWindow : Form
    {
        public List<Process> Processes = new List<Process>();
        public List<ProcessInformation> ProcessesInformation = new List<ProcessInformation>();
        public List<ModuleInfo> processModules = new List<ModuleInfo>();

        Thread RefreshThread;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            RefreshThread = new Thread(new ThreadStart(autoRefresh));
            RefreshProcesses(false, true);
        }
        public void autoRefresh()
        {
            while (true)
            {
                Task.Delay(5000).Wait();
                RefreshProcesses(true, false);
            }
        }
        public void RefreshProcesses(bool WindowOpen, bool IsMainThread)
        {
            if (SettingsCheckBoxes.GetItemChecked(2))
            {
                int oldScroll = 0;
                if (IsMainThread)
                {
                    oldScroll = ProcessorDataGrid.FirstDisplayedScrollingRowIndex;
                    ProcessorDataGrid.DataSource = null;
                }
                else
                {
                    ProcessorDataGrid.BeginInvoke((MethodInvoker)(() => { oldScroll = ProcessorDataGrid.FirstDisplayedScrollingRowIndex; ProcessorDataGrid.DataSource = null; }));
                }

                Processes.Clear();
                Processes = Process.GetProcesses().ToList<Process>();
                foreach (Process process in Processes)
                {
                    processModules.Add(new ModuleInfo 
                    {
                        ModuleName = process.MainModule.ModuleName,
                        FileName = process.MainModule.FileName,
                        ModuleMemorySize = process.MainModule.ModuleMemorySize,
                        BaseAddress = process.MainModule.BaseAddress
                    });
                }

                if (!IsMainThread)
                {
                    ProcessorDataGrid.BeginInvoke((MethodInvoker)(() =>
                    {
                        {
                            ProcessorDataGrid.DataSource = processModules;
                            Task.Delay(500).Wait();
                            ProcessorDataGrid.FirstDisplayedScrollingRowIndex = WindowOpen == true & ProcessesInformation.Count > oldScroll ? oldScroll : ProcessorDataGrid.FirstDisplayedScrollingRowIndex;
                        }
                    }));
                }
                else
                {
                    ProcessorDataGrid.DataSource = processModules;
                    Task.Delay(250).Wait();
                    ProcessorDataGrid.FirstDisplayedScrollingRowIndex = WindowOpen == true & ProcessesInformation.Count > oldScroll ? oldScroll : ProcessorDataGrid.FirstDisplayedScrollingRowIndex;
                }
            }
            else
            {
                int oldScroll = 0;
                if (IsMainThread)
                {
                    oldScroll = ProcessorDataGrid.FirstDisplayedScrollingRowIndex;
                    ProcessorDataGrid.DataSource = null;
                }
                else
                {
                    ProcessorDataGrid.BeginInvoke((MethodInvoker)(() => { oldScroll = ProcessorDataGrid.FirstDisplayedScrollingRowIndex; ProcessorDataGrid.DataSource = null; }));
                }

                Processes.Clear();
                Processes = Process.GetProcesses().ToList<Process>();
                ProcessesInformation.Clear();
                foreach (Process process in Processes)
                {
                    ProcessesInformation.Add(new ProcessInformation
                    {
                        ProcessName = process.ProcessName,
                        ProcessStartInfo = process.StartInfo,
                        ProcessId = process.Id,
                        Priority = process.BasePriority,
                        threadNames = process.Threads.ToString()
                    });
                }

                if (!IsMainThread)
                {
                    ProcessorDataGrid.BeginInvoke((MethodInvoker)(() =>
                    {
                        {
                            ProcessorDataGrid.DataSource = ProcessesInformation;
                            Task.Delay(500).Wait();
                            ProcessorDataGrid.FirstDisplayedScrollingRowIndex = WindowOpen == true & ProcessesInformation.Count > oldScroll ? oldScroll : ProcessorDataGrid.FirstDisplayedScrollingRowIndex;
                        }
                    }));
                }
                else
                {
                    ProcessorDataGrid.DataSource = ProcessesInformation;
                    Task.Delay(250).Wait();
                    ProcessorDataGrid.FirstDisplayedScrollingRowIndex = WindowOpen == true & ProcessesInformation.Count > oldScroll ? oldScroll : ProcessorDataGrid.FirstDisplayedScrollingRowIndex;
                }
            }
        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            RefreshProcesses(true, true);
        }

        private void SettingsCheckBoxes_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.Index == 0)
            {
                if (e.NewValue == CheckState.Checked)
                {
                    RefreshThread.Start();
                }
                else
                {
                    RefreshThread.Abort();
                }
                
            }
        }

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            RefreshThread.Abort();
        }

        private void TerminateProcessButton_Click(object sender, EventArgs e)
        {
            if (SettingsCheckBoxes.GetItemChecked(1))
            {
                foreach (DataGridViewRow row in ProcessorDataGrid.SelectedRows)
                {
                    foreach (Process process in Process.GetProcessesByName((string)row.Cells[0].Value))
                    {
                        try
                        {
                            process.Kill();
                        }
                        catch
                        {
                            MessageBox.Show($"Cannot Terminate Process {row.Cells[0].Value}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            else
            {
                foreach (DataGridViewRow row in ProcessorDataGrid.SelectedRows)
                {
                    try
                    {
                        Processes[row.Index].Kill();
                    }
                    catch
                    {
                        MessageBox.Show($"Cannot Terminate Process {row.Cells[0].Value}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }

    public class ProcessInformation
    {
        public string ProcessName { get; set; }
        public ProcessStartInfo ProcessStartInfo { get; set; }
        public string threadNames { get; set; }
        public int ProcessId { get; set; }
        public int Priority { get; set; }
    }
    public class ModuleInfo
    {
        public string ModuleName { get; set; }
        public int ModuleMemorySize { get; set; }
        public string FileName { get; set; }
        public IntPtr BaseAddress { get; set; }
    }
}
