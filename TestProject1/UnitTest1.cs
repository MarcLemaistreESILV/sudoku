using Microsoft.VisualStudio.TestTools.UnitTesting;
using jeuA;
using System;
using System.Collections.Generic;

namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void IA7_systeme()
        {
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
            //=> correct
        }
        public void IA7_sudoku_terminé()
        {

            //=> correct
        }
        [TestMethod]
        public void IA5_sensibilite_frequence()
        {
            int[,] plateauTestA = {
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
            List<int>[] possibilite = Program.IA3_possibilite_colonnes(plateauTestA, 1);
            (int min, List<int>[] frequences) = Program.IA5_sensibilite_frequence(possibilite);
            Program.affichage(frequences);
            List<int>[] result1 = new List<int>[9];
            for(int i =0; i <9; i++)
            {
                result1[i] = new List<int>();
            }
            result1[1].Add(9);
            result1[2].Add(8);
            result1[4].Add(5);
            result1[4].Add(6);
            result1[4].Add(7);
            result1[5].Add(1);
            result1[5].Add(2);
            result1[5].Add(3);
            result1[5].Add(4);
            for(int i =0; i < 9; i++)
            {
                for (int j = 0; j < result1[i].Count; j++)
                {
                    Assert.AreEqual(result1[i][j], frequences[i][j]);
                }
            }
            Assert.AreEqual(min, 1);
        }


        [TestMethod]
        public void complexite()
        {
            Assert.AreEqual(1, Program.complexite(0));
            Assert.AreEqual(1, Program.complexite(1));
            Assert.AreEqual(2, Program.complexite(2));
            Assert.AreEqual(6, Program.complexite(3));
            Assert.AreEqual(24, Program.complexite(4));
            Assert.AreEqual(120, Program.complexite(5));
            Assert.AreEqual(720, Program.complexite(6));
            Assert.AreEqual(5040, Program.complexite(7));
            Assert.AreEqual(40320, Program.complexite(8));
            Assert.AreEqual(362880, Program.complexite(9));
        }
        [TestMethod]
        public void IA3_possibilite_colonnes()
        {
            int[,] plateauTestC = {
                {0,0,8, 0,0,0, 0,0,0},
                {0,0,9, 5,6,0, 0,1,0},
                {0,0,0, 0,0,0, 0,2,0},

                {0,1,2, 3,9,4, 5,6,7},
                {0,0,0, 0,0,0, 0,0,0},
                {0,0,0, 0,0,0, 7,0,0},

                {1,2,3, 4,5,6, 7,8,9},
                {0,0,0, 0,0,0, 0,0,0},
                {0,0,0, 0,0,0, 0,0,0}
                };
            #region construction
            List<int> result1_0 = new List<int>();
            result1_0.Add(2);
            result1_0.Add(3);
            result1_0.Add(4);
            result1_0.Add(5);
            result1_0.Add(6);
            result1_0.Add(7);

            List<int> result1_1 = new List<int>();
            result1_1.Add(2);
            result1_1.Add(3);
            result1_1.Add(4);
            result1_1.Add(7);

            List<int> result1_2 = new List<int>();
            result1_2.Add(3);
            result1_2.Add(4);
            result1_2.Add(5);
            result1_2.Add(6);
            result1_2.Add(7);

            List<int> result1_3 = new List<int>();
            result1_3.Add(8);

            List<int> result1_4 = new List<int>();
            result1_4.Add(3);
            result1_4.Add(4);
            result1_4.Add(5);
            result1_4.Add(6);
            result1_4.Add(7);
            result1_4.Add(8);
            result1_4.Add(9);

            List<int> result1_5 = new List<int>();
            result1_5.Add(3);
            result1_5.Add(4);
            result1_5.Add(5);
            result1_5.Add(6);
            result1_5.Add(8);
            result1_5.Add(9);

            List<int> result1_6 = new List<int>();
            result1_6.Add(1);

            List<int> result1_7 = new List<int>();
            result1_7.Add(4);
            result1_7.Add(5);
            result1_7.Add(6);
            result1_7.Add(7);
            result1_7.Add(8);
            result1_7.Add(9);

            List<int> result1_8 = new List<int>();
            result1_8.Add(4);
            result1_8.Add(5);
            result1_8.Add(6);
            result1_8.Add(7);
            result1_8.Add(8);
            result1_8.Add(9);
            List<int>[] result1 = { result1_0, result1_1, result1_2, result1_3, result1_4, result1_5, result1_6, result1_7, result1_8 };
            #endregion

            List<int>[] possibilite = Program.IA3_possibilite_colonnes(plateauTestC, 0);
            for(int i =0; i < 9; i++)
            {
                for(int j =0; j < possibilite[i].Count; j++)
                {
                    Assert.AreEqual(possibilite[i][j], result1[i][j]);
                }
            }
            
        }


        [TestMethod]
        public void IA4_focage_simple()
        {
            int[,] plateauTestA = {
                {0,0,8, 0,0,0, 0,0,0},
                {0,0,9, 5,6,0, 0,1,0},
                {0,0,0, 0,0,0, 0,2,0},

                {0,1,2, 3,9,4, 5,6,7},
                {0,0,0, 0,0,0, 0,0,0},
                {0,0,0, 0,0,0, 7,0,0},

                {0,0,0, 0,0,0, 0,0,0},
                {0,0,0, 0,0,0, 0,0,0},
                {0,0,0, 0,0,0, 0,0,0}
                };
            List<int>[] possibilite = Program.IA3_possibilite_colonnes(plateauTestA, 0);
            Program.IA4_focage_simple(plateauTestA, possibilite, 0);
            Assert.AreEqual(0, plateauTestA[0, 0]);
            Assert.AreEqual(8, plateauTestA[3, 0]);
        }
        [TestMethod]
        public void IA4_forcage()
        {
            int[,] plateauTestA = {
                {0,0,8, 0,0,0, 0,0,0},
                {0,0,9, 5,6,0, 0,1,0},
                {0,0,0, 0,0,0, 0,2,0},

                {0,1,2, 3,9,4, 5,6,7},
                {0,0,0, 0,0,0, 0,0,0},
                {0,0,0, 0,0,0, 7,0,0},

                {0,0,0, 0,0,0, 0,0,0},
                {0,0,0, 0,0,0, 0,0,0},
                {0,0,0, 0,0,0, 0,0,0}
                };
            
            List<int>[] possibilite = Program.IA3_possibilite_colonnes(plateauTestA, 0);
            int[] ordre_forcage = Program.IA3_ordre_forcage(plateauTestA, 0);
            Program.IA4_forcage(plateauTestA, ordre_forcage,  possibilite, 0);
            Assert.AreEqual(1, plateauTestA[0, 0]);
            Assert.AreEqual(8, plateauTestA[3, 0]);
            Assert.AreEqual(9, plateauTestA[8, 0]);


            int[] ordre_forcage2 = { 1, 0, 2, 3, 4, 5, 7, 8 };
            int[,] plateauTestB = {
                { 1,0,8, 0,0,0, 0,0,0, },
                { 2,0,9, 5,6,0, 0,1,0, },
                { 3,0,0, 0,0,0, 0,2,0, },

                { 8,1,2, 3,9,4, 5,6,7, },
                { 4,0,0, 0,0,0, 0,0,0, },
                { 5,0,0, 0,0,0, 7,0,0, },

                { 6,0,0, 0,0,0, 0,0,0, },
                { 7,0,0, 0,0,0, 0,0,0, },
                { 9,0,0, 0,0,0, 0,0,0, }
            };

        }
        [TestMethod]
        public void IA3_test_colonne()
        {
            int[,] plateauTestA = {
                {0,0,8, 1,0,0, 0,3,0},
                {0,0,0, 2,6,0, 0,1,0},
                {0,0,0, 3,0,0, 0,2,0},

                {0,0,0, 4,9,0, 0,7,0},
                {0,0,0, 5,0,0, 0,4,0},
                {0,0,0, 6,0,0, 7,5,0},

                {0,0,0, 7,0,0, 0,6,0},
                {0,0,0, 8,0,0, 0,9,0},
                {0,0,0, 9,0,0, 0,8,0}
                };
            (bool a, bool b) = Program.IA3_test_colonne(plateauTestA, 0);
            Assert.IsTrue(a);
            Assert.IsFalse(b);
            (a, b) = Program.IA3_test_colonne(plateauTestA, 7);
            Assert.IsFalse(a);
            Assert.IsFalse(b);
            (a, b) = Program.IA3_test_colonne(plateauTestA, 3);
            Assert.IsFalse(a);
            Assert.IsTrue(b);
        }
            

        [TestMethod]
        public void IA3_valeurs_intersection_tableau()
        {
            int[] tab1 = { 0, 1, 5, 9 };
            int[] tab2 = { 0, 1, 5, 9 };
            int[] tab3 = { 0, 1, 9, 5 };
            int[] tab4 = { 1, 2, 3, 4, 5, 9 };
            int[] tab5 = { 2,3,4,7,8};
  
            List<int> result1 = Program.IA3_valeurs_intersection_tableau(tab1, tab2);
            List<int> result2 = Program.IA3_valeurs_intersection_tableau(tab1, tab3);
            List<int>  result3 = Program.IA3_valeurs_intersection_tableau(tab1, tab4);
            List<int> result4 = Program.IA3_valeurs_intersection_tableau(tab1, tab5);

            Assert.AreEqual(result1[2], 9);
            Assert.AreEqual(result2[2], 9);
            Assert.AreEqual(result2.Count, 3);
            Assert.AreEqual(result3[2], 9);
            Assert.AreEqual(result3.Count, 3);
            Assert.AreEqual(result4.Count, 0);
        }
        [TestMethod]
        public void encadrement()
        {
            List<int>[] tab1 = new List<int>[9];
            
            Random e = new Random();
            for(int i =0; i < 9; i++)
            {
                tab1[i] = new List<int>();
                for (int j =0; j < 3; j++)
                {
                    tab1[i].Add(e.Next(0, 10));
                }
            }
            tab1[0].RemoveAt(0);
            Assert.AreEqual(tab1[0].Count, 2);//temoin
            tab1[1].Add(9);
            Assert.AreEqual(tab1[1].Count, 4);
            (int min, int max) = Program.encadrement(tab1);
            Assert.AreEqual(min, 2);
            Assert.AreEqual(max, 4);
            tab1[0].Add(8);
            (min, max) = Program.encadrement(tab1);
            Assert.AreEqual(min, 3);
            Assert.AreEqual(max, 4);
            tab1[1].RemoveAt(0);
            tab1[4].RemoveAt(0);
            (min, max) = Program.encadrement(tab1);
            Assert.AreEqual(min, 2);
            Assert.AreEqual(max, 3);
        }
        [TestMethod]
        public void IA3_valeurs_possibles()
        {
            int[,] plateau = {
            {0,0,9   ,0,2,1,  0,0,4 },
            {3,0,1   ,0,0,4  ,0,0,9},
            {0,5,4   ,0,6,9  ,0,0,1},

             {0,0,6  ,0,0,2  ,4,3,5},
             {1,0,2  ,0,0,5  ,9,7,6},
             {4,0,5  ,0,0,0  ,1,8,2},

             {6,0,8  ,0,0 ,7  ,5,0,3},
             {0,0,3  ,0,4 ,0  ,0,0,7},
             {5,0,7  ,0,0 ,0  ,2,0,8}
            };
            List<int>[] result1 = Program.IA3_valeurs_possibles(plateau, 0);
            /*
             * expected output :
             * 7 8
             * 3
             * 2 7 8
             * 7 8 9
             * 1
             * 4
             * 6
             * 2 9 
             * 5
             */
            int[] tailleA = { 2, 1, 3, 3, 1, 1, 1, 2, 1 };
            for (int i = 0; i < 9; i++)
            {
                Assert.AreEqual(result1[i].Count, tailleA[i]);
            }
            Assert.AreEqual(result1[0][0], 7);
            Assert.AreEqual(result1[0][1], 8);
            Assert.AreEqual(result1[2][2], 8);
            List<int>[] result2 = Program.IA3_valeurs_possibles(plateau, 3);
            /*
             * expected output :
             * 3 5 7 8 
             * 5 7 8 
             * 3 7 8 
             * 1 7 8 9 
             * 3 4 8
             * 3 6 7 9
             * 1 2 9
             * 1 2 5 6 8 9
             * 1 3 6 9
              */
            int[] tailleB = { 4, 3, 3, 4, 3, 4, 3, 6, 4 };
            for (int i = 0; i < 9; i++)
            {
                Assert.AreEqual(result2[i].Count, tailleB[i]);
            }
            Assert.AreEqual(result2[0][0], 3);
            Assert.AreEqual(result2[0][1], 5);
            Assert.AreEqual(result2[0][2], 7);
            Assert.AreEqual(result2[0][3], 8);
            Assert.AreEqual(result2[2][2], 8);

            List<int>[] result3 = Program.IA3_valeurs_possibles(plateau, 8);
            /*
             * expected output :
             * 4
             * 9
             * 1
             * 5
             * 6
             * 2
             * 3
             * 7 
             * 8
              */
            for (int i =0; i < 9; i++)
            {
                Assert.AreEqual(result3[i].Count, 1);
            }
            
        }


        [TestMethod]
        public void Testremplir_trivial_ligne()
        {

            int[,] plateauA = {
                    { 1   , 0   ,   0   ,   0   ,   5   ,   0   ,   2   ,   6   ,   9   },
                    { 0   , 5   ,   0   ,   1   ,   6   ,   0   ,   3   ,   4   ,   7   },
                    { 3   , 0   ,   9   ,   0   ,   4   ,   7   ,   1   ,   5   ,   8   },
                    { 7   , 1   ,   4   ,   0   ,   3   ,   5   ,   9   ,   0   ,   6   },
                    { 8   , 2   ,   0   ,   9   ,   0   ,   6   ,   7   ,   3   ,   4   },
                    { 9   , 3   ,   6   ,   0   ,   2   ,   0   ,   8   ,   1   ,   0   },
                    { 4   , 7   ,   1   ,   5   ,   0   ,   3   ,   6   ,   0   ,   2   },
                    { 5   , 8   ,   2   ,   6   ,   9   ,   1   ,   4   ,   7   ,   3   },
                    { 0   , 0   ,   0   ,   4   ,   7   ,   2   ,   5   ,   8   ,   1   }
                };
            int[,] plateau0 = {
                    {0,0,0,0,0,0,0,0,0},
                    {0,0,0,0,0,0,0,0,0},
                    {0,0,0,0,0,0,0,0,0},
                    {0,0,0,0,0,0,0,0,0},
                    {0,0,0,0,0,0,0,0,0},
                    {0,0,0,0,0,0,0,0,0},
                    {0,0,0,0,0,0,0,0,0},
                    {0,0,0,0,0,0,0,0,0},
                    {0,0,0,0,0,0,0,0,0}
                };
            
            int[] ligneA = Program.matrice_a_tableau(plateauA, 0, true);
            int[] plateau_ligneA = Program.valeur_possibles_ligne(ligneA);
            Assert.AreEqual(plateau_ligneA[0], 3);
            Assert.AreEqual(plateau_ligneA[1], 4);
            Assert.AreEqual(plateau_ligneA[2], 7);
            Assert.AreEqual(plateau_ligneA[3], 8);
            int[] ligneB = Program.matrice_a_tableau(plateauA, 7, true);
            int[] plateau_ligneB = Program.valeur_possibles_ligne(ligneB);
            Assert.AreEqual(plateau_ligneB.Length, 0);

            int[] ligne0 = Program.matrice_a_tableau(plateau0, 0, true);
            int[] plateau_ligne0 = Program.valeur_possibles_ligne(ligne0);
            Assert.AreEqual(plateau_ligne0[8], 9);
            Assert.AreEqual(plateau_ligne0[0], 1);


        }
        [TestMethod]
        public void Testremplir_trivial_colonne()
        {

            int[,] plateauA = {
                    { 1   , 0   ,   0   ,   0   ,   5   ,   0   ,   2   ,   6   ,   9   },
                    { 0   , 5   ,   0   ,   1   ,   6   ,   0   ,   3   ,   4   ,   7   },
                    { 3   , 0   ,   9   ,   0   ,   4   ,   0   ,   1   ,   5   ,   8   },
                    { 0   , 1   ,   4   ,   0   ,   3   ,   0   ,   9   ,   0   ,   6   },
                    { 8   , 2   ,   0   ,   9   ,   0   ,   0   ,   7   ,   3   ,   4   },
                    { 0   , 3   ,   6   ,   0   ,   2   ,   0   ,   8   ,   1   ,   5   },
                    { 4   , 7   ,   1   ,   5   ,   0   ,   0   ,   6   ,   0   ,   2   },
                    { 5   , 8   ,   2   ,   6   ,   9   ,   0   ,   4   ,   7   ,   3   },
                    { 0   , 0   ,   0   ,   4   ,   7   ,   0   ,   5   ,   8   ,   1   }
                };

            int[] colonneA = Program.matrice_a_tableau(plateauA, 0, false);
            int[] plateau_colonneA = Program.valeur_possibles_ligne(colonneA);
            Assert.AreEqual(plateau_colonneA[0], 2);
            Assert.AreEqual(plateau_colonneA[1], 6);
            Assert.AreEqual(plateau_colonneA[2], 7);
            Assert.AreEqual(plateau_colonneA[3], 9);
            
            int[] colonneB = Program.matrice_a_tableau(plateauA, 8, false);
            int[] plateau_colonneB = Program.valeur_possibles_colonne(colonneB);
            Assert.AreEqual(plateau_colonneB.Length, 0);

            int[] colonneC = Program.matrice_a_tableau(plateauA, 1, false);
            int[] plateau_colonneC = Program.valeur_possibles_colonne(colonneC);
            Assert.AreEqual(plateau_colonneC[0], 4);
            Assert.AreEqual(plateau_colonneC[1], 6);
            Assert.AreEqual(plateau_colonneC[2], 9);
            Assert.AreEqual(plateau_colonneC.Length, 3);

            int[] colonne0 = Program.matrice_a_tableau(plateauA, 5, false);
            int[] plateau_colonne0 = Program.valeur_possibles_colonne(colonne0);
            Assert.AreEqual(plateau_colonne0[8], 9);
            Assert.AreEqual(plateau_colonne0[0], 1);


        }
        [TestMethod]
        public void Testremplir_trivial_carre()
        {

            int[,] plateauAcarre = {
                    { 1   , 0   ,   0,   0   ,   5   ,   0   ,   2   ,   6   ,   9   },
                    { 0   , 5   ,   0,   1   ,   6   ,   0   ,   3   ,   4   ,   7   },
                    { 3   , 0   ,   9,   0   ,   4   ,   0   ,   1   ,   5   ,   8   },

                    { 0   , 1   ,   4,   4   ,   3   ,   6   ,   9   ,   0   ,   6   },
                    { 8   , 2   ,   0,   9   ,   1   ,   7   ,   7   ,   3   ,   4   },
                    { 0   , 3   ,   6,   5   ,   2   ,   8   ,   8   ,   1   ,   5   },

                    { 0   , 0   ,   0   ,   5   ,   0   ,   0   ,   6   ,   0   ,   2   },
                    { 0   , 0   ,   0   ,   6   ,   9   ,   0   ,   4   ,   7   ,   3   },
                    { 0   , 0   ,   0   ,   4   ,   7   ,   0   ,   5   ,   8   ,   1   }
                };

            int[] colonneA = Program.matrice_a_tableau(plateauAcarre, 1, false, true, 1);
            int[] plateau_colonneA = Program.valeur_possibles_carre(colonneA);
            Assert.AreEqual(plateau_colonneA[0], 2);
            Assert.AreEqual(plateau_colonneA[1], 4);
            Assert.AreEqual(plateau_colonneA[2], 6);
            Assert.AreEqual(plateau_colonneA[3], 7);
            Assert.AreEqual(plateau_colonneA[4], 8);

            int[] colonneB = Program.matrice_a_tableau(plateauAcarre, 5, false, true, 4);
            int[] plateau_colonneB = Program.valeur_possibles_carre(colonneB);
            Assert.AreEqual(plateau_colonneB.Length, 0);

            int[] colonne0 = Program.matrice_a_tableau(plateauAcarre, 7, false, true, 2);
            int[] plateau_colonne0 = Program.valeur_possibles_carre(colonne0);
            Assert.AreEqual(plateau_colonne0[8], 9);
            Assert.AreEqual(plateau_colonne0[0], 1);


        }


        [TestMethod] 
        public void IA4_reorganisation()
        {

            int[] ordre_forcage = { 1, 2, 3, 4, 5 };//, 4, 5, 6, 7, 8, 9 
            int[] stocke = { 1, 2, 3, 4, 5 };
            int[] result1 = { 1, 2, 3, 4, 5 };
            int[] result2 = { 1, 2, 3, 5, 4 };
            int[] result3 = { 1, 2, 4, 3, 5 };
            int[] result4 = { 1, 4, 3, 2, 5 };//15
            int[] result5 = { 5, 4, 2, 3, 1 };//120

            Program.compteur = 1;
            Program.IA4_reorganisation(ordre_forcage);
            for(int i =0; i < ordre_forcage.Length; i++)
            {
                Assert.AreEqual(ordre_forcage[i], result1[i]);
            }
            for (int i = 0; i < ordre_forcage.Length; i++)
            {
                ordre_forcage[i] = stocke[i];
            }


            Program.compteur = 2;
            Program.IA4_reorganisation(ordre_forcage);
            for (int i = 0; i < ordre_forcage.Length; i++)
            {
                Assert.AreEqual(ordre_forcage[i], result2[i]);
            }

            for(int i =0;i < ordre_forcage.Length; i++)
            {
                ordre_forcage[i] = stocke[i];
            }
           

            Program.compteur = 3;
            
            Program.IA4_reorganisation(ordre_forcage);
            for (int i = 0; i < ordre_forcage.Length; i++)
            {
                Assert.AreEqual(ordre_forcage[i], result3[i]);
            }
            for (int i = 0; i < ordre_forcage.Length; i++)
            {
                ordre_forcage[i] = stocke[i];
            }


            Program.compteur = 15;
            Program.IA4_reorganisation(ordre_forcage);
            for (int i = 0; i < ordre_forcage.Length; i++)
            {
                Assert.AreEqual(ordre_forcage[i], result4[i]);
            }
            for (int i = 0; i < ordre_forcage.Length; i++)
            {
                ordre_forcage[i] = stocke[i];
            }

            Program.compteur = 15;
            Program.IA4_reorganisation(ordre_forcage);
            for (int i = 0; i < ordre_forcage.Length; i++)
            {
                Assert.AreEqual(ordre_forcage[i], result4[i]);
            }


            for (int i = 0; i < ordre_forcage.Length; i++)
            {
                ordre_forcage[i] = stocke[i];
            }

            Program.compteur = 120;
            Program.IA4_reorganisation(ordre_forcage);
            for (int i = 0; i < ordre_forcage.Length; i++)
            {
                Assert.AreEqual(ordre_forcage[i], result5[i]);
            }

        }

        [TestMethod]
        public void IA3_ordre_forcage()
        {
            int[,] plateauTestA = {
                {0,0,8, 1,0,0, 0,0,0},
                {0,0,0, 2,6,0, 0,1,0},
                {0,0,0, 3,0,0, 0,2,0},

                {0,0,0, 4,9,0, 0,0,0},
                {0,0,0, 5,0,0, 0,0,0},
                {0,0,0, 6,0,0, 7,0,0},

                {0,0,0, 7,0,0, 0,0,0},
                {0,0,0, 8,0,0, 0,0,0},
                {0,0,0, 9,0,0, 0,0,0}
                };
            int[] result1 = Program.IA3_ordre_forcage(plateauTestA, 0);
            int[] result2 = Program.IA3_ordre_forcage(plateauTestA, 2);
            int[] result3 = Program.IA3_ordre_forcage(plateauTestA, 3);
            Assert.AreEqual(result1.Length, 9);
            Assert.AreEqual(result2.Length, 8);
            Assert.AreEqual(result3.Length, 0);

        }
        /*
                [TestMethod]
        public void IA3_forcage()
        {
            int[,] plateauTestA = {
                {0,0,8, 0,0,0, 0,0,0},
                {0,0,0, 5,6,0, 0,1,0},
                {0,0,0, 0,0,0, 0,2,0},

                {0,0,0, 0,9,0, 0,0,0},
                {0,0,0, 0,0,0, 0,0,0},
                {0,0,0, 0,0,0, 7,0,0},

                {0,0,0, 0,0,0, 0,0,0},
                {0,0,0, 0,0,0, 0,0,0},
                {0,0,0, 0,0,0, 0,0,0}
                };
            int[] ordre_forcage = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            //Program.IA2_reorganisation(ordre_forcage);
            Program.IA3_forcage(plateauTestA, 0, 8);
            Assert.AreEqual(plateauTestA[0, 0], ordre_forcage[0]);
            for (int i =1; i < plateauTestA.GetLength(0); i++)
            {
                Assert.AreEqual(plateauTestA[i, 0], 0);
            }
        }
        [TestMethod]
        public void TestMethod6()
        {
            int[,] plateauA =
            {
                { 1,2,3,4,5,6,7,8,9},
                { 1,2,4,5,6,7,8,9,9},
                { 3,4,5,6,7,8,9,1,9},
                { 4,3,6,7,8,9,1,2,9},
                { 5,6,7,8,9,1,2,3,9},
                { 6,7,8,9,1,2,3,4,9},
                { 7,8,9,  3,3,3,  4,5,9},
                { 8,9,1,  3,3,3,  5,6,9},
                { 9,1,2,  3,3,3,  6,7,9 }
            };
            int[,] plateauB =
{
                { 1,2,3,4,5,6,7,8,9},
                { 2,3,4,5,6,7,8,9,1},
                { 3,4,5,6,7,8,9,1,2},
                { 4,5,6,7,8,9,1,2,3},
                { 5,6,7,8,9,1,2,3,4},
                { 6,7,8,9,1,2,3,4,5},
                { 7,8,9,1,2,3,4,5,6},
                { 9,9,9,9,9,9,9,9,9},
                {9,1,2,3,4,5,6,7,9 }
            };
            int[,] plateauD = {
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
            int[,] plateauE = {
                    { 1   , 4   ,   5   ,   3   ,   5   ,   8   ,   2   ,   6   ,   9   },
                    { 2   , 7   ,   8   ,   1   ,   6   ,   9   ,   3   ,   4   ,   7   },
                    { 3   , 6   ,   9   ,   2   ,   4   ,   7   ,   1   ,   5   ,   8   },
                    { 7   , 1   ,   4   ,   8   ,   3   ,   5   ,   9   ,   2   ,   6   },
                    { 8   , 2   ,   5   ,   9   ,   1   ,   6   ,   7   ,   3   ,   4   },
                    { 9   , 3   ,   6   ,   7   ,   2   ,   4   ,   8   ,   1   ,   5   },
                    { 4   , 7   ,   1   ,   5   ,   8   ,   3   ,   6   ,   9   ,   2   },
                    { 5   , 8   ,   2   ,   6   ,   9   ,   1   ,   4   ,   7   ,   3   },
                    { 6   , 9   ,   3   ,   4   ,   7   ,   2   ,   5   ,   8   ,   1   }
                };
            int[,] plateauF = {
                    { 1   , 4   ,   7   ,   3   ,   5   ,   8   ,   2   ,   6   ,   9   },
                    { 2   , 5   ,   8   ,   1   ,   6   ,   9   ,   3   ,   4   ,   7   },
                    { 6   , 3   ,   9   ,   2   ,   4   ,   7   ,   1   ,   5   ,   8   },
                    { 7   , 1   ,   4   ,   8   ,   3   ,   5   ,   9   ,   2   ,   6   },
                    { 8   , 2   ,   5   ,   9   ,   1   ,   6   ,   7   ,   3   ,   4   },
                    { 9   , 3   ,   6   ,   7   ,   2   ,   4   ,   8   ,   1   ,   5   },
                    { 4   , 7   ,   1   ,   5   ,   8   ,   3   ,   6   ,   9   ,   2   },
                    { 5   , 8   ,   2   ,   6   ,   9   ,   1   ,   4   ,   7   ,   3   },
                    { 6   , 9   ,   3   ,   4   ,   7   ,   2   ,   5   ,   8   ,   1   }
                };

            Assert.IsFalse(Program.testplateau(plateauA));
            Assert.IsFalse(Program.testplateau(plateauB));


            Assert.IsTrue(Program.testplateau(plateauD));
            Assert.IsFalse(Program.testplateau(plateauE));
            Assert.IsFalse(Program.testplateau(plateauF));
        }
        [TestMethod]
        public void forcage()
        {
            int[,] plateau0 = {
                    {0,0,0,0,0,0,0,0,0},
                    {0,0,0,0,0,0,0,0,0},
                    {0,0,0,0,0,0,0,0,0},
                    {0,0,0,0,0,0,0,0,0},
                    {0,0,0,0,0,0,0,0,0},
                    {0,0,0,0,0,0,0,0,0},
                    {0,0,0,0,0,0,0,0,0},
                    {0,0,0,0,0,0,0,0,0},
                    {0,0,0,0,0,0,0,0,0}
                };
            for (int i = 0; i < 81; i++)
            {
                Program.forcage(plateau0);
                Program.affichage(plateau0);
            }
            Assert.IsTrue(Program.testplateau(plateau0));
        }
        [TestMethod]
        public void TestMethod1()
        {
            int[,] plateauA =
            {
                { 1,2,3,4,5,6,7,8,9},
                { 1,2,4,5,6,7,8,9,9},
                { 3,4,5,6,7,8,9,1,9},
                { 4,3,6,7,8,9,1,2,9},
                { 5,6,7,8,9,1,2,3,9},
                { 6,7,8,9,1,2,3,4,9},
                { 7,8,9,  3,3,3,  4,5,9},
                { 8,9,1,  3,3,3,  5,6,9},
                { 9,1,2,  3,3,3,  6,7,9 }
            };
            int[,] plateauB =
{
                { 1,2,3,4,5,6,7,8,9},
                { 2,3,4,5,6,7,8,9,1},
                { 3,4,5,6,7,8,9,1,2},
                { 4,5,6,7,8,9,1,2,3},
                { 5,6,7,8,9,1,2,3,4},
                { 6,7,8,9,1,2,3,4,5},
                { 7,8,9,1,2,3,4,5,6},
                { 9,9,9,9,9,9,9,9,9},
                {9,1,2,3,4,5,6,7,9 }
            };

            int[,] plateauD = {
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
            int[,] plateauE = {
                    { 1   , 4   ,   5   ,   3   ,   5   ,   8   ,   2   ,   6   ,   9   },
                    { 2   , 7   ,   8   ,   1   ,   6   ,   9   ,   3   ,   4   ,   7   },
                    { 3   , 6   ,   9   ,   2   ,   4   ,   7   ,   1   ,   5   ,   8   },
                    { 7   , 1   ,   4   ,   8   ,   3   ,   5   ,   9   ,   2   ,   6   },
                    { 8   , 2   ,   5   ,   9   ,   1   ,   6   ,   7   ,   3   ,   4   },
                    { 9   , 3   ,   6   ,   7   ,   2   ,   4   ,   8   ,   1   ,   5   },
                    { 4   , 7   ,   1   ,   5   ,   8   ,   3   ,   6   ,   9   ,   2   },
                    { 5   , 8   ,   2   ,   6   ,   9   ,   1   ,   4   ,   7   ,   3   },
                    { 6   , 9   ,   3   ,   4   ,   7   ,   2   ,   5   ,   8   ,   1   }
                };
            int[,] plateauF = {
                    { 1   , 4   ,   7   ,   3   ,   5   ,   8   ,   2   ,   6   ,   9   },
                    { 2   , 5   ,   8   ,   1   ,   6   ,   9   ,   3   ,   4   ,   7   },
                    { 6   , 3   ,   9   ,   2   ,   4   ,   7   ,   1   ,   5   ,   8   },
                    { 7   , 1   ,   4   ,   8   ,   3   ,   5   ,   9   ,   2   ,   6   },
                    { 8   , 2   ,   5   ,   9   ,   1   ,   6   ,   7   ,   3   ,   4   },
                    { 9   , 3   ,   6   ,   7   ,   2   ,   4   ,   8   ,   1   ,   5   },
                    { 4   , 7   ,   1   ,   5   ,   8   ,   3   ,   6   ,   9   ,   2   },
                    { 5   , 8   ,   2   ,   6   ,   9   ,   1   ,   4   ,   7   ,   3   },
                    { 6   , 9   ,   3   ,   4   ,   7   ,   2   ,   5   ,   8   ,   1   }
                };

            // public static bool test_ligne(int[,] plateau, int nombre, int ligne, int colonne)
            Assert.IsTrue(Program.test_ligne(plateauA, 2, 1, 1));
            Assert.IsTrue(Program.test_ligne(plateauA, 1, 1, 0));
            Assert.IsFalse(Program.test_ligne(plateauB, 9, 8, 0));
            Assert.IsTrue(Program.test_ligne(plateauA, 2, 1, 1));
            Assert.IsTrue(Program.test_ligne(plateauA, 3, 4, 7));


            // public static bool test_colonne(int[,] plateau, int nombre, int ligne, int colonne)
            Assert.IsFalse(Program.test_colonne(plateauA, 2, 1, 1));
            Assert.IsFalse(Program.test_colonne(plateauA, 3, 1, 2));
            Assert.IsFalse(Program.test_colonne(plateauA, 9, 0, 8));
            Assert.IsTrue(Program.test_colonne(plateauA, 2, 8, 2));
            Assert.IsFalse(Program.test_colonne(plateauA, 5, 8, 0));

            //public static bool test_carre(int[,] plateau, int nombre, int ligne, int colonne)
            Assert.IsFalse(Program.test_carre(plateauD, 2, 1, 1));
            Assert.IsFalse(Program.test_carre(plateauD, 2, 2, 2));
            Assert.IsTrue(Program.test_carre(plateauA, 2, 6, 3));
            Assert.IsTrue(Program.test_carre(plateauA, 2, 7, 4));
            Assert.IsTrue(Program.test_carre(plateauE, 5, 0, 2));
            Assert.IsTrue(Program.test_carre(plateauF, 3, 2, 1));
            Assert.IsTrue(Program.test_carre(plateauF, 6, 2, 0));

        }

        [TestMethod]
        public void TestMethod2()
        {
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

            Program.changement(plateau, 2, 2, 3, 3);
            Program.changement(plateau, 6, 4, 8, 5);
            Program.changement(plateau, 0, 0, 0, 1);

            Assert.AreEqual(plateau[4, 4], 1);//témoin
            Assert.AreEqual(plateau[2, 2], 8);
            Assert.AreEqual(plateau[3, 3], 9);
            Assert.AreEqual(plateau[6, 4], 2);
            Assert.AreEqual(plateau[0, 0], 4);
            Assert.AreEqual(plateau[0, 1], 1);
            
             expected output : 
            {
                    { A4A , A1A ,   7   ,   3   ,   5   ,   8   ,   2   ,   6   ,   9   },
                    { 2   , 5   ,   8   ,   1   ,   6   ,   9   ,   3   ,   4   ,   7   },
                    { 3   , 6   ,  A8A  ,   2   ,   4   ,   7   ,   1   ,   5   ,   8   }, 
                    { 7   , 1   ,   4   ,  A9A  ,   3   ,   5   ,   9   ,   2   ,   6   },
                    { 8   , 2   ,   5   ,   9   ,   1   ,   6   ,   7   ,   3   ,   4   },
                    { 9   , 3   ,   6   ,   7   ,   2   ,   4   ,   8   ,   1   ,   5   },
                    { 4   , 7   ,   1   ,   5   ,  A2A  ,   3   ,   6   ,   9   ,   2   },
                    { 5   , 8   ,   2   ,   6   ,   9   ,   1   ,   4   ,   7   ,   3   },
                    { 6   , 9   ,   3   ,   4   ,   7   ,  A8A  ,   5   ,   8   ,   1   }
              };

                    { 1   , 4   ,   7   ,   3   ,   5   ,   D9D ,   2   ,   6   ,   E8E },
                    { 2   , 5   ,  B9B  ,   1   ,   6   ,   C8C ,   3   ,   4   ,   7   },
                    { 3   , 6   ,  A8A  ,   2   ,   4   ,   7   ,   1   ,   5   ,   F9F }, 
                    { 7   , 1   ,   4   ,  a9a  ,   3   ,   5   ,  b8b  ,   2   ,   6   },
                    {e9e  , 2   ,   5   ,  b8b  ,   1   ,   6   ,   7   ,   3   ,   4   },
                    {d8d  , 3   ,   6   ,   7   ,   2   ,   4   ,   c9c ,   1   ,   5   },
                    { 4   , 7   ,   1   ,   5   ,   8   ,   3   ,   6   ,   9   ,   2   },
                    { 5   , 8   ,   2   ,   6   ,   9   ,   1   ,   4   ,   7   ,   3   },
                    { 6   , 9   ,   3   ,   4   ,   7   ,   2   ,   5   ,   8   ,   1   }
                    --> 6 degrés d'équilibrage par changement et 6 permutations totale
             

        }
        [TestMethod]
        public void TestMethod3()
        {
            int[,] plateau = {
                    { 1   , 4   ,   7   ,   3   ,   5   ,   8   ,   2   ,   6   ,   9   },
                    { 2   , 5   ,   8   ,   1   ,   6   ,   9   ,   3   ,   4   ,   7   },
                    { 3   , 6   ,   9   ,   2   ,   4   ,   7   ,   1   ,   5   ,   8   },
                    { 7   , 1   ,   4   ,   10   ,   3   ,   5   ,   9   ,   2   ,   6   },
                    { 8   , 2   ,   5   ,   9   ,   10   ,   6   ,   7   ,   3   ,   4   },
                    { 9   , 3   ,   6   ,   7   ,   2   ,   4   ,   8   ,   1   ,   5   },
                    { 10   , 7   ,   1   ,   5   ,   8   ,   3   ,   6   ,   9   ,   2   },
                    { 5   , 8   ,   2   ,   10   ,   9   ,   1   ,   4   ,   7   ,   3   },
                    { 6   , 9   ,   10   ,   10   ,   7   ,   2   ,   5   ,   8   ,   1   }
                };

            Assert.AreEqual(Program.findindexcarre(plateau, 10, 4, 4)[0], 3);
            Assert.AreEqual(Program.findindexcarre(plateau, 10, 4, 4)[1], 3);
            Assert.AreEqual(Program.findindexcarre(plateau, 10, 6, 0)[0], 8);
            Assert.AreEqual(Program.findindexcarre(plateau, 10, 6, 0)[1], 2);
            Assert.AreEqual(Program.findindexcarre(plateau, 10, 8, 3)[0], 7);
            Assert.AreEqual(Program.findindexcarre(plateau, 10, 8, 3)[1], 3);
            Assert.AreNotEqual(Program.findindexcarre(plateau, 10, 4, 4)[0], 6);
            Assert.AreNotEqual(Program.findindexcarre(plateau, 10, 4, 4)[1], 7);
        }
        [TestMethod]
        public void TestIA_1_degre()
        {
            int[,] plateau = {
            {0,0,9   ,0,2,1,  0,0,4 },
            {3,0,1   ,8,0,4  ,0,0,9},
            {0,5,4   ,0,6,9  ,0,0,0},

             {0,0,6  ,0,0,2  ,4,3,5},
             {1,0,2  ,0,0,5  ,9,7,6},
             {4,0,5  ,0,0,0  ,1,8,2},

             {6,0,8  ,0,0 ,7  ,5,0,3},
             {0,0,3  ,5,4 ,0  ,0,0,7},
             {5,0,7  ,0,0 ,0  ,2,0,0}
            };

            int ligne = 1;
            int colonne = 4;
            int[] ligne_tab = Program.valeur_possibles_ligne(Program.matrice_a_tableau(plateau, ligne, true));
            int[] colonne_tab = Program.valeur_possibles_colonne(Program.matrice_a_tableau(plateau, colonne, false));
            int[] carre_tab = Program.valeur_possibles_carre(Program.matrice_a_tableau(plateau, ligne, false, true, colonne));
            int[] possibilites_tab = Program.valeurs_intersection_tableau(ligne_tab, colonne_tab, carre_tab);
            Assert.AreEqual(ligne_tab[1], 5); //2 5 6 7
            Assert.AreEqual(colonne_tab[2], 5);//1 3 5 7 8 9
            Assert.AreEqual(carre_tab[1], 5);//3 5 7
            Assert.AreEqual(possibilites_tab[0], 5);
            Assert.AreEqual(possibilites_tab[1], 7);

            Program.IA_1_degre(plateau);
            Assert.AreEqual(plateau[ligne, colonne], 5);


        }
       
        */
    }
}
