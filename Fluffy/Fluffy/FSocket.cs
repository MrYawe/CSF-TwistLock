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
        private Socket ConnectSocket
        {
            get;
            set;
        }
        public string Server
        {
            get;
            set;
        }
        public int Port
        {
            get;
            set;
        }

        public FSocket(string server, int port)
        {
            Server = server;
            Port = port;
            IPEndPoint ipeConnect = new IPEndPoint(IPAddress.Parse(server), port);
            ConnectSocket = new Socket(ipeConnect.AddressFamily, SocketType.Dgram, ProtocolType.Udp);
        }

        public void Connect()
        {
            try
            {
                // Connect to remote ip and port
                IPEndPoint epRemote = new IPEndPoint(IPAddress.Parse(Server), Port);
                ConnectSocket.Connect(epRemote);

            }
            catch(Exception ex)
            {
                Console.WriteLine("ERREUR : " + ex.Message);
            }
        }

        public void Send(string value)
        {
            ConnectSocket.Send(GetBytes(value));
        }

        public void Send(string value, int taille)
        {
            ConnectSocket.Send(GetBytes(value));
        }

        public string Receive()
        {
            byte[] buffer = new byte[256];
            try
            {
                int i = ConnectSocket.Receive(buffer);
                return Encoding.UTF8.GetString(buffer);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return "";
            }
        }

        public static byte[] GetBytes(string str)
        {
            byte[] bytes = new byte[str.Length];
            Encoding.ASCII.GetBytes(str, 0, str.Length, bytes, 3);  
            return bytes;
        }

        public static string GetString(byte[] bytes)
        {
            char[] chars = new char[bytes.Length / sizeof(char)];
            System.Buffer.BlockCopy(bytes, 0, chars, 0, bytes.Length);
            return new string(chars);
        }
    }
}
