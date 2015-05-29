using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fluffy
{
    class Joueur
    {
        public enum status { NONE, ONE, TWO };

        public int Id
        {
            get;
            set;
        }
        public string Couleur
        {
            get;
            set;
        }
        public int NbTwistLock
        {
            get;
            set;
        }

        public Joueur()
        {
            NbTwistLock = 20;
        }
    }
}
