using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fluffy
{
    class Plateau
    {
        public static Plateau instance {get;set;}
        public List<Point> points {get;set;}
        public Conteneur[,] conteneurs {get;set;}
        public int nbColonnes {get;set;}
        public int nbLignes {get;set;}


        public Plateau()
        {
            points = new List<Point>();
        }

        public void Init(string map)
        {
            string[] mesLignes = map.Split('|');
            this.nbLignes = mesLignes.Count()-1;
            this.nbColonnes = mesLignes[0].Split(':').Count();
            this.conteneurs = new Conteneur[this.nbLignes, this.nbColonnes];
            int nbPoints = (this.nbLignes+1)*(this.nbColonnes+1);

            for (int i = 0; i < nbPoints; i++ )
            {
                points.Add(new Point(i));
            }
           

            for (int lin = 0; lin < this.nbLignes; lin++ )
            {
                string[] valeurs = mesLignes[lin].Split(':');
                for (int col = 0; col < this.nbColonnes; col++)
                {
                    conteneurs[lin, col] = new Conteneur(lin, col, int.Parse(valeurs[col]));
                }
            }
        }

        public static int asciiToInt(char ascii) {
            return ((int)ascii) - 65; 
        }

        public static char intToAscii(int pos)
        {
            return (char)(pos+65);
        }
        public static Plateau getInstance()
        {
         
            if (Plateau.instance == null)
            {
                Plateau.instance = new Plateau();
            }

            return Plateau.instance;
        }

        public void pointChanged(String pos, Point.status joueur)
        {
            int ligne;
            int colonne;
            int coin;
            int point = -1;
            if (pos.Count() == 4)
            {
                ligne = 9;
                colonne = Plateau.asciiToInt(pos[2]);
                coin = int.Parse(pos.Substring(3, 1));
            }
            else
            {
                ligne = int.Parse(pos[0].ToString()) - 1;
                colonne = Plateau.asciiToInt(pos[1]);
                coin = int.Parse(pos[2].ToString());
            }
            switch (coin)
            {
                case 1:
                    point = (ligne * nbColonnes) + colonne;
                    break;
                case 2:
                    point = (ligne * nbColonnes) + colonne + 1;
                    break;
                case 3 :
                    point = ((ligne + 1) * nbColonnes) + colonne;
                    break;
                case 4 :
                    point = ((ligne + 1) * nbColonnes) + colonne +1;
                    break;
            }

            points[point].changeStatus(joueur);
            IAInit.freePoints.Remove(points[point]);
            for (int i = 0; i < points[point].conteneurs.Count(); i++)
            {
                Conteneur c = points[point].conteneurs[i];
                c.coinChanged();
                if (c.statut == Point.status.YOU)
                {
                    c.coins[0].valeur -= c.valeur;
                    c.coins[1].valeur -= c.valeur;
                    c.coins[2].valeur -= c.valeur;
                    c.coins[3].valeur -= c.valeur;
                }
                else if (c.statut == Point.status.ME)
                {
                    c.coins[0].valeur += c.valeur;
                    c.coins[1].valeur += c.valeur;
                    c.coins[2].valeur += c.valeur;
                    c.coins[3].valeur += c.valeur;
                }

            }
        }

        public void Show()
        {
            for (int i = 0; i < conteneurs.GetLength(0); i++)
            {
                for (int j = 0; j < conteneurs.GetLength(1); j++)
                {
                    Console.Write(conteneurs[i,j].valeur + " | ");
                }
                Console.WriteLine("");
            }
        }
    }
}
