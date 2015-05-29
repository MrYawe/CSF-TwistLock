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

        public Point searchPoint()
        {
            Point res = IAInit.freePoints[0];
            for (int i = 0; i < IAInit.freePoints.Count; i++)
            {
                List<Conteneur> parents = IAInit.freePoints[i].conteneurs;
                for (int j = 0; j < parents.Count; i++)
                {
                    if (ConteneurPrenable(parents[j]) && IAInit.freePoints[i].valeur > res.valeur)
                    {
                        res = IAInit.freePoints[i];
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
    }
}
