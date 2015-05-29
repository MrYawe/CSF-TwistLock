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

            // TESTING 
            Console.Write("Server: ");
            server = Console.ReadLine();
            Console.Write("Port: ");
            port = int.Parse(Console.ReadLine());

            // CONNECTION TO THE SERVER
            FSocket socket = new FSocket(server, port);
            socket.Connect();
            socket.Send(teamName);

            // RECEPTION INFO PLAYER
            string infoPlayer = socket.Receive();
            Console.WriteLine("Infos player : " + infoPlayer);

            // DEBUT DU JEU
            string begin = socket.Receive();
            Console.WriteLine("Infos partie : " + begin);

            Console.ReadLine();
        }
    }
}
