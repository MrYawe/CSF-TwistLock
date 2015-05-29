using FluffyNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fluffy
{
    class Program
    {
        static void Main(string[] args)
        {
            // VARIABLES
            string teamName = "Comic Sans Fluffy " + new Random().Next(10);
            string server;
            int port;
            bool isServer;

            // TESTING 
            Console.Write("server (1) or client (2) ? ");
            isServer = int.Parse(Console.ReadLine()) == 1;
            Console.Write("server: ");
            server = Console.ReadLine();
            Console.Write("port: ");
            port = int.Parse(Console.ReadLine());

            // CONNECTION TO THE SERVER
            FSocket socket = new FSocket();
            socket.Connect(server, port);
            if(!isServer)
            {
                socket.Send(teamName);
            }
            else
            {
                List<string> teams = new List<string>();
                string line = socket.Receive();

            }

        }
    }
}
