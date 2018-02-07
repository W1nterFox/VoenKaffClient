using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using VoenKaffStartClient.Senders;

namespace VoenKaffStartClient
{
    public static class Program
    {

        [STAThread]
        public static void Main()
        {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            goUpdateClient();
            //Application.Run(new Form1());
            Application.Run();
        }

        private static async void  goUpdateClient()
        {
            FormLoader formLoading = new FormLoader();
            formLoading.Visible = true;
            if (await Task.Run(() => method1()))
            {
                Form1 form1 = new Form1();
                //Application.Run(form1);
                formLoading.Visible = false;
                form1.Visible = true;
            }
        }

        private static Boolean method1()
        {
            new UpdateTests().Connect();
            return true;
        }

    }
}
