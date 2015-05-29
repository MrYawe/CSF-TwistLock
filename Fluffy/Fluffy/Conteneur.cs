using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fluffy
{
    class Conteneur
    {
        public enum status { NONE, ME, YOU };
        public int valeur { get; set; }
        public status statut { get; set; }
        public Point[] coins { get; set; }

        public Conteneur(int ligne, int colonne, int valeur)
        {
            this.statut = status.NONE;
            this.valeur = valeur;
            int nbcolonne = Plateau.getInstance().colonnes;
            coins[0] = Plateau.getInstance().points[(ligne*nbcolonne)+colonne];
            coins[1] = Plateau.getInstance().points[(ligne*nbcolonne)+colonne+1];
            coins[2] = Plateau.getInstance().points[((ligne+1)*nbcolonne)+colonne];
            coins[3] = Plateau.getInstance().points[((ligne+1)*nbcolonne)+colonne+1];
            coins[0].valeur += valeur;
            coins[1].valeur += valeur;
            coins[2].valeur += valeur;
            coins[3].valeur += valeur;
        }

    }
}
