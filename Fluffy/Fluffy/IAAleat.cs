using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fluffy
{
    class IAAleat
    {
        public String SendAction()
        {
            Random r = new Random();
            int ligne = r.Next(1,Plateau.getInstance().nbLignes);
            int colonne = r.Next(1, Plateau.getInstance().nbColonnes);
            int coin = r.Next(1, 4);
            String res = ligne + Plateau.intToAscii(colonne) + coin.ToString();
            while (!IARecherche.isActionValid(res))
            {
                ligne = r.Next(1, Plateau.getInstance().nbLignes);
                colonne = r.Next(1, Plateau.getInstance().nbColonnes);
                coin = r.Next(1, 4);
                res = ligne + Plateau.intToAscii(colonne) + coin.ToString();
            }
            return res;
        }
    }
}
