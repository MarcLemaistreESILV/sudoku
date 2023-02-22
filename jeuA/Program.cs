using System;
using System.Collections.Generic;

namespace jeuA
{
    public class Program
    {
       
        public static List<byte> valeures_prise_cases_vides = new List<byte>();
        public static List<byte> position_case_vide = new List<byte>();
        public static int[,] grille_sudoku = new int[9, 9];
        public static int[,] grille_sudoku_ennonce = new int[9, 9];
        public const byte TAILLE_CARRE = 3;
        static void Main(string[] args)
        {
            int brassage = 100;

            int[,] plateau = {
                    { 1   , 4   ,   7   ,   3   ,   5   ,   8   ,   2   ,   6   ,   9   },
                    { 2   , 5   ,   8   ,   1   ,   6   ,   9   ,   3   ,   4   ,   7   },
                    { 3   , 6   ,   9   ,   2   ,   4   ,   7   ,   1   ,   5   ,   8   },
                    { 7   , 1   ,   4   ,   8   ,   3   ,   5   ,   9   ,   2   ,   6   },
                    { 8   , 2   ,   5   ,   9   ,   1   ,   6   ,   7   ,   3   ,   4   },
                    { 9   , 3   ,   6   ,   7   ,   2   ,   4   ,   8   ,   1   ,   5   },
                    { 4   , 7   ,   1   ,   5   ,   8   ,   3   ,   6   ,   9   ,   2   },
                    { 5   , 8   ,   2   ,   6   ,   9   ,   1   ,   4   ,   7   ,   3   },
                    { 6   , 9   ,   3   ,   4   ,   7   ,   2   ,   5   ,   8   ,   1   }
                };
            int[,] plateauTestA = {
                {0,0,0, 0,0,0, 0,0,0},
                {0,0,0, 0,0,0, 0,0,0},
                {0,0,0, 0,0,0, 0,0,0},

                {0,0,0, 0,0,0, 0,0,0},
                {0,0,0, 0,0,0, 0,0,0},
                {0,0,0, 0,0,0, 0,0,0},

                {0,0,0, 0,0,0, 0,0,0},
                {0,0,0, 0,0,0, 0,0,0},
                {0,0,0, 0,0,0, 0,0,0}
                };
            int[,] plateauTestB = {
                {1,0,8, 0,0,0, 0,0,0},
                {2,0,9, 5,6,0, 0,1,0},
                {3,0,0, 0,0,0, 0,2,0},

                {4,0,0, 0,9,0, 0,0,0},
                {5,0,0, 0,0,0, 0,0,0},
                {6,0,0, 0,0,0, 7,0,0},

                {7,0,0, 0,0,0, 0,0,0},
                {8,0,0, 0,0,0, 0,0,0},
                {9,0,0, 0,0,0, 0,0,0}
                };

            int[,] plateauTestC = {
                {1,3,0, 6,4,8, 7,0,2, },
                {7,4,8, 1,5,2, 6,3,9, },
                {6,5,2, 7,0,9, 1,4,0, },

                {9,1,3, 8,6,4, 2,7,5, },
                {0,7,4, 2,1,0, 9,6,3, },
                {2,6,0, 9,7,3, 8,1,4, },

                {3,9,1, 0,8,6, 5,2,7, },
                {4,8,7, 5,2,1, 3,9,6, },
                {5,2,6, 3,0,7, 4,8,1, },

                };
            int[,] plateauTestD = {
                {0,5,2, 0,6,0, 0,0,0, },
                {0,6,7, 9,3,1, 8,5,0, },
                {8,0,0, 0,5,2, 9,6,0, },

                {2,0,5, 7,0,6, 0,0,3, },
                {0,4,0, 1,9,3, 2,0,5, },
                {0,0,3, 2,4,0, 0,9,0, },

                {5,2,9, 6,0,8, 0,1,4, },
                {6,0,0, 3,1,9, 5,2,8, },
                {0,1,0, 5,2,0, 0,0,0, },

                };



            valeures_prise_cases_vides.Clear();
            position_case_vide.Clear();
            grille_sudoku_ennonce = plateauTestD;
              resolution_sudoku();
              Console.WriteLine("success D");

            valeures_prise_cases_vides.Clear();
            position_case_vide.Clear();
            grille_sudoku_ennonce = plateauTestC;
              resolution_sudoku();
              Console.WriteLine("success C");

            valeures_prise_cases_vides.Clear();
            position_case_vide.Clear();
            grille_sudoku_ennonce = plateauTestB;
              resolution_sudoku();
              Console.WriteLine("success B");

            valeures_prise_cases_vides.Clear();
            position_case_vide.Clear();
            grille_sudoku_ennonce = plateauTestA;
            resolution_sudoku();
            Console.WriteLine("success A");

        }


