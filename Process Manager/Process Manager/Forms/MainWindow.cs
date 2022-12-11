using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace Process_Manager.Forms
{
    public partial class MainWindow : Form
    {
        public List<Process> Processes = new List<Process>();
        public List<ProcessInformation> ProcessesInformation = new List<ProcessInformation>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            RefreshProcesses(false);
            
        }

        public void RefreshProcesses(bool WindowOpen)
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

            int oldScroll = ProcessorDataGrid.FirstDisplayedScrollingRowIndex;
            ProcessorDataGrid.DataSource = null;
            ProcessorDataGrid.DataSource = ProcessesInformation;
            ProcessorDataGrid.FirstDisplayedScrollingRowIndex = WindowOpen == true? oldScroll : ProcessorDataGrid.FirstDisplayedScrollingRowIndex;
        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            RefreshProcesses(true);
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
