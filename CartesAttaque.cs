using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlayTheCards
{
    internal class CartesAttaque : Cartes
    {
        int dégat;
        public CartesAttaque(string unNomCarte, string unAttribut, int unCout, int unDégat) : base(unNomCarte, unAttribut, unCout)
        {
            unDégat = dégat;
        }
    }
}
