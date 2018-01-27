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
                var counter = 0;
                int bytes = 0; // количество полученных байт
                while (counter < 20)
                {
                    if (socket.Available == 0)
                    {
                        counter++;
                    }
                    bytes = socket.Receive(data, data.Length, 0);
                    builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
                }


                var filenames = JsonConvert.DeserializeObject<List<ObjectInfo>>(builder.ToString());
                Directory.Delete("tests", true);
                Directory.CreateDirectory("tests");
                Directory.CreateDirectory("tests\\picture");
                socket.Shutdown(SocketShutdown.Both);
                socket.Close();


                foreach (var objectInfo in filenames)
                {
                    File.AppendAllText("log.txt",objectInfo.FileName+":"+objectInfo.Length+"\r\n");
                }

                for (var i = 0; i < filenames.Count; i++)
                {
                    socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    socket.Connect(ipPoint);
                    socket.Send(Encoding.Unicode.GetBytes(i.ToString()));


                    builder = new StringBuilder();

                    FileStream fs = new FileStream(Resources.PathForTest+"\\"+filenames[i].FileName, FileMode.Create, FileAccess.ReadWrite, FileShare.None);
                    while (true)
                    {
                        // если есть доступные данные, которые всецело можно записать в буфер обмена - то пишем
                        if (socket.Available > 50000)
                        {
                            data = new byte[50000];
                            int recv = socket.Receive(data, SocketFlags.None);
                            if (recv == 0)
                                break;
                            fs.Write(data, 0, data.Length);
                        }
                        //иначе проверяем, является ли это последним блоком данных, который меньше нашего буфера
                        else
                        {
                            var socketAvaliable = socket.Available;
                            // 5402624 - размер файла оригинала
                            if (fs.Length + socketAvaliable == filenames[i].Length)
                            {
                                File.AppendAllText("log.txt","Socket Avaliable: " + socketAvaliable);
                                data = new byte[50000];
                                socket.Receive(data, SocketFlags.None);
                                fs.Write(data, 0, data.Length);
                                break;
                            }
                        }
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
