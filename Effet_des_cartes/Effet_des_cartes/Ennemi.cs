using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Effet_des_cartes
{
    internal class Ennemi
    {
        public int pointFolie;
        public int pointPsy;
        public List<Cartes> mainEnnemi;
        public Ennemi(int unPointFolie, int unPointPsy, List<Cartes> uneMainE)
        {
            pointFolie = unPointFolie;
            pointPsy = unPointPsy;
            mainEnnemi = uneMainE;
        }

        public void AfficherScore()
        {
            Console.WriteLine("Score de Folie ennemi :" + pointFolie);
            Console.WriteLine("Points Psy ennemi: " + pointPsy);
        }

    }   // c'est quoi une carte défense? 
        // une carte qui empêche une attaque pour un tour
        
}