        #region IA7
       

        /// <summary>
        /// résoud le sudoku
        /// </summary>
        public static void resolution_sudoku()
        {

            tableau_equalizer();


            resoudre_systeme();
            affichage(grille_sudoku);
            while (!sudoku_fini())
            {
    
                choix();
                resoudre_systeme();
                
            }
            
        }
      
        /// <summary>
        /// regarde si le sudoku est fini
        /// </summary>
        /// <returns>true si le sudoku est fini</returns>
        public static bool sudoku_fini()
        {
            bool case_vide = false;

            for (int ligne = 0; ligne < grille_sudoku.GetLength(0); ligne++)
            {
                for (int colonne = 0; colonne < grille_sudoku.GetLength(1); colonne++)
                {
                    if (grille_sudoku[ligne, colonne] == 0)
                    {
                        case_vide = true;
                        break;
                    }
                }
            }
            return !case_vide;
        }
        
        /// <summary>
        /// rempli toutes les cases ou le résutlat est certain
        /// </summary>
        public static void resoudre_systeme()
        {
            bool a_change = false;
            do
            {
                a_change = false;
                for (byte ligne = 0; ligne < grille_sudoku.GetLength(0); ligne++)
                {
                    for (byte colonne = 0; colonne < grille_sudoku.GetLength(1); colonne++)
                    {
                        if (grille_sudoku[ligne, colonne] == 0)
                        {
                            if (!a_change && resoudre_case(ligne, colonne))
                            {
                                a_change = true;
                            }
                        }
                    }
                }
            } while (a_change);
        }
        
        /// <summary>
        /// rempli une case avec la bonne valeur ou renvoit false (pas résoluble mais pas encore bloquage)
        /// en paramètres les position de la ligne et de la colonne de la case
        /// </summary>
        /// <returns></returns>
        public static bool resoudre_case(byte position_ligne, byte position_colonne)
        {
           
            bool est_resolue = false;
            bool[] pas_possibilite = non_possibilite_function(position_ligne, position_colonne);
            //ejection de l'unique bonne valeur et test du bloquage
            byte choix_fait = 0;
            for(byte index =1; index < pas_possibilite.Length; index++)
            {
                if (!pas_possibilite[index])
                {
                    if(choix_fait != 0)
                    {
                        est_resolue = false;
                        break;
                    }
                    else
                    {
                        est_resolue = true;
                        choix_fait = (byte)(index);
                    }
   
                }
            }
            if (est_resolue)
            {
                grille_sudoku[position_ligne, position_colonne] = (int)(choix_fait);
            }
            return est_resolue;
        }

