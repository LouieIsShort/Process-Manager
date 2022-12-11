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
                Task.Delay(500).Wait();
                RefreshProcesses(true, false);
            }
        }
        public void RefreshProcesses(bool WindowOpen, bool IsMainThread)
        {
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
                        int oldScroll = ProcessorDataGrid.FirstDisplayedScrollingRowIndex;
                        ProcessorDataGrid.DataSource = null;
                        ProcessorDataGrid.DataSource = ProcessesInformation;
                        ProcessorDataGrid.FirstDisplayedScrollingRowIndex = WindowOpen == true ? oldScroll : ProcessorDataGrid.FirstDisplayedScrollingRowIndex;
                    }
                }));
            }
            else
            {
                int oldScroll = ProcessorDataGrid.FirstDisplayedScrollingRowIndex;
                ProcessorDataGrid.DataSource = null;
                ProcessorDataGrid.DataSource = ProcessesInformation;
                ProcessorDataGrid.FirstDisplayedScrollingRowIndex = WindowOpen == true ? oldScroll : ProcessorDataGrid.FirstDisplayedScrollingRowIndex;
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
}
