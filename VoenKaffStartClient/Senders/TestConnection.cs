using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VoenKaffServer;

namespace VoenKaffStartClient.Senders
{
    public class TestConnection
    {
        private DynamicParams _parameters;

        public TestConnection()
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
                byte[] data = Encoding.Unicode.GetBytes("Test connect");
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

                if (builder.ToString() == "OK")
                {
                    result = true;
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
