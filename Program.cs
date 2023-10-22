using System.Net;


namespace SlayTheCards
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string title = "\r\n\r\n__| |__________________________________________________________________| |__\r\n__   __________________________________________________________________   __\r\n  | |                                                                  | |  \r\n  | |    _     _ __   __ _______ ______   _______    ___ _______       | |  \r\n  | |   | | _ | |  | |  |       |    _ | |       |  |   |       |      | |  \r\n  | |   | || || |  |_|  |    ___|   | || |    ___|  |   |  _____|      | |  \r\n  | |   |       |       |   |___|   |_||_|   |___   |   | |_____       | |  \r\n  | |   |       |       |    ___|    __  |    ___|  |   |_____  |      | |  \r\n  | |   |   _   |   _   |   |___|   |  | |   |___   |   |_____| |      | |  \r\n  | |   |__| |__|__| |__|_______|___|  |_|_______|  |___|_______|      | |  \r\n  | |    __   __ __   __    __   __ __    _ _______ ___     _______    | |  \r\n  | |   |  |_|  |  | |  |  |  | |  |  |  | |       |   |   |       |   | |  \r\n  | |   |       |  |_|  |  |  | |  |   |_| |       |   |   |    ___|   | |  \r\n  | |   |       |       |  |  |_|  |       |       |   |   |   |___    | |  \r\n  | |   |       |_     _|  |       |  _    |      _|   |___|    ___|   | |  \r\n  | |   | ||_|| | |   |    |       | | |   |     |_|       |   |___    | |  \r\n  | |   |_|   |_| |___|    |_______|_|  |__|_______|_______|_______|   | |  \r\n__| |__________________________________________________________________| |__\r\n__   __________________________________________________________________   __\r\n  | |                                                                  | |  \r\n\r\n";



            List<Cartes> cartes = new List<Cartes>();
            List<Cartes> cartesJoueur = new List<Cartes>();
            List<Cartes> cartesEnnemi = new List<Cartes>();

            Random random = new Random();
            int randomPos = random.Next(0, cartes.Count);





            #region CARTES : Création
            CartesAttaque carte001 = new CartesAttaque ("Dermatillomanie", "Attaque", 4, 3); // PV - 5, Psy - 3
            CartesAttaque carte002 = new CartesAttaque("Humeur Dépressive", "Attaque", 10, 3); // PV -2, Psy -8
            CartesAttaque carte003 = new CartesAttaque("Agoraphobie", "Attaque", 2, 3); // PV - 0, Psy - 3
            CartesAttaque carte004 = new CartesAttaque("État Confusionnel", "Attaque", 12, 3); // PV - 3, Psy - 5, Cartes - 2
            CartesAttaque carte005 = new CartesAttaque("Amnésie Dissociative", "Attaque", 5, 3); // le joueur visé passe son tour
            CartesAttaque carte007 = new CartesAttaque("Kleptomanie", "Attaque", 4, 3); // PV -0 Psy -0, Cartes -1

            CartesDéfense carte006 = new CartesDéfense("Thésaurisation Pathologique", "Défense", 2, 3); // Psy - 5, Cartes + 3
              
            CartesThérapie carte008 = new CartesThérapie ("Méditation", "Thérapie", 5, 3); // Psy +3
            CartesThérapie carte009 = new CartesThérapie("Anti-dépresseur", "Thérapie", 4, 2); // Psy +2
            CartesThérapie carte010 = new CartesThérapie("Psychothérapie", "Thérapie", 15, 10); // Psy +10

            CartesVie carte011 = new CartesVie ("Pansement", "Vie", 2, 3); // PV +3
            CartesVie carte012 = new CartesVie ("Point de suture", "Vie", 4, 5); // PV +5
            CartesVie carte013 = new CartesVie ("Chirurgie", "Vie", 15, 10); // PV +10


            cartes.Add(carte001);
            cartes.Add(carte002);
            cartes.Add(carte003);   
            cartes.Add(carte004);   
            cartes.Add(carte005);   
            cartes.Add(carte006);   
            cartes.Add(carte007);   
            cartes.Add(carte008);
            cartes.Add(carte009);
            cartes.Add(carte010);
            cartes.Add(carte011);
            cartes.Add(carte012);
            cartes.Add(carte013);
            #endregion



            Joueur joueur = new Joueur ("DSMike", 25, 15, cartesJoueur);
            Ennemi ennemi = new Ennemi ("MyUncle", 25, 15, cartesEnnemi);

            Console.WriteLine(title);


            Console.WriteLine("Appuie sur une touche pour commencer une partie");
            Console.ReadKey();
            bool isGameRunning = true;


           

            // isGameRunning bool
            // CheckInput ()
            // UpdateStatus ()
            // Render ()



            /* faire une liste avec toutes les cartes ok
             * accéder à ces cartes pour en attribuer 3 AU HASARD au joueur
             * accéder à ces cartes pour en attribuer 3 AU HASARD à l'ennemi
             * afficher cartes ENNEMI et cartes JOUEUR*/


            
            
            if (isGameRunning)
            {
                CheckUpdate();
                //void UpdateStatus() { }
                //void Render() { }  // victoire/défaite/ titre du jeu
            }

            void CheckUpdate() 
            {

                    DébutPartie();

            }

            void AffichageCarte()
                {
                    Console.WriteLine(cartes.ElementAt(randomPos).nomCarte + "  " + cartes.ElementAt(randomPos).attribut+ "  " + cartes.ElementAt(randomPos).cout);

                }

            void DébutPartie() // peut-être donner à chaque joueur au moins une carte attaque au début de la partie
            {
                Console.WriteLine("Voici les cartes avec lesquelles vous commencerez la partie: ");
                for (int i = 0; i < 3; i++)
                {
                    cartesJoueur.Add(cartes.ElementAt(randomPos));
                    randomPos = random.Next(0, cartes.Count);
                    AffichageCarte();

                }

                for (int i = 0; i < 3; i++)
                {
                    cartesEnnemi.Add(cartes.ElementAt(randomPos));
                    randomPos = random.Next(0, cartes.Count);
                }



            }






        }
    }
}