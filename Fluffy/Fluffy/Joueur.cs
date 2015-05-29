using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fluffy
{
    class Joueur
    {
        private string id;
        private string couleur;
        private int nbTwistLock=20;


        public enum status { NONE, ONE, TWO };



        // Accessor
        public string id
        {
            get;
            set;
        }

        public string couleur
        {
            get;
            set;
        }

        public int nbTwistLock
        {
            get;
            set;
        }
    }
}
