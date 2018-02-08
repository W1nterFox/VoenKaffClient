using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Forms;
using VoenKaffStartClient.Senders;
using System.Linq;


namespace VoenKaffStartClient
{
    public static class Program
    {
        static Form1 form1;
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

            goUpdateClient();
            Application.Run();
        }

        private static async void  goUpdateClient()
        {
            
            FormLoader formLoading = new FormLoader();
            formLoading.Visible = true;
            if (await Task.Run(() => method1()))
            {
                
                //Application.Run(form1);
                formLoading.Visible = false;
                form1.Visible = true;
            }
        }

        private static Boolean method1()
        {
            new UpdateTests().Connect();
            form1 = new Form1();
            return true;
        }

    }
}