        /// <summary>
        /// rempli une case manquante et enregistre ou est quoi a été rempli
        /// s'il n'y pas de choix mais une case vide appel bloquage
        /// </summary>
        public static void choix()
        {
            //chope le premier emplacement possible
            byte position_ligne =0;
            byte position_colonne =0;
            bool fin = true; 
            for (byte ligne = 0; ligne < grille_sudoku.GetLength(0) && fin; ligne++)
            {
                for (byte colonne = 0; colonne < grille_sudoku.GetLength(1) && fin; colonne++)
                {
                    if(grille_sudoku[ligne, colonne] == 0)
                    {
                        position_ligne = ligne;
                        position_colonne = colonne;

                        fin = false;
                    }
                }
            }
            //on essaie de remplir la case
            if (!remplir_une_case(position_ligne, position_colonne))
            {   
                if (!incrementer_une_case())
                {
                    if (!remonter_une_case())
                    {
                        Console.WriteLine("erreur");
                    }
                }
            }
            //on complète
            tableau_equalizer();
            for (int case_a_remplir = 0; case_a_remplir < valeures_prise_cases_vides.Count; case_a_remplir++)
            {
                grille_sudoku[position_case_vide[case_a_remplir * 2], position_case_vide[case_a_remplir * 2 + 1]] = valeures_prise_cases_vides[case_a_remplir];
            }  
        }
        /// <summary>
        /// permet de resoudre une case lorsqu'on a plusieurs choix (prend celui après le dernier qu'on est choisi avant)
        /// sinon appel bloquage
        /// </summary>
        public static void resoudre_case_cas_particuliers(byte position_ligne, byte position_colonne)
        {
            bool[] pas_possibilite = non_possibilite_function(position_ligne, position_colonne);
          
            //selections des choix
            bool est_resolue = false;
            //on regarde si on change un valeur ou si on en cré une autre
            if(grille_sudoku[position_ligne, position_colonne] == 0)
            {
                position_case_vide.Add(position_ligne);
                position_case_vide.Add(position_colonne);
                valeures_prise_cases_vides.Add(0);
            }
            //on lui donne la valeur
            for (byte index = 1; index < pas_possibilite.Length; index++)
            {
                if (!pas_possibilite[index])
                {
                    
                    est_resolue = true;
                    grille_sudoku[position_ligne, position_colonne] = index;
                    valeures_prise_cases_vides[valeures_prise_cases_vides.Count - 1] = index;
                    break;
                }
            }
     
            //bloquage
            if (!est_resolue)
            {
               // bloquage(pas_possibilite, index );
            }
        }
        /// <summary>
        /// renvoit un tableau de bool avec une premier case inutile puis true si la valeur de l'index est prise false sinon
        /// </summary>
        /// <param name="position_ligne"></param>
        /// <param name="position_colonne"></param>
        /// <returns></returns>
        public static bool[] non_possibilite_function(byte position_ligne, byte position_colonne)
        {
            
            bool[] pas_possibilite = new bool[TAILLE_CARRE * TAILLE_CARRE + 1];//le +1 permet juste de ne pas avoir à faire de test mais sinon il est inutile                                                                       //test ligne
            for (byte ligne = 0; ligne < grille_sudoku.GetLength(0); ligne++)
            {
                pas_possibilite[grille_sudoku[ligne, position_colonne]] = true;
            }
            //test colonne
            for (byte colonne = 0; colonne < grille_sudoku.GetLength(1); colonne++)
            {
                pas_possibilite[grille_sudoku[position_ligne, colonne]] = true;
            }
            //test carre
            for (byte ligne = 0; ligne < TAILLE_CARRE; ligne++)
            {
                for (byte colonne = 0; colonne<TAILLE_CARRE; colonne++)
                {
                    pas_possibilite[grille_sudoku[(position_ligne) - (position_ligne % TAILLE_CARRE) + ligne, (position_colonne) - (position_colonne % TAILLE_CARRE)+ colonne]] = true;
                }
            }
            return pas_possibilite;
        }
        /// <summary>
        /// grille_sudoku <- grille_sudoku_ennoncé
        /// </summary>
        public static void tableau_equalizer()
        {
            for(int i =0; i < grille_sudoku.GetLength(0); i++)
            {
                for (int j = 0; j < grille_sudoku.GetLength(1); j++)
                {
                    grille_sudoku[i, j] = grille_sudoku_ennonce[i, j];
                }
            }
        }
     
