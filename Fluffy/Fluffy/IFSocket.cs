using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluffyNet
{
    public interface IFSocket
    {
        void Connect();
        void Send(string value);
        string Receive();
    }
}
