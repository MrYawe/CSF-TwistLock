using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace FluffyNet
{
    public class FSocket : IFSocket
    {
        public string IpAddress
        {
            get;
            set;
        }
        public int Port
        {
            get;
            set;
        }

        public FSocket()
        {
            Socket socket = new Socket();
        }

        public void Connect(string address, int port)
        {

        }

        public int Send(string value)
        {
            return 0;
        }
    }
}