        /// <summary>
        /// remonte d'une case 
        /// </summary>
        public static bool remonter_une_case()
        {
            
            if(valeures_prise_cases_vides.Count > 0)
            {

                //on initialise
                supprimer_case();

                //on prépare la boucle suivante
                while (valeures_prise_cases_vides.Count > 0 && !incrementer_une_case())
                {
                    supprimer_case();
                   
                }
                if(valeures_prise_cases_vides.Count == 0)
                {
                    return false;
                }
                else
                {
                   
                   resoudre_systeme();
                    return true;
                }
            }
            else
            {
                return false;
            }
            
        }
        public static bool remplir_une_case(byte position_ligne, byte position_colonne)
        {
            
            if (grille_sudoku[position_ligne, position_colonne] == 0)
            {
                bool[] pas_possiblilite = non_possibilite_function(position_ligne, position_colonne);
                for(byte index =1; index < pas_possiblilite.Length+1; index++)
                {
                    if(index == pas_possiblilite.Length)
                    {
                        return false;
                    }
                    else if (!pas_possiblilite[index])
                    {
                        ajouter_case(position_ligne, position_colonne, index);
                        return true;
                    }
                }
                
            }
            else
            {
                return false;
            }
            return true;
        }
        /// <summary>
        /// incrémente si sur la même case sinon délègue
        /// </summary>
        public static bool incrementer_une_case()
        {

            tableau_equalizer();
            for (int case_a_remplir = 0; case_a_remplir < valeures_prise_cases_vides.Count-1; case_a_remplir++)
            {
                grille_sudoku[position_case_vide[case_a_remplir * 2], position_case_vide[case_a_remplir * 2 + 1]] = valeures_prise_cases_vides[case_a_remplir];
            }

            resoudre_systeme();
            //568
           
            bool[] pas_possibilite = non_possibilite_function(position_case_vide[position_case_vide.Count - 2], position_case_vide[position_case_vide.Count - 1]);
          
            for (byte index = (byte)(valeures_prise_cases_vides[valeures_prise_cases_vides.Count-1] +1); index < pas_possibilite.Length + 1; index++)
            {
                if (index == pas_possibilite.Length)
                {
                   
                    grille_sudoku[position_case_vide[position_case_vide.Count - 2], position_case_vide[position_case_vide.Count - 1]] = valeures_prise_cases_vides[valeures_prise_cases_vides.Count - 1];
                    return false;
                }
                else if (!pas_possibilite[index])
                {
                    grille_sudoku[position_case_vide[position_case_vide.Count - 2], position_case_vide[position_case_vide.Count - 1]] = (int)(index);
                    valeures_prise_cases_vides[valeures_prise_cases_vides.Count - 1] = index;
                    return true;
                }
            }
          
            return true;
        }
        #endregion
        /// <summary>
        /// a utiliser pour modifier une case determinée par choix
        /// retire tout jusqu'à la dernière case modifiée et modifie le tableau de remplissage
        /// </summary>
        /// <param name="plateau"></param>
        public static void supprimer_case()
        {
            grille_sudoku[position_case_vide[position_case_vide.Count - 2], position_case_vide[position_case_vide.Count - 1]] = 0;
            position_case_vide.RemoveAt(position_case_vide.Count - 1);
            position_case_vide.RemoveAt(position_case_vide.Count - 1);
            valeures_prise_cases_vides.RemoveAt(valeures_prise_cases_vides.Count - 1);
        }
        public static void ajouter_case(byte ligne, byte colonne, byte valeur)
        {
           
            position_case_vide.Add(ligne);
            position_case_vide.Add(colonne);
            valeures_prise_cases_vides.Add(valeur);
            grille_sudoku[ligne, colonne] = (int)(valeur);
            grille_sudoku[position_case_vide[position_case_vide.Count - 2], position_case_vide[position_case_vide.Count - 1]] = (int)(valeur);
        }
        public static void affichage(int[,] plateau)
        {
            Console.Write("{\n");
            for (int i = 0; i < plateau.GetLength(0); i++)
            {
                Console.Write("{");
                for (int j = 0; j < plateau.GetLength(1); j++)
                {
                    Console.Write(plateau[i, j] + ",");
                    if ((j + 1) % 3 == 0)
                    {
                        Console.Write(" ");
                    }
                }
                Console.Write("},\n");
                if ((i + 1) % 3 == 0)
                {
                    Console.WriteLine();
                }

            }
            Console.Write("}\n");
        }


    }
}

