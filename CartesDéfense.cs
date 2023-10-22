using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlayTheCards 
{
    internal class CartesDéfense : Cartes
    {
        int défense;
        public CartesDéfense(string unNomCarte, string unAttribut, int unCout, int unDéfense) : base(unNomCarte, unAttribut, unCout)
        {
            unDéfense = défense;
        }
    }
}
