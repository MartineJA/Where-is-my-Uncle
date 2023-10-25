using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlayTheCards 
{
 
    
    internal class CartesBONUS : Cartes
    {
       
        string effetSpecial;

        public CartesBONUS(string unNomCarte, string unAttribut, int unCout, string aEffetSpecial) : base(unNomCarte, unAttribut, unCout)
        {
            aEffetSpecial = effetSpecial;
        }

   


    }
}
