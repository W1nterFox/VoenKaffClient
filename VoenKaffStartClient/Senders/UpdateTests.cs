using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using VoenKaffServer;
using VoenKaffStartClient.Properties;

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

                var filenames = JsonConvert.DeserializeObject<List<string>>(builder.ToString());

                socket.Shutdown(SocketShutdown.Both);
                socket.Close();

                for (var i = 0; i < filenames.Count; i++)
                {
                    socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    socket.Connect(ipPoint);
                    socket.Send(Encoding.Unicode.GetBytes(i.ToString()));

                    data = new byte[256]; // буфер для ответа
                    builder = new StringBuilder();
                    bytes = 0; // количество полученных байт
                    do
                    {
                        bytes = socket.Receive(data, data.Length, 0);
                        builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
                    }
                    while (socket.Available > 0);

                    var filename = Resources.PathForTest + "\\" + filenames[i];
                    if (!File.Exists(filename))
                    {
                        File.WriteAllText(filename, builder.ToString());
                    }
                }

                socket.Shutdown(SocketShutdown.Both);
                socket.Close();

                return result;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
