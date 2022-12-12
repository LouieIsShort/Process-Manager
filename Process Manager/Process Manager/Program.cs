using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Process_Manager.Forms;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Diagnostics;
using System.Reflection;

namespace Process_Manager
{
    internal class Program
    {
        [DllImport("kernel32.dll")]
        static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        const int SW_HIDE = 0;
        const int SW_SHOW = 5;


        static void Main(string[] args)
        {
            AdminClass adminClass = new AdminClass();
            adminClass.AdminRelauncher();
            Console.Beep(400, 700);
            ShowWindow(GetConsoleWindow(), SW_HIDE);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainWindow());

        }
    }

    class AdminClass
    {
        public void AdminRelauncher()
        {
            if (!IsRunAsAdmin())
            {
                ProcessStartInfo proc = new ProcessStartInfo();
                proc.UseShellExecute = true;
                proc.WorkingDirectory = Environment.CurrentDirectory;
                proc.FileName = Assembly.GetEntryAssembly().CodeBase;

                proc.Verb = "runas";

                try
                {
                    Process.Start(proc);
                }
                catch
                {
                    MessageBox.Show("Must be run as Administraitor", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Environment.Exit(0);
                }

                Application.Exit();
            }
        }

        private bool IsRunAsAdmin()
        {
            try
            {
                WindowsIdentity id = WindowsIdentity.GetCurrent();
                WindowsPrincipal principal = new WindowsPrincipal(id);
                return principal.IsInRole(WindowsBuiltInRole.Administrator);
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
