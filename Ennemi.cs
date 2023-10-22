using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlayTheCards
{
    internal class Ennemi
    {
        public string nom;
        public int pointVie = 25;
        public int pointPsy = 15;
        public int argent;
        public List<Cartes> mainJoueur;


        public Ennemi (string unNom, int unPointVie, int unPointPsy, List<Cartes> uneMainEnnemi)
        {
            nom = unNom;
            pointVie = unPointVie;
            pointPsy = unPointPsy;
            mainJoueur = uneMainEnnemi;

        }

    }
}
