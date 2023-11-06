using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;

namespace Effet_des_cartes
{
    internal class Joueur 
    {
        public int pointFolie;
        public int pointPsy;
        public List<Cartes> mainJoueur;
        public int index;

        public Joueur(int unPointFolie,int unPointPsy, List<Cartes> uneMainJ) 
        { 
            pointFolie = unPointFolie;
            pointPsy = unPointPsy;
            mainJoueur = uneMainJ;
           
        }

        public void AfficherScore()
        {
            Console.WriteLine("Votre Score de Folie :" + pointFolie);
            Console.WriteLine("Vos Points Psy: " + pointPsy);
        }

        public void AfficherCarte(int index)
        {
            // il faut afficher dans des cases les caractéristiques des carte
            // il faut que ces caractéristiques changent quand de nouvelles cartes sont piochées
            Console.WriteLine("╔═════════════════════");
            Console.WriteLine("║ nom: " + mainJoueur.ElementAt(index).nom + "\n" + "║ ID: " + mainJoueur.ElementAt(index).iD);
            Console.WriteLine("cette carte inflige " + mainJoueur.ElementAt(index).effetFolie + " de folie à votre adversaire");
            Console.WriteLine("╠═════════════════════");

        }

        public void ChangerCarte(int index) // besoin d'accéder à la liste <pioche>
        {
            // il faut afficher dans des cases les caractéristiques des carte
            // il faut que ces caractéristiques changent quand de nouvelles cartes sont piochées
            Console.WriteLine("╔═════════════════════");
            Console.WriteLine("║ nom: " + mainJoueur.ElementAt(index).nom + "\n" + "║ ID: " + mainJoueur.ElementAt(index).iD);
            Console.WriteLine("cette carte inflige " + mainJoueur.ElementAt(index).effetFolie + " de folie à votre adversaire");
            Console.WriteLine("╠═════════════════════");

        }

    }
}
