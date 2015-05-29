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

        }

        public void init(string map)
        {
            string[] mesLignes = map.Split('|');
            int nbLigne = mesLignes.Count()-1;
            int nbColonne =mesLignes[0].Split(':').Count();
            int nbPoints = (nbLigne+1)*(nbColonne+1);

            for (int i = 0; i < nbPoints; i++ )
            {
                points.Add(new Point());
            }
           

            for (int lin = 0; lin < nbLigne; lin++ )
            {
                string[] valeurs = mesLignes[lin].Split(':');
                for (int col = 0; col < nbColonne; col++)
                {
                    conteneurs[lin][col] = new Conteneur(lin, col, int.Parse(valeurs[col]));
                }
            }
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
