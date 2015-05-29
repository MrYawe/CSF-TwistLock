using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fluffy
{
    class IARecherche
    {
        public IARecherche()
        {
            
        }

        public String searchPoint()
        {
            Point pt = IAInit.freePoints[0];
            List<Conteneur> ptParents = pt.conteneurs;
            String res = (ptParents[0].ligne+1).ToString() + Plateau.intToAscii(ptParents[0].colonne+1);
            for (int i = 0; i < ptParents[0].coins.Length; i++)
            {
                if (ptParents[0].coins[i] == pt)
                {
                    res += i+1;
                }
            }

            for (int i = 0; i < IAInit.freePoints.Count; i++)
            {
                Point ptTemp = IAInit.freePoints[i];
                List<Conteneur> parents = ptTemp.conteneurs;
                for (int j = 0; j < parents.Count; j++)
                {
                    String temp = (parents[j].ligne+1).ToString() + Plateau.intToAscii(parents[j].colonne+1);
                    for (int k = 0; k < parents[0].coins.Length; k++)
                    {
                        if (parents[0].coins[k] == ptTemp)
                        {
                            temp += k+1;
                        }
                    }
                    if (ConteneurPrenable(parents[j]) && ptTemp.valeur > pt.valeur && isActionValid(temp))
                    {
                        res = temp;
                        pt = ptTemp;
                    }
                }
            }
            IAInit.freePoints.Remove(pt);

            List<Conteneur> listCont = pt.conteneurs;

            foreach (Conteneur c in listCont)
            {
                int pointEnnemi = 0;
                int pointMoi = 0;

                if (c.coins[0].statut == Point.status.YOU) { pointEnnemi++; }
                else if (c.coins[0].statut == Point.status.ME) { pointMoi++; }

                if (c.coins[1].statut == Point.status.YOU) { pointEnnemi++; }
                else if (c.coins[1].statut == Point.status.ME) { pointMoi++; }

                if (c.coins[2].statut == Point.status.YOU) { pointEnnemi++; }
                else if (c.coins[2].statut == Point.status.ME) { pointMoi++; }

                if (c.coins[3].statut == Point.status.YOU) { pointEnnemi++; }
                else if (c.coins[3].statut == Point.status.ME) { pointMoi++; }

                if (pointEnnemi > pointMoi)
                {
                    c.statut = Point.status.YOU;
                    c.coins[0].valeur -= c.valeur;
                    c.coins[1].valeur -= c.valeur;
                    c.coins[2].valeur -= c.valeur;
                    c.coins[3].valeur -= c.valeur;
                }
                else if (pointEnnemi < pointMoi)
                {
                    c.statut = Point.status.ME;
                    c.coins[0].valeur += c.valeur;
                    c.coins[1].valeur += c.valeur;
                    c.coins[2].valeur += c.valeur;
                    c.coins[3].valeur += c.valeur;
                }
                else
                {
                    c.statut = Point.status.NONE;
                }
            }
            return res;
        }

        public bool ConteneurPrenable(Conteneur c)
        {
            Point[] coins = c.coins;
            int nbPointsEnnemis = 0;
            for (int i = 0; i < coins.Length; i++)
            {
                if (coins[i].statut == Point.status.YOU)
                {
                    nbPointsEnnemis++;
                }
            }
            return (nbPointsEnnemis < 2);
        }

        public static bool isActionValid(string action)
        {
            bool res;
            int ligne = 0;
            int colonne = 0;
            int point = 0;
            res = (action.Length == 3 && char.IsLetter(action[1]) || (action.Length == 4 && char.IsLetter(action[2])));
            
            if(action.Length == 3 && res)
            {
                ligne = int.Parse(action[0].ToString());
            }
            else if(action.Length == 4 && res)
            {
                ligne = int.Parse(action.Substring(0, 2));
            }

            if(action.Length == 3 && res)
            {
                colonne = action[1] - 'A' - 1;
            }
            else if (action.Length == 4 && res)
            {
                colonne = action[2] - 'A' - 1;
            }

            if (action.Length == 3 && res)
            {
                point = int.Parse(action[2].ToString());
            }
            else if (action.Length == 4 && res)
            {
                point = int.Parse(action[3].ToString());
            }
            

            res = (ligne >= 0 && ligne <= Plateau.getInstance().nbLignes - 1 && res);
            res = (colonne >= 0 && colonne <= Plateau.getInstance().nbColonnes - 1 && res);
            res = (point >= 0 && point <= 3 && res);

            return res;
        }
    }
}
