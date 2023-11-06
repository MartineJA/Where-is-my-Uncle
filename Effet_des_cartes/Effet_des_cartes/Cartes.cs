
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Effet_des_cartes
{
    internal class Cartes 

    {

        public string nom;
        public string numéro;

        public int iD;
        public int effetPsy;
        public int effetFolie;
        

        public Cartes(string unNuméro, string unNom, int unId, int uneFolie, int unePsy)
        {
            numéro = unNuméro;
            nom = unNom;
            iD = unId;
            effetPsy = unePsy;
            effetFolie = uneFolie;
        }



    }

    
}
