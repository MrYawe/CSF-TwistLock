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
            string server   = "172.30.7.16";
            int port        = 9867;

            // TESTING 
            Console.Write("Server: ");
            //server = Console.ReadLine();
            Console.Write("Port: ");
            //port = int.Parse(Console.ReadLine());

            // CONNECTION TO THE SERVER
            FSocket socket = new FSocket(server, port);
            socket.Connect();
            socket.Send(teamName);

            // RECEPTION INFO PLAYER
            Joueur joueur = new Joueur();
            string infoJoueur = socket.Receive();
            infoJoueur = "Vous êtes le Joueur 1 (ROUGE), attente suite ..."; // TODO: remove
            if (infoJoueur.IndexOf("eur ") > 0)
                joueur.Id = int.Parse(infoJoueur.Substring(infoJoueur.IndexOf("eur ") + 4, 1));
            else
                joueur.Id = 2;

            // RECEPTION INFO MAP
            Plateau plateau = Plateau.getInstance();
            string infoMap = socket.Receive();
            plateau.Init(infoMap.Split('=')[1]);
            Console.WriteLine(infoMap);
            
            // DEBUT DU JEU
            string begin = socket.Receive();
            Console.WriteLine("Infos partie : " + begin);

            Console.ReadLine();
        }
    }
}
