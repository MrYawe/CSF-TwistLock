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
        public static Conteneur[][] freeConteneurs {get;set;}
        public IAInit()
        {
            freeConteneurs = Plateau.getInstance().conteneurs;
            SortConteneur sc = new SortConteneur();
            Array.Sort(freeConteneurs, sc);

            freePoints = Plateau.getInstance().points;
            SortPoint sp = new SortPoint();
            freePoints.Sort(sp);
        }
    }

    public class SortConteneur : IComparer<Conteneur[]>
    {
        public int Compare(Conteneur x, Conteneur y)
        {
            return y.valeur - x.valeur;
        }
    }

    public class SortPoint : IComparer<Point>
    {
        public int Compare(Point x, Point y)
        {
            return y.valeur - x.valeur;
        }
    }
}
