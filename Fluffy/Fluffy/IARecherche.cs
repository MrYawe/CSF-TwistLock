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
            String res = ptParents[0].ligne.ToString() + ptParents[0].colonne.ToString();
            for (int i = 0; i < ptParents[0].coins.Length; i++)
            {
                if (ptParents[0].coins[i] == pt)
                {
                    res += i;
                }
            }

            for (int i = 0; i < IAInit.freePoints.Count; i++)
            {
                List<Conteneur> parents = IAInit.freePoints[i].conteneurs;
                for (int j = 0; j < parents.Count; i++)
                {
                    String temp = parents[j].ligne.ToString() + parents[j].colonne.ToString();
                    Point ptTemp = IAInit.freePoints[i];
                    for (int k = 0; k < ptParents[0].coins.Length; k++)
                    {
                        if (ptParents[0].coins[k] == ptTemp)
                        {
                            temp += k;
                        }
                    }
                    if (ConteneurPrenable(parents[j]) && IAInit.freePoints[i].valeur > ptTemp.valeur && isActionValid(temp))
                    {
                        res = temp;
                    }
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
