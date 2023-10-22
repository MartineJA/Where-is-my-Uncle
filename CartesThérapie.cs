using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlayTheCards
{
    internal class CartesThérapie : Cartes
    {
        int gainPsy;

        public CartesThérapie(string unNomCarte, string unAttribut, int unCout, int unGainPsy) : base(unNomCarte, unAttribut, unCout)
        {
            unGainPsy = gainPsy;

        }



    }
}
