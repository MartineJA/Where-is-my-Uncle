using System;
using System.Collections.Immutable;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.Design;
using System.IO;
using System.Reflection;

namespace Effet_des_cartes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region INTRO
            string title = "\r\n\r\n █████╗ ███████╗██╗   ██╗██╗     ██╗   ██╗███╗   ███╗\r\n██╔══██╗██╔════╝╚██╗ ██╔╝██║     ██║   ██║████╗ ████║\r\n███████║███████╗ ╚████╔╝ ██║     ██║   ██║██╔████╔██║\r\n██╔══██║╚════██║  ╚██╔╝  ██║     ██║   ██║██║╚██╔╝██║\r\n██║  ██║███████║   ██║   ███████╗╚██████╔╝██║ ╚═╝ ██║\r\n╚═╝  ╚═╝╚══════╝   ╚═╝   ╚══════╝ ╚═════╝ ╚═╝     ╚═╝\r\n                                                     \r\n███████╗██╗ ██████╗ ██╗  ██╗████████╗                \r\n██╔════╝██║██╔════╝ ██║  ██║╚══██╔══╝                \r\n█████╗  ██║██║  ███╗███████║   ██║                   \r\n██╔══╝  ██║██║   ██║██╔══██║   ██║                   \r\n██║     ██║╚██████╔╝██║  ██║   ██║                   \r\n╚═╝     ╚═╝ ╚═════╝ ╚═╝  ╚═╝   ╚═╝                   \r\n\r\n";
            Console.WriteLine(title);

            //Console.WriteLine("Asylum Fight");

            Console.WriteLine("Quel est ton nom?");
            string name = Console.ReadLine();
            Console.WriteLine(name + " " + "après un simple rendez-vous de routine chez ton psy, tu te retrouves enfermé.e à l'asile");
            Console.WriteLine("Pour t'échapper, tu dois rendre le chef de service de l'asile fou");

            Console.WriteLine("Appuie sur une touche pour commencer la partie");
            Console.ReadKey();
            bool isGameRunning = true;

            #endregion

            #region EXAMPLES
            Cartes C1 = new Cartes("01","Karta", 300, 12, 0);
            Cartes C2 = new Cartes("02","Paizo", 301, 05, 0);
            Cartes C3 = new Cartes("03","Thiella", 302, 04, 0);
            Cartes C4 = new Cartes("04","Liono", 303, 10, 0);
            #endregion

            #region FOLIE Cards



            // Cartes Folie
            Cartes Folie01 = new Cartes("100","Agoraphobie", 100, 03, 1);
            Cartes Folie02 = new Cartes("101","Dermatillomanie", 101, 05, 1);
            Cartes Folie03 = new Cartes("102","Trichotillomanie", 102, 05, 1);
            Cartes Folie04 = new Cartes("103","Humeur dépressive", 103, 07, 1);
            Cartes Folie05 = new Cartes("104","Amnésie dissociative", 104, 08, 1);
            Cartes Folie06 = new Cartes("105","Trouble factice", 105, 08, 1);
            Cartes Folie07 = new Cartes("106","Insomnie", 106, 10, 1);
            Cartes Folie08 = new Cartes("107","Pyromanie", 107, 15, 1);
            Cartes Folie09 = new Cartes("108","Kleptomanie", 108, 15, 1);
            Cartes Folie10 = new Cartes("109","État confusionnel", 109, 20, 1);

            List<Cartes> folieClassée = new List<Cartes>()
            {
                Folie01, Folie01,
                Folie02, Folie02,
                Folie03, Folie03,
                Folie04, Folie04, Folie04,
                Folie05, Folie05,
                Folie06,
                Folie07, Folie07, Folie07,
                Folie08,
                Folie09,
                Folie10
            };
            #endregion

            //Cartes D1 = new Cartes("Parakalo", 401, 13);
            //Cartes D2 = new Cartes("Soupa", 402, 14);

            #region PSY Cards
            // Cartes Psy // diminue les points de folie // coûte des points psy
            Cartes Psy01 = new Cartes("500","Thérapie", 500, 15, 3);
            Cartes Psy02 = new Cartes("501","Méditation", 501, 10, 2);
            Cartes Psy03 = new Cartes("502","Anxiolytiques", 502, 5, 1);

            List<Cartes> psyClassée = new List<Cartes>()
            {
                Psy01, Psy01, Psy01, Psy01,
                Psy02, Psy02, Psy02, Psy02,
                Psy03, Psy03, Psy03, Psy03, Psy03, Psy03,
            };
            #endregion

            #region OBJETS Cards
            // Cartes Objets // Empêche la prochaine attaque // bouclier qui coûte point Psy
            Cartes Objet01 = new Cartes("600","x", 600, -5, -5);
            Cartes Objet02 = new Cartes("601","y", 601, -5, -5);
            Cartes Objet03 = new Cartes("602","z", 602, -5, -5);
            Cartes Objet04 = new Cartes("603","a", 603, -5, -5);
            Cartes Objet05 = new Cartes("604","b", 604, -5, -5);

            List<Cartes> objetsClassée = new List<Cartes>()
            {
                Objet01,Objet01,
                Objet02, Objet02,
                Objet03, Objet03,
                Objet04, Objet04,
                Objet05, Objet05
            };
            #endregion

            #region init player/enemy
            List<Cartes> mainJoueur = new List<Cartes>();
            List<Cartes> mainEnnemi = new List<Cartes>();


            Joueur player = new Joueur(0, 5, mainJoueur);
            Ennemi enemy = new Ennemi(0, 5, mainEnnemi);


            Random random = new Random();
            int rdmF = random.Next(0, folieClassée.Count);
            int rdmP = random.Next(0, psyClassée.Count);
            int rdmO = random.Next(0, objetsClassée.Count);

            #endregion

            #region PIOCHE : cartes qu'il reste après distribution
            List<Cartes> pioche = new List<Cartes>();

            for (int i = 0; i < folieClassée.Count; i++)
            {
                pioche.Add(folieClassée.ElementAt(i));
            }
            for (int i = 0; i < psyClassée.Count; i++)
            {
                pioche.Add(psyClassée.ElementAt(i));
            }
            for (int i = 0; i < objetsClassée.Count; i++)
            {
                pioche.Add(objetsClassée.ElementAt(i));
            }

            //Console.WriteLine(pioche.Count + "w");
            #endregion

            #region INVENTAIRE DE TOUTES LES CARTES : la réf

            List<Cartes> inventaire = new List<Cartes>();
            Cartes[] inventaireArray = new Cartes[pioche.Count];

            for (int i = 0; i < folieClassée.Count; i++)
            {
                inventaire.Add(folieClassée.ElementAt(i));
                inventaireArray[i] = folieClassée[i];
            }
            for (int i = 0; i < psyClassée.Count; i++)
            {
                inventaire.Add(psyClassée.ElementAt(i));
                inventaireArray[i] = folieClassée[i];
            }
            for (int i = 0; i < objetsClassée.Count; i++)
            {
                inventaire.Add(objetsClassée.ElementAt(i));
                inventaireArray[i] = folieClassée[i];
            }
            #endregion




            // isGameRunning bool
            // CheckInput ()
            // UpdateStatus ()
            // Render ()

            if (isGameRunning)
            {
                CheckUpdate();
                //void UpdateStatus() { }
                //void Render() { }  // victoire/défaite/ titre du jeu
            }

            void CheckUpdate()
            {
                DistributionCartesJoueur();
                DistributionCartesEnnemi();

                

                while (player.pointFolie <50 ||enemy.pointFolie < 50)
                {
                    string reponse = Console.ReadLine();
                    ChoixJoueur();
                    ChoixEnnemi();

                }


            }
           
            // mélanger les cartes des différentes listes
            // les distribuer 
            // pioche = ce qu'il reste dans chaque liste après les distributions



            void MélangerFolie()
            {
                mainJoueur.Add(folieClassée.ElementAt(rdmF));
                rdmF = random.Next(0, folieClassée.Count);
                //Console.WriteLine("╔═════════════════════");
                //Console.WriteLine("║ nom: " + mainJoueur.ElementAt(0).nom + "\n" + "║ ID: " + mainJoueur.ElementAt(0).iD);
                pioche.Remove(folieClassée.ElementAt(rdmF));
                // Console.WriteLine(pioche.Count + "joueur");
                //Console.WriteLine("cette carte inflige " + mainJoueur.ElementAt(0).effetFolie + " de folie à votre adversaire");
                //Console.WriteLine("╠═════════════════════");
                player.AfficherCarte(0);

                for (int i = 1; i < 3; i++)
                {
                    rdmF = random.Next(0, folieClassée.Count);

                    if (mainJoueur.Contains(folieClassée.ElementAt(rdmF)))
                    {
                        rdmF = random.Next(0, folieClassée.Count);
                        i -= 1;

                    }
                    else
                    {
                        mainJoueur.Add(folieClassée.ElementAt(rdmF));
                        //Console.WriteLine("║ nom: " + mainJoueur.ElementAt(i).nom + "\n" + "║ ID: " + mainJoueur.ElementAt(i).iD);
                        pioche.Remove(folieClassée.ElementAt(rdmF));
                        //Console.WriteLine(pioche.Count + "joueur");
                        //Console.WriteLine("cette carte inflige " + mainJoueur.ElementAt(i).effetFolie + " de folie à votre adversaire");
                        //Console.WriteLine("╠═════════════════════");
                        player.AfficherCarte(i);
                    }

                }


            }
            void MélangerPsy()
            {
                mainJoueur.Add(psyClassée.ElementAt(rdmP));
                rdmP = random.Next(0, psyClassée.Count);
                Console.WriteLine("║ nom: " + mainJoueur.ElementAt(3).nom + "\n" + "║ ID: " + mainJoueur.ElementAt(3).iD);
                pioche.Remove(psyClassée.ElementAt(rdmP));
                //Console.WriteLine(pioche.Count + "joueurPsy");
                Console.WriteLine("cette carte vous permet d'enlever " + mainJoueur.ElementAt(3).effetFolie + " à votre score de Folie ");
                Console.WriteLine("cette carte coûte " + mainJoueur.ElementAt(3).effetPsy + " points Psy");
                Console.WriteLine("╠═════════════════════");


                for (int i = 1; i < 2; i++)
                {
                    rdmP = random.Next(0, psyClassée.Count);

                    if (mainJoueur.Contains(psyClassée.ElementAt(rdmP)))
                    {
                        rdmP = random.Next(0, psyClassée.Count);
                        i -= 1;
                    }
                    else
                    {
                        mainJoueur.Add(psyClassée.ElementAt(rdmP));
                        Console.WriteLine("║ nom: " + mainJoueur.ElementAt(i + 3).nom + "\n" + "║ ID: " + mainJoueur.ElementAt(i + 3).iD);
                        pioche.Remove(psyClassée.ElementAt(rdmP));
                        //Console.WriteLine(pioche.Count + "joueurPsy");
                        Console.WriteLine("Cette carte vous permet d'enlever " + mainJoueur.ElementAt(i + 3).effetFolie + " à votre score de Folie ");
                        Console.WriteLine("Cette carte coûte " + mainJoueur.ElementAt(i + 3).effetPsy + " points Psy");
                        Console.WriteLine("╠═════════════════════");
                    }

                }

            }

            void MélangerFolieEnnemi()
            {
                mainEnnemi.Add(folieClassée.ElementAt(rdmF));
                rdmF = random.Next(0, folieClassée.Count);
                //Console.WriteLine(mainEnnemi.ElementAt(0).nom);
                pioche.Remove(folieClassée.ElementAt(rdmF));
                //Console.WriteLine(pioche.Count + "ennemiF");

                for (int i = 1; i < 3; i++)
                {
                    rdmF = random.Next(0, folieClassée.Count);

                    if (mainJoueur.Contains(folieClassée.ElementAt(rdmF)))
                    {
                        rdmF = random.Next(0, folieClassée.Count);
                        i -= 1;

                    }
                    else
                    {
                        mainEnnemi.Add(folieClassée.ElementAt(rdmF));
                        //Console.WriteLine(mainEnnemi.ElementAt(i).nom);
                        pioche.Remove(folieClassée.ElementAt(rdmF));
                        //Console.WriteLine(pioche.Count + "ennemiF");
                    }

                }


            }
            void MélangerPsyEnnemi()
            {
                mainEnnemi.Add(psyClassée.ElementAt(rdmP));
                rdmP = random.Next(0, psyClassée.Count);
                //Console.WriteLine(mainEnnemi.ElementAt(3).nom);
                pioche.Remove(psyClassée.ElementAt(rdmP));
                //Console.WriteLine(pioche.Count + "ennemiPsi");

                for (int i = 1; i < 2; i++)
                {
                    rdmP = random.Next(0, psyClassée.Count);

                    if (mainJoueur.Contains(psyClassée.ElementAt(rdmP)))
                    {
                        rdmP = random.Next(0, psyClassée.Count);
                        i -= 1;
                    }
                    else
                    {
                        mainEnnemi.Add(psyClassée.ElementAt(rdmP));
                        //Console.WriteLine(mainEnnemi.ElementAt(i).nom);
                        pioche.Remove(psyClassée.ElementAt(rdmP));
                        //Console.WriteLine(pioche.Count + "ennemiPsi");
                    }

                }

            }

            void DistributionCartesJoueur()

            {
                // on distribue ses cartes au joueur:
                // 3Folie
                // 2Psy
                // 1Objet
                Console.WriteLine("voici vos cartes");
                MélangerFolie();
                MélangerPsy();
                mainJoueur.Add(objetsClassée.ElementAt(rdmO));
                //AffichageObjet();
                Console.WriteLine("Pour jouer une carte, tapez son ID");

            }
            void DistributionCartesEnnemi()
            {
                // on distribue ses cartes à l'ennemi (après distribJoueur)
                MélangerFolieEnnemi();
                MélangerPsyEnnemi();
                mainEnnemi.Add(objetsClassée.ElementAt(rdmO));
                //AffichageObjet();

            }

            void AffichageCartesFolie()
            {
                Console.WriteLine("cartes folie " + folieClassée.ElementAt(rdmF).nom + " "
                                 + folieClassée.ElementAt(rdmF).effetFolie + " "
                                 + folieClassée.ElementAt(rdmF).effetPsy + " "
                                 + "ID: " + folieClassée.ElementAt(rdmF).iD);
            }
            void AffichageCartesPsy()
            {
                Console.WriteLine("cartes psy " + psyClassée.ElementAt(rdmP).nom + " "
                                 + psyClassée.ElementAt(rdmP).effetFolie + " "
                                 + psyClassée.ElementAt(rdmP).effetPsy + " "
                                 + "ID: " + psyClassée.ElementAt(rdmP).iD);
            }
            void AffichageObjet()
            {
                Console.WriteLine(objetsClassée.ElementAt(rdmO).nom + " "
                                  + objetsClassée.ElementAt(rdmO).iD);
            }


            void ChoixJoueur()
            {

                #region  Commentaires
                // action du joueur
                // perte pointPsy
                // gain pointFolie
                // utilisationObjet
                // carte retourne dans pioche
                /* Comment appliquer l'effet d'une carte sur joueur et ennemi basé sur le choix d'ID?
                 * 
                 */

                // on compare avec un élément présent dans la liste mainJoueur

                // si la réponse est égale au nom d'une carte présente dans la main,
                // on applique les effets de la carte à l'ennemi

                #endregion  

                string reponse = Console.ReadLine();
                int index;

                // cartes attaque

                if (reponse == mainJoueur.ElementAt(1).numéro)
                {
                    index = 1;

                    Console.WriteLine(mainJoueur.ElementAt(index).nom + " a été jouée");
                    Console.WriteLine("l'ennemi gagne " + mainJoueur.ElementAt(index).effetFolie + "de folie");

                    enemy.pointFolie = +mainJoueur.ElementAt(index).effetFolie;

                    mainJoueur.Remove(mainJoueur.ElementAt(index));
                    mainJoueur.Add(pioche.ElementAt(0));

                    Console.WriteLine("vous piochez la carte: " + pioche.ElementAt(0).nom);

                }
                if (reponse == mainJoueur.ElementAt(2).numéro)
                {
                    index = 2;
                    
                    Console.WriteLine(mainJoueur.ElementAt(index).nom + " a été jouée");
                    Console.WriteLine("l'ennemi gagne " + mainJoueur.ElementAt(index).effetFolie + "de folie");
                    
                    enemy.pointFolie = +mainJoueur.ElementAt(index).effetFolie;
                    
                    mainJoueur.Remove(mainJoueur.ElementAt(index));
                    mainJoueur.Add(pioche.ElementAt(0));
                    
                    Console.WriteLine("vous piochez la carte: " + pioche.ElementAt(0).nom);

                }
                if (reponse == mainJoueur.ElementAt(0).numéro)
                {
                    index = 0;
                    
                    Console.WriteLine(mainJoueur.ElementAt(index).nom + " a été jouée");
                    Console.WriteLine("l'ennemi gagne " + mainJoueur.ElementAt(index).effetFolie + "de folie");
                    
                    enemy.pointFolie = +mainJoueur.ElementAt(index).effetFolie;
                    
                    mainJoueur.Remove(mainJoueur.ElementAt(index));
                    mainJoueur.Add(pioche.ElementAt(0));
                    
                    Console.WriteLine("vous piochez la carte: " + pioche.ElementAt(0).nom);

                }

                // cartes soins 

                if (reponse == mainJoueur.ElementAt(3).numéro)
                {
                    index = 3;
                    Console.WriteLine(mainJoueur.ElementAt(index).nom + " a été jouée");


                    Console.WriteLine("votre score de folie diminue de " + mainJoueur.ElementAt(index).effetFolie + " points");
                    Console.WriteLine("cette carte vous coûte " + mainJoueur.ElementAt(index).effetPsy + " points psy");

                    player.pointFolie -= mainJoueur.ElementAt(index).effetFolie;
                    player.pointPsy -= mainJoueur.ElementAt(index).effetPsy;

                    mainJoueur.Remove(mainJoueur.ElementAt(index));

                    mainJoueur.Add(pioche.ElementAt(0));
                    Console.WriteLine("vous piochez la carte: " + pioche.ElementAt(0).nom);

                }
                if (reponse == mainJoueur.ElementAt(4).numéro)
                {
                    index = 4;
                    Console.WriteLine(mainJoueur.ElementAt(index).nom + " a été jouée");


                    Console.WriteLine("votre score de folie diminue de " + mainJoueur.ElementAt(index).effetFolie + " points");
                    Console.WriteLine("cette carte vous coûte " + mainJoueur.ElementAt(index).effetPsy + " points psy");

                    player.pointFolie -= mainJoueur.ElementAt(index).effetFolie;
                    player.pointPsy -= mainJoueur.ElementAt(index).effetPsy;

                    mainJoueur.Remove(mainJoueur.ElementAt(index));

                    mainJoueur.Add(pioche.ElementAt(0));
                    Console.WriteLine("vous piochez la carte: " + pioche.ElementAt(0).nom);

                }


                player.AfficherScore();
                enemy.AfficherScore();
             
   

                #region TESTS
                /* List<Cartes> inventaireClassé = new List<Cartes>
                 {
                     C1,
                     C2,
                     C3,
                     C4
                 };

                 List<Cartes> mainEnemy = new List<Cartes>
                 {
                     C4, //302
                     C3, //303
                     C1 //301
                 };
                 // si joueur choisit C1 il se passe (...) effet de carte

                 Console.WriteLine("voici tes cartes");
                 Console.WriteLine();
                 string reponse = Console.ReadLine();*/
                #endregion
                #region COMMENTAIRES
                /*
                            if (reponse == "C1")
                            {
                                Console.WriteLine("la carte coûte " + C1.cout);
                                Console.WriteLine("tu perds" + C1.cout + "points de vie");
                                player.pointVie = player.pointVie-C1.cout;
                                Console.WriteLine(player.pointVie);

                            }
                */
                // id cartes
                // simplifier les effets


                // ennemi
                // action : joue une carte, effet de carte appliquée au joueur

                /* comment l'ennemi choisit sa carte? 
                 * 
                 * -- random
                 * -- algo de choix à créer
                 * 
                 * ennemi has cards; best choice possible; meaning?
                 * --> id de cartes: hiérarchiser. [] 
                 * ennemi choisit la carte avec l'index le plus élevé   
                 * conditions: il a peu de pv dc il joue la meilleure carte soin qu'il a 
                 *             il a peu de ppsy dc ...
                 *             il a une excellente carte attaque, dc il attaque
                 *
                 */

                // enemy choisit la carte qui a l'index le plus élevé dans la liste inventaireClassé
                #endregion







            }
            void ChoixEnnemi()
            {
                int index = 1;

                Console.WriteLine("l'ennemi joue une carte " + mainEnnemi.ElementAt(index).nom);
                Console.WriteLine("l'ennemi t'inflige " + mainEnnemi.ElementAt(index).effetFolie + " points de folie");

                player.pointFolie += mainEnnemi.ElementAt(index).effetFolie;

                mainEnnemi.Remove(mainEnnemi.ElementAt(index));
                mainEnnemi.Add(pioche.ElementAt(0));

                player.AfficherScore();
                enemy.AfficherScore();
                Console.WriteLine("quelle carte souhaites-tu jouer?");
                
                
                
            }


            
        }
    }
}