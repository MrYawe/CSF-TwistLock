﻿using System;
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

            if(IARecherche.isActionValid(action))
            {
                int ligne = int.Parse(action.Length == 3 ? action[0].ToString() : action.Substring(0, 2));
                int colonne = action[1] - 'A' - 1;
                int point = int.Parse(action[2].ToString());

                Conteneur cont = Plateau.getInstance().conteneurs[ligne,colonne];
                
                cont.coins[point].statut = Point.status.YOU;
                List<Conteneur> tabCont = cont.coins[point].conteneurs;

                IAInit.freePoints.Remove(cont.coins[point]);

                foreach(Conteneur c in tabCont)
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
                        c.coins[0].valeur -= cont.valeur;
                        c.coins[1].valeur -= cont.valeur;
                        c.coins[2].valeur -= cont.valeur;
                        c.coins[3].valeur -= cont.valeur;
                    }
                    else if (pointEnnemi < pointMoi)
                    {
                        c.statut = Point.status.ME;
                        c.coins[0].valeur += cont.valeur;
                        c.coins[1].valeur += cont.valeur;
                        c.coins[2].valeur += cont.valeur;
                        c.coins[3].valeur += cont.valeur;
                    }
                    else
                    {
                        c.statut = Point.status.NONE;
                    }
                }   
            }
            else
            {
                res = false;
            }

            return res;
        }

        public String SendAction()
        {
            IARecherche search = new IARecherche();
            return search.searchPoint();
        }
    }
}
