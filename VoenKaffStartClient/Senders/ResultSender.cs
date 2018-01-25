using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VoenKaffServer;
using VoenKaffStartClient.Wrappers;

namespace VoenKaffStartClient.Senders
{
    class ResultSender
    {
        private readonly DynamicParams _parameters;

        public ResultSender()
        {
            _parameters = new DynamicParams();
        }

        public bool Connect(string result)
        {
            int port = _parameters.Get().Port;
            string address = _parameters.Get().Ip;

            var ipPoint = new IPEndPoint(IPAddress.Parse(address), port);
            var socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket.Connect(ipPoint);
            byte[] data = Encoding.Unicode.GetBytes(result);
            socket.Send(data);

            socket.Shutdown(SocketShutdown.Both);
            socket.Close();

            return true;
            
        }
    }
}
