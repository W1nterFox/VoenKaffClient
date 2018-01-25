using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using SerializablePicutre;
using VoenKaffServer;
using VoenKaffStartClient.Properties;
using VoenKaffStartClient.Wrappers;

namespace VoenKaffStartClient.Senders
{
    public class UpdateTests
    {
        private readonly DynamicParams _parameters;

        public UpdateTests()
        {
            _parameters = new DynamicParams();
        }
        public bool Connect()
        {
            bool result = false;
            int port = _parameters.Get().Port;
            string address = _parameters.Get().Ip;
            try
            {
                var ipPoint = new IPEndPoint(IPAddress.Parse(address), port);
                var socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                socket.Connect(ipPoint);
                byte[] data = Encoding.Unicode.GetBytes("Update");
                socket.Send(data);

                data = new byte[256]; // буфер для ответа
                StringBuilder builder = new StringBuilder();
                int bytes = 0; // количество полученных байт
                do
                {
                    bytes = socket.Receive(data, data.Length, 0);
                    builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
                }
                while (socket.Available > 0);

                var filenames = JsonConvert.DeserializeObject<List<ObjectInfo>>(builder.ToString());
                Directory.Delete("tests", true);
                Directory.CreateDirectory("tests");
                Directory.CreateDirectory("tests\\picture");
                socket.Shutdown(SocketShutdown.Both);
                socket.Close();

                for (var i = 0; i < filenames.Count; i++)
                {
                    socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    socket.Connect(ipPoint);
                    socket.Send(Encoding.Unicode.GetBytes(i.ToString()));


                    builder = new StringBuilder();

                    FileStream fs = new FileStream(Resources.PathForTest+"\\"+filenames[i].FileName, FileMode.Create, FileAccess.ReadWrite, FileShare.None);
                    var timeout = 0;
                    while (true)
                    {
                        var test = socket.Available;
                        // если есть доступные данные, которые всецело можно записать в буфер обмена - то пишем
                        if (socket.Available > 4096)
                        {
                            data = new byte[4096];
                            int recv = socket.Receive(data, SocketFlags.None);
                            if (recv == 0)
                                break;
                            fs.Write(data, 0, data.Length);
                        }
                        //иначе проверяем, является ли это последним блоком данных, который меньше нашего буфера
                        else
                        {
                            // 5402624 - размер файла оригинала
                            if (fs.Length + socket.Available == filenames[i].Length)
                            {
                                data = new byte[4096];
                                socket.Receive(data, SocketFlags.None);
                                fs.Write(data, 0, data.Length);
                                break;
                            }
                        }

                        timeout++;
                    }
                    fs.Close();
                }

                socket.Shutdown(SocketShutdown.Both);
                socket.Close();

                return result;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "df", MessageBoxButtons.OK);
                return false;
            }
        }
    }
}
