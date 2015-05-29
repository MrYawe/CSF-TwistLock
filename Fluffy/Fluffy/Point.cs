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
    }
}
