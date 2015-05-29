using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace FluffyNet
{
    public class FSocket : IFSocket
    {
        private string _server;
        private int _port;

        private Socket Socket
        {
            get;
            set;
        }
        public string Server
        {
            get { return _server; }
        }
        public int Port
        {
            get { return _port; }
        }

        public FSocket()
        {
        }

        public void Connect(string server, int port)
        {
            if(string.IsNullOrEmpty(server))
            {
                Console.WriteLine("Le serveur est vide !");
                return;
            }

            if(port <= 0 || port > 65556)
            {
                Console.WriteLine("Port invalide !");
                return;
            }

            // Get host related information.
            _server = server;
            _port = port;
            IPHostEntry hostEntry = Dns.GetHostEntry(server);

            // Loop through the AddressList to obtain the supported AddressFamily. This is to avoid
            // an exception that occurs when the host IP Address is not compatible with the address family
            // (typical in the IPv6 case).
            foreach (IPAddress address in hostEntry.AddressList)
            {
                IPEndPoint ipe = new IPEndPoint(address, port);
                Socket tempSocket = new Socket(ipe.AddressFamily, SocketType.Stream, ProtocolType.Udp);

                tempSocket.Connect(ipe);

                if (tempSocket.Connected)
                {
                    Socket = tempSocket;
                    break;
                }
                else
                {
                    continue;
                }
            }
        }

        public void Send(string value)
        {

        }
    }
}
