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
        public Conteneur[][] conteneurs {get;set;}
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
            this.nbColonnes =mesLignes[0].Split(':').Count();
            int nbPoints = (this.nbLignes+1)*(this.nbColonnes+1);

            for (int i = 0; i < nbPoints; i++ )
            {
                points.Add(new Point());
            }
           

            for (int lin = 0; lin < this.nbLignes; lin++ )
            {
                string[] valeurs = mesLignes[lin].Split(':');
                for (int col = 0; col < this.nbColonnes; col++)
                {
                    conteneurs[lin][col] = new Conteneur(lin, col, int.Parse(valeurs[col]));
                }
            }
        }

        public static int asciiToInt(char ascii) {
            return ((int)ascii) - 65; 
        }

        public static int intToAscii(int pos)
        {
            return (Char)(pos+65);
        }
        public static Plateau getInstance()
        {
         
            if (Plateau.instance == null)
            {
                Plateau.instance = new Plateau();
            }

            return Plateau.instance;
        }
    }
}
