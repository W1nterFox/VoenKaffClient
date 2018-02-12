using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Forms;
using VoenKaffStartClient.Senders;
using System.Linq;
using System.ComponentModel;

namespace VoenKaffStartClient
{
    public static class Program
    {
        static Form1 form1;
        static FormLoader formLoading;
        [STAThread]
        public static void Main()
        {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var runningProccess = from proc in Process.GetProcesses(".") orderby proc.Id select proc;
            if (runningProccess.Count(p => p.ProcessName.Contains("VoenKaffStartClient")) > 1)
            {
                MessageBox.Show("Программа уже запущена, невозможно запустить ещё один экземпляр",
                    "Программа уже запущена", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
            }

            formLoading = new FormLoader();
            formLoading.Visible = true;
            BackgroundWorker bw = new BackgroundWorker();
            bw.DoWork +=new DoWorkEventHandler(bw_DoWork);
            bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw_RunWorkerCompleted);
            bw.RunWorkerAsync();
            
            Application.Run();
        }

        private static void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            new UpdateTests().Connect();
            form1 = new Form1();
        }

        private static void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            formLoading.Visible = false;
            form1.Visible = true;
        }
    }
}
