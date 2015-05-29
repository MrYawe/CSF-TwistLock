using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fluffy
{
    class Point
    {
        public enum status { NONE, ONE, TWO };
        int valeur { get; set; }
        status statut { get; set; }
        
        public Point()
        {
            this.statut = status.NONE;
            this.valeur = 0;
        }

        
    }
}
