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

        public Conteneur(int ligne, int colonne, int valeur)
        {
            this.statut = Point.status.NONE;
            this.valeur = valeur;
            int nbcolonne = Plateau.getInstance().nbColonnes;
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

    }
}
