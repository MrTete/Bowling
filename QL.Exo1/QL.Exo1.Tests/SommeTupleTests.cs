using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace QL.Exo1.Tests
{
    [TestClass]
    public class SommeTupleTests
    {
        [TestMethod]
        public void TestEntreeNull()
        {
            List<Tuple<int, int>> array = null;
            JeuScore s = new JeuScore(array,10);
            bool isOk = false;
            try
            {
                s.GetSomme();
            }
            catch(ArgumentNullException e)
            {
                isOk = true;
            }
            if(!isOk)
                Assert.Fail();
        }

        /// <summary>
        /// Verifie si chaque tuple est positif ou nulle
        /// </summary>
        [TestMethod]
        public void TestAddNegative()
        {
            JeuScore jeuScore = new JeuScore(10);
            Assert.IsFalse(jeuScore.Add(new Tuple<int, int>(-1, 0)));
        }

        /// <summary>
        /// Verifie si chaque tuple est positif ou nulle
        /// </summary>
        [TestMethod]
        public void TestAddPositive()
        {
            JeuScore jeuScore = new JeuScore(10);
            Assert.IsTrue(jeuScore.Add(new Tuple<int, int>(1, 0)));
            Assert.IsTrue(jeuScore.Add(new Tuple<int, int>(0, 0)));
        }

        [TestMethod]
        public void TestNbMaxManche()
        {
            JeuScore jeuScore = new JeuScore(10);
            for(int i = 0; i < 10; ++i)
            {
                Assert.IsTrue(jeuScore.Add(new Tuple<int, int>(1, 2)));
            }
            Assert.IsFalse(jeuScore.Add(new Tuple<int, int>(1, 3)));
        }

        /// <summary>
        /// somme valeur dans un tuple inférieure ou égale à 10
        /// </summary>
        [TestMethod]
        public void TestSommeTuple()
        {
            JeuScore jeuScore = new JeuScore(10);
            Assert.IsTrue(jeuScore.Add(new Tuple<int, int>(10, 0)));
            Assert.IsFalse(jeuScore.Add(new Tuple<int, int>(11, 3)));
        }

        /// <summary>
        /// Check the GetSomme when a tuple equals 10 (item1 + item2 = 10)
        /// </summary>
        [TestMethod]
        public void TestGetSomme1()
        {
            JeuScore jeuScore = new JeuScore(10);
            jeuScore.Add(new Tuple<int, int>(2, 3));
            jeuScore.Add(new Tuple<int, int>(5, 5));
            jeuScore.Add(new Tuple<int, int>(1, 0));
            jeuScore.Add(new Tuple<int, int>(1, 0));
            jeuScore.Add(new Tuple<int, int>(1, 0));
            jeuScore.Add(new Tuple<int, int>(1, 0));
            jeuScore.Add(new Tuple<int, int>(1, 0));
            jeuScore.Add(new Tuple<int, int>(1, 0));
            jeuScore.Add(new Tuple<int, int>(1, 0));
            jeuScore.Add(new Tuple<int, int>(1, 0));
            Assert.AreEqual(24, jeuScore.GetSomme());//5+11+8

        }

        /// <summary>
        /// Check the GetSomme when a tuple equals 10 (item1 + item2 = 10, item1=0 XOR item2 = 0)
        /// </summary>
        [TestMethod]
        public void TestGetSomme2()
        {
            JeuScore jeuScore = new JeuScore(10);
            jeuScore.Add(new Tuple<int, int>(2, 3));
            jeuScore.Add(new Tuple<int, int>(10, 0));
            jeuScore.Add(new Tuple<int, int>(1, 0));
            jeuScore.Add(new Tuple<int, int>(1, 0));
            jeuScore.Add(new Tuple<int, int>(1, 0));
            jeuScore.Add(new Tuple<int, int>(1, 0));
            jeuScore.Add(new Tuple<int, int>(1, 0));
            jeuScore.Add(new Tuple<int, int>(1, 0));
            jeuScore.Add(new Tuple<int, int>(1, 0));
            jeuScore.Add(new Tuple<int, int>(1, 0));
            Assert.AreEqual(24, jeuScore.GetSomme());//5+11+8
        }

        /// <summary>
        /// Test enchainement stike et spare
        /// </summary>
        [TestMethod]
        public void TestGetSomme3()
        {
            JeuScore jeuScore = new JeuScore(10);
            jeuScore.Add(new Tuple<int, int>(2, 3));
            jeuScore.Add(new Tuple<int, int>(10, 0));
            jeuScore.Add(new Tuple<int, int>(10, 0));
            jeuScore.Add(new Tuple<int, int>(5, 5));
            jeuScore.Add(new Tuple<int, int>(7, 2));
            jeuScore.Add(new Tuple<int, int>(2, 3));
            jeuScore.Add(new Tuple<int, int>(10, 0));
            jeuScore.Add(new Tuple<int, int>(10, 0));
            jeuScore.Add(new Tuple<int, int>(4, 5));
            jeuScore.Add(new Tuple<int, int>(7, 2));
            Assert.AreEqual(5 + 25 + 20 + 17 + 9 + 5 + 24 + 19 + 9 + 9, jeuScore.GetSomme()); //5+25+20+17+9+5+24+19+9+9
        }

        [TestMethod]
        public void TestAddMancheEnd1() //Pas de coup supplémentaires
        {
            JeuScore jeuScore = new JeuScore(10);
            jeuScore.Add(new Tuple<int, int>(2, 5));
            jeuScore.Add(new Tuple<int, int>(3, 1));
            jeuScore.Add(new Tuple<int, int>(4, 3));
            jeuScore.Add(new Tuple<int, int>(5, 2));
            jeuScore.Add(new Tuple<int, int>(6, 2));
            jeuScore.Add(new Tuple<int, int>(7, 0));
            jeuScore.Add(new Tuple<int, int>(8, 1));
            jeuScore.Add(new Tuple<int, int>(9, 1));
            jeuScore.Add(new Tuple<int, int>(10, 0));
            jeuScore.Add(new Tuple<int, int>(6, 3));

            Assert.IsFalse(jeuScore.Add(new Tuple<int, int>(2, 3)));
        }

        [TestMethod]
        public void TestAddMancheEnd2()//spare => un coup supplémentaire
        {
            JeuScore jeuScore = new JeuScore(10);
            jeuScore.Add(new Tuple<int, int>(2, 5));
            jeuScore.Add(new Tuple<int, int>(3, 1));
            jeuScore.Add(new Tuple<int, int>(4, 3));
            jeuScore.Add(new Tuple<int, int>(5, 2));
            jeuScore.Add(new Tuple<int, int>(6, 2));
            jeuScore.Add(new Tuple<int, int>(7, 0));
            jeuScore.Add(new Tuple<int, int>(8, 1));
            jeuScore.Add(new Tuple<int, int>(9, 1));
            jeuScore.Add(new Tuple<int, int>(10, 0));
            jeuScore.Add(new Tuple<int, int>(5, 5));

            Assert.IsFalse(jeuScore.Add(new Tuple<int, int>(2, 3)));
            Assert.IsTrue(jeuScore.Add(new Tuple<int, int>(2, 0)));
        }

        [TestMethod]
        public void TestAddMancheEnd3()//strike => 2 coups supplémentaires
        {
            JeuScore jeuScore = new JeuScore(10);
            jeuScore.Add(new Tuple<int, int>(2, 5));
            jeuScore.Add(new Tuple<int, int>(3, 1));
            jeuScore.Add(new Tuple<int, int>(4, 3));
            jeuScore.Add(new Tuple<int, int>(5, 2));
            jeuScore.Add(new Tuple<int, int>(6, 2));
            jeuScore.Add(new Tuple<int, int>(7, 0));
            jeuScore.Add(new Tuple<int, int>(8, 1));
            jeuScore.Add(new Tuple<int, int>(9, 1));
            jeuScore.Add(new Tuple<int, int>(10, 0));
            jeuScore.Add(new Tuple<int, int>(10, 0));

            Assert.IsTrue(jeuScore.Add(new Tuple<int, int>(2, 3)));
        }

        [TestMethod]
        public void TestAddMancheEnd4()//test ajout d'un coup après le coup supplémentaire
        {
            JeuScore jeuScore = new JeuScore(10);
            jeuScore.Add(new Tuple<int, int>(2, 5));
            jeuScore.Add(new Tuple<int, int>(3, 1));
            jeuScore.Add(new Tuple<int, int>(4, 3));
            jeuScore.Add(new Tuple<int, int>(5, 2));
            jeuScore.Add(new Tuple<int, int>(6, 2));
            jeuScore.Add(new Tuple<int, int>(7, 0));
            jeuScore.Add(new Tuple<int, int>(8, 1));
            jeuScore.Add(new Tuple<int, int>(9, 1));
            jeuScore.Add(new Tuple<int, int>(10, 0));
            jeuScore.Add(new Tuple<int, int>(10, 0));

            Assert.IsTrue(jeuScore.Add(new Tuple<int, int>(2, 3)));

            Assert.IsFalse(jeuScore.Add(new Tuple<int, int>(1, 1)));
        }

        [TestMethod]
        public void Test300points()
        {
            JeuScore jeuScore = new JeuScore(10);
            Assert.IsTrue(jeuScore.Add(new Tuple<int, int>(10, 0)));
            Assert.IsTrue(jeuScore.Add(new Tuple<int, int>(10, 0)));
            Assert.IsTrue(jeuScore.Add(new Tuple<int, int>(10, 0)));
            Assert.IsTrue(jeuScore.Add(new Tuple<int, int>(10, 0)));
            Assert.IsTrue(jeuScore.Add(new Tuple<int, int>(10, 0)));
            Assert.IsTrue(jeuScore.Add(new Tuple<int, int>(10, 0)));
            Assert.IsTrue(jeuScore.Add(new Tuple<int, int>(10, 0)));
            Assert.IsTrue(jeuScore.Add(new Tuple<int, int>(10, 0)));
            Assert.IsTrue(jeuScore.Add(new Tuple<int, int>(10, 0)));
            Assert.IsTrue(jeuScore.Add(new Tuple<int, int>(10, 0)));
            Assert.IsTrue(jeuScore.Add(new Tuple<int, int>(10, 0)));
            Assert.IsTrue(jeuScore.Add(new Tuple<int, int>(10, 0)));

            Assert.AreEqual(300, jeuScore.GetSomme());
        }

    }
}
