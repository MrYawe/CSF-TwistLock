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
            string teamName = "Comic Sans Fluffy ";
            string server   = "172.30.7.16";
            int port        = 9204;

            // TESTING
            Console.WriteLine(teamName);
            Console.WriteLine("Server: " + server);
            //server = Console.ReadLine();
            Console.WriteLine("Port: " + port);
            //port = int.Parse(Console.ReadLine());

            // CONNECTION TO THE SERVER
            FSocket socket = new FSocket(server, port);
            socket.Connect();
            Thread.Sleep(500);
            
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
            try
            {
                Console.WriteLine("MAP : " + infoMap.Split('=')[1]);
                plateau.Init(infoMap.Split('=')[1]);
            }
            catch
            {
                infoMap = socket.Receive();
                plateau.Init(infoMap.Split('=')[1]);
            }
            plateau.Show();
            IAInit ia = new IAInit();
            
            // DEBUT DU JEU
            bool isActive = true; // Etat de la partie
            while(isActive)
            {
                string response = socket.Receive();
                string code = "";
                if (response.Length > 2)
                    code = response.Substring(0, 2);
                Console.WriteLine(response);

                // 10- Notre tour
                if (code == "10")
                {
                    // Genere un coup
                    IAAction ia_action = new IAAction();
                    string coup = ia_action.SendAction(); // TODO: RECEPTION DU CODE A JOUER
                    socket.Send(coup);
                    Console.WriteLine("ENVOI : " + coup + " taille : " + coup.Count());
                }
                // 20- Tour ennemi
                else if(code == "20")
                {
                    // Reception du coup ennemi
                    string enCoup = "";
                    try
                    {
                        enCoup = response.Split(':')[2].Substring(0, response.IndexOf('\n'));
                        Console.WriteLine("RECEPTION : " + enCoup);
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    IAAction iac = new IAAction();
                    iac.recieveAction(enCoup);
                    plateau.pointChanged(enCoup, Point.status.YOU);
                    // Update map
                    // TODO: METTRE A JOUR

                }
                // 88- Partie Terminée, vous avez perdu/gagné + score
                else if(code == "88")
                {
                    isActive = true;
                }

                // Ignore
                // 21- Coup joué inégal
                // 22- Coup adversaire illégal
                // 50- Vous ne pouvez plus jouer
            }

            Console.ReadLine();
        }
    }
}
