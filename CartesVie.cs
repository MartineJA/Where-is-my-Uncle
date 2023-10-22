using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlayTheCards
{
    internal class CartesVie : Cartes
    {
        int gainVie;

        public CartesVie(string unNomCarte, string unAttribut, int unCout, int unGainVie) : base(unNomCarte, unAttribut, unCout)
        {
            unGainVie = gainVie;   
        }
    }



}
