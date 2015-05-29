using FluffyNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
            int port        = 9877;

            // TESTING 
            Console.WriteLine("Server: " + server);
            //server = Console.ReadLine();
            Console.WriteLine("Port: " + port);
            //port = int.Parse(Console.ReadLine());

            // CONNECTION TO THE SERVER
            FSocket socket = new FSocket(server, port);
            socket.Connect();
            socket.Send(teamName);

            // RECEPTION INFO PLAYER
            Joueur joueur = new Joueur();
            string infoJoueur = socket.Receive();
            if (infoJoueur.IndexOf("eur ") > 0)
                joueur.Id = int.Parse(infoJoueur.Substring(infoJoueur.IndexOf("eur ") + 4, 1));
            else
                joueur.Id = 2;
            Console.WriteLine("ID JOUEUR : " + joueur.Id);

            // RECEPTION INFO MAP
            Plateau plateau = Plateau.getInstance();
            string infoMap = socket.Receive();
            plateau.Init(infoMap.Split('=')[1]);
            Console.WriteLine("MAP : " + infoMap.Split('=')[1]);
            
            // DEBUT DU JEU
            bool isActive = true; // Etat de la partie
            int turn = joueur.Id;
            while(isActive)
            {
                if (turn == 1)
                {
                    // Genere un coup
                    string coup = "";
                    socket.Send(coup);
                    Console.WriteLine("ENVOI : " + coup);
                }
                else
                {
                    // Reception du coup ennemi
                    string enCoup = socket.Receive();

                }
            }

            Console.ReadLine();
        }
    }
}
