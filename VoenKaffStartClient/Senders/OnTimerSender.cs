using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using VoenKaffStartClient.Properties;
using VoenKaffStartClient.Wrappers;

namespace VoenKaffStartClient.Senders
{
    class OnTimerSender
    {
        private Thread thread;

        public OnTimerSender()
        {
            thread= new Thread(Connect);
        }

        public void Start()
        {
            thread.Start();
        }

        private void Connect()
        {
            while (true)
            {
                try
                {
                    if (File.Exists(Resources.ResultData))
                    {
                        var results =
                            JsonConvert.DeserializeObject<List<Result>>(File.ReadAllText(Resources.ResultData));

                        var updater = new ResultSender();

                        foreach (var result in results)
                        {
                            updater.Connect(JsonConvert.SerializeObject(result));
                        }
                        File.Delete(Resources.ResultData);
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message, "rewwer", MessageBoxButtons.OK);
                }

                Thread.Sleep(10000);
            }
        }
    }
}
