using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fluffy
{
    class Conteneur
    {
        public int valeur { get; set; }
        public Point.status statut { get; set; }
        public Point[] coins { get; set; }
        public int ligne { get; set; }
        public int colonne { get; set; }

        public Conteneur(int ligne, int colonne, int valeur)
        {
            this.ligne = ligne;
            this.colonne = colonne;
            this.statut = Point.status.NONE;
            this.valeur = valeur;
            int nbcolonne = Plateau.getInstance().nbColonnes;
            this.coins = new Point[4];
            coins[0] = Plateau.getInstance().points[(ligne*nbcolonne)+colonne];
            coins[1] = Plateau.getInstance().points[(ligne*nbcolonne)+colonne+1];
            coins[2] = Plateau.getInstance().points[((ligne+1)*nbcolonne)+colonne];
            coins[3] = Plateau.getInstance().points[((ligne+1)*nbcolonne)+colonne+1];
            for (int i = 0; i < 4; i++)
            {
                coins[i].addParent(this);
                coins[i].valeur += valeur;
            }
        }

        public Conteneur(int valeur, Point.status statut, Point[] coins)
        {
            this.statut = statut;
            this.valeur = valeur;
            this.coins = new Point[4];
            this.coins[0] = coins[0];
            this.coins[1] = coins[1];
            this.coins[2] = coins[2];
            this.coins[3] = coins[3];
        }

        private void coinChanged(){
            int nbme = 0;
            int nbyou = 0;
            for(int i = 0; i < 4; i++)
            {
                if (coins[i].statut == Point.status.ME)
                    nbme++;
                else if (coins[i].statut == Point.status.YOU)
                    nbyou++;
            }
            if (nbme > nbyou){
                this.statut = Point.status.ME;
            }
            else if (nbyou > nbme)
            {
                this.statut = Point.status.YOU;
            }
            else
            {
                this.statut = Point.status.NONE;
            }
                
        }
    }
}
