using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fluffy
{
    class Point
    {
        public enum status { NONE, ME, YOU };
        public int valeur { get; set; }
        public status statut { get; set; } 
        public List<Conteneur> conteneurs { get; set;}
        public int id { get; set; }
        
        public Point(int id)
        {
            this.statut = status.NONE;
            this.valeur = 0;
            this.conteneurs = new List<Conteneur>();
            this.id = id;
        }

        public void changeStatus(status stat)
        {
            this.statut = stat;
            for (int i = 0; i<conteneurs.Count(); i++)
            {
                conteneurs[i].statut = stat;
            }
        }

        public void addParent(Conteneur cont)
        {
            conteneurs.Add(cont);
        }

        public override bool Equals(object obj)
        {
            bool res = false;

            if(obj is Point)
            {
                Point point = (Point)obj;

                if(point.id == this.id)
                {
                    res = true;
                }
            }

            return res;
        }

        public override int GetHashCode()
        {
            return this.id;
        }

        public static bool operator == (Point p1, Point p2)
        {
            return p1.id == p2.id;
        }

        public static bool operator != (Point p1, Point p2)
        {
            return p1.id != p2.id;
        }
    }
}
