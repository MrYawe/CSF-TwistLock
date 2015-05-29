using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fluffy
{
    class IAInit
    {
        public static List<Point> freePoints {get;set;} 
        public static Conteneur[,] freeConteneurs {get;set;}
        public IAInit()
        {
            freeConteneurs = Plateau.getInstance().conteneurs;

            /*for (int i = 0; i < freeConteneurs.GetLength(0); i++)
            {
                for (int j = 0; j < freeConteneurs.GetLength(1); j++)
                {
                    for(int k = 0; k < freeConteneurs.GetLength(0); k++)
                    {
                        for(int l = 0; l < freeConteneurs.GetLength(1); l++)
                        {
                            if(freeConteneurs[i,j].valeur < freeConteneurs[k,l].valeur)
                            {
                                Conteneur temp = new Conteneur(freeConteneurs[i,j].valeur, freeConteneurs[i,j].statut, freeConteneurs[i,j].coins);
                                freeConteneurs[i,j] = freeConteneurs[k,l];
                                freeConteneurs[k,l] = temp;
                            }
                        }
                    }
                }
            }*/

            freePoints = new List<Point>(Plateau.getInstance().points);
            /*SortPoint sp = new SortPoint();
            freePoints.Sort(sp);*/
        }

        public class SortPoint : IComparer<Point>
        {
            public int Compare(Point x, Point y)
            {
                return y.valeur - x.valeur;
            }
        }
    }
}
