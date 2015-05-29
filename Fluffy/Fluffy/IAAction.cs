using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fluffy
{
    class IAAction
    {
        public bool recieveAction(string action)
        {
            bool res = true;

            if(isActionValid(action))
            {
                int ligne = int.Parse(action[0].ToString());
                int colonne = action[1] - 'A' - 1;
                int point = int.Parse(action[2].ToString());

                Conteneur cont = Plateau.getInstance().conteneurs[ligne,colonne];
                cont.coins[point].statut = Point.status.ME;

                int pointEnnemi = 0;
                int pointMoi = 0;

                if (cont.coins[0].statut == Point.status.YOU) { pointEnnemi++; }
                else if (cont.coins[0].statut == Point.status.ME) { pointMoi++; }

                if (cont.coins[1].statut == Point.status.YOU) { pointEnnemi++; }
                else if (cont.coins[1].statut == Point.status.ME) { pointMoi++; }

                if (cont.coins[2].statut == Point.status.YOU) { pointEnnemi++; }
                else if (cont.coins[2].statut == Point.status.ME) { pointMoi++; }

                if (cont.coins[3].statut == Point.status.YOU) { pointEnnemi++; }
                else if (cont.coins[3].statut == Point.status.ME) { pointMoi++; }

                if (pointEnnemi > pointMoi)
                {
                    cont.statut = Point.status.YOU;
                    cont.coins[0].valeur -= cont.valeur;
                    cont.coins[1].valeur -= cont.valeur;
                    cont.coins[2].valeur -= cont.valeur;
                    cont.coins[3].valeur -= cont.valeur;
                }
                else if (pointEnnemi < pointMoi)
                {
                    cont.statut = Point.status.ME;
                    cont.coins[0].valeur += cont.valeur;
                    cont.coins[1].valeur += cont.valeur;
                    cont.coins[2].valeur += cont.valeur;
                    cont.coins[3].valeur += cont.valeur;
                }
                else
                {
                    cont.statut = Point.status.NONE;
                }
            }
            else
            {
                res = false;
            }

            return res;
        }

        public bool isActionValid(string action)
        {
            bool res;

            res = (action.Length == 3);
            res = (char.IsLetter(action[1]) && res);

            int ligne = int.Parse(action[0].ToString());
            int colonne = action[1] - 'A' - 1;
            int point = int.Parse(action[2].ToString());

            res = (ligne >= 0 && ligne <= Plateau.getInstance().nbLignes - 1 && res);
            res = (colonne >= 0 && colonne <= Plateau.getInstance().nbColonnes - 1 && res);
            res = (point >= 0 && point <= 3 && res);

            return res;
        }
    }
}
