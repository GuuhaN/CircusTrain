using System.Collections;
using System.Linq;
using System.Collections.Generic;
using AnimalsLib;
using AnimalsLib.Animals;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algoritmiek_UnitTest
{
    [TestClass]
    public class CircustreinTests
    {
        private readonly WagonAlgorithms wagonAlgorithms;
        public CircustreinTests()
        {
            wagonAlgorithms = new WagonAlgorithms();
        }

        #region Unit tests with the wagon size rule, ignores the others
        /// <summary>
        /// Checks if the wagon can fit 2 of the biggest animals, ignores the carnivore rule
        /// </summary>
        [TestMethod]
        public void CheckWagonSizeWith2BigAnimals()
        {
            Assert.IsTrue(wagonAlgorithms.CheckWagonSpace(
                new List<Animal>
                {
                    new Elephant(),
                    new Elephant(),
                }));
        }

        /// <summary>
        /// Checks if a wagon can fit all the animals by size, ignores the carnivore rule.
        /// </summary>
        [TestMethod]
        public void CheckWagonSizeWithAllAnimals()
        {
            Assert.IsFalse(wagonAlgorithms.CheckWagonSpace(
                new List<Animal>
                {
                    new T_Rex(),
                    new Elephant(),
                    new Tiger(),
                    new Camel(),
                    new Monkey()
                }));
        }

        /// <summary>
        /// Checks if a wagon can fit 10 of the smallest animals by size, ignores the carnivore rule
        /// </summary>
        [TestMethod]
        public void CheckWagonSizeWith10SmallAnimals()
        {
            Assert.IsTrue(wagonAlgorithms.CheckWagonSpace(
                new List<Animal>
                {
                    new Monkey(),
                    new Monkey(),
                    new Monkey(),
                    new Monkey(),
                    new Monkey(),
                    new Monkey(),
                    new Monkey(),
                    new Monkey(),
                    new Monkey(),
                    new Monkey(),
                }));
        }

        /// <summary>
        /// Checks if wagon can fit one of all animal sizes, ignores the carnivore rule
        /// </summary>
        [TestMethod]
        public void CheckWagonSizeWith1Big1Medium1SmallAnimals()
        {
            Assert.IsTrue(wagonAlgorithms.CheckWagonSpace(
                new List<Animal>
                {
                    new Elephant(),
                    new Camel(),
                    new Monkey(),
                }));
        }

        /// <summary>
        /// Final check if the wagonspace algorithm works by a series of assert tests
        /// </summary>
        [TestMethod]
        public void CheckIfEnoughWagonSpace()
        {
            // 1 big, 1 medium and 1 small sized animals 
            Assert.IsTrue(wagonAlgorithms.CheckWagonSpace(new List<Animal>
            {
                new Elephant(),
                new Tiger(),
                new Monkey()
            }));

            // 1 big and 2 medium sized animals
            Assert.IsFalse(wagonAlgorithms.CheckWagonSpace(new List<Animal>
            {
                new Elephant(),
                new Camel(),
                new Tiger()
            }));

            // 1 big, 1 medium and 2 small sized animals
            Assert.IsTrue(wagonAlgorithms.CheckWagonSpace(new List<Animal>
            {
                new T_Rex(),
                new Monkey(),
                new Monkey(),
                new Camel()
            }));

            // 2 big and 1 medium sized animals
            Assert.IsFalse(wagonAlgorithms.CheckWagonSpace(new List<Animal>
            {
                new Elephant(),
                new T_Rex(),
                new Tiger(),
            }));
        }
        #endregion

        #region Unit tests with the meateater rule, ignores the others.
        /// <summary>
        /// Checks if wagon can fit 1 big meateater, ignores the size of the wagon rule
        /// </summary>
        [TestMethod]
        public void CheckWagonWith1BigMeatEater()
        {
            Assert.IsTrue(wagonAlgorithms.IsWagonCompatibleWithMeatEaters(
                new List<Animal>
                {
                    new T_Rex()
                }));
        }

        /// <summary>
        /// Checks if 2 animals of the same size and are meat eaters are compatible in the same wagon, ignores the size of the wagon rule
        /// </summary>
        [TestMethod]
        public void CheckWagonWith2SameSizedMeatEaters()
        {
            Assert.IsFalse(wagonAlgorithms.IsWagonCompatibleWithMeatEaters(
                new List<Animal>
                {
                    new Tiger(),
                    new Tiger(),
                }));
        }

        /// <summary>
        /// Check if 1 big animal is compatible with 1 medium sized meat eater, ignores the size of a wagon rule
        /// </summary>
        public void CheckWagonWith1BigCarnivoreAnd1Meateater()
        {
            Assert.IsTrue(wagonAlgorithms.IsWagonCompatibleWithMeatEaters(
                new List<Animal>
                {
                    new Elephant(),
                    new Tiger()
                }));
        }

        /// <summary>
        /// Checks if 1 big meateater is compatible with 5 small carnivores, ignores the size of a wagon rule
        /// </summary>
        [TestMethod]
        public void CheckWagonWith1BigMeateaterAnd5SmallCarnivores()
        {
            Assert.IsFalse(wagonAlgorithms.IsWagonCompatibleWithMeatEaters(
                new List<Animal>
                {
                    new T_Rex(),
                    new Monkey(),
                    new Monkey(),
                    new Monkey(),
                    new Monkey(),
                    new Monkey(),
                }));
        }

        /// <summary>
        /// Check if 2 big meateaters are compatible with eachother, ignores the size of wagon rule
        /// </summary>
        [TestMethod]
        public void CheckWagonWith2BigMeateaters()
        {
            Assert.IsFalse(wagonAlgorithms.IsWagonCompatibleWithMeatEaters(new List<Animal>
            {
                new T_Rex(),
                new T_Rex(),
            }));
        }

        /// <summary>
        /// Final check if the algorithm of the meateaters/carnivore compatibility works through a series of assert tests
        /// </summary>
        [TestMethod]
        public void CheckMeateaterCarnivoreRule()
        {
            // 1 Big carnivore and 1 medium meateater
            Assert.IsTrue(wagonAlgorithms.IsWagonCompatibleWithMeatEaters(new List<Animal>
            {
                new Elephant(),
                new Tiger()
            }));

            // 1 Big and 1 small carnivore and 1 medium meateater
            Assert.IsFalse(wagonAlgorithms.IsWagonCompatibleWithMeatEaters(new List<Animal>
            {
                new Elephant(),
                new Monkey(),
                new Tiger()
            }));

            // 1 Big carnivore and 1 big meateater
            Assert.IsFalse(wagonAlgorithms.IsWagonCompatibleWithMeatEaters(new List<Animal>
            {
                new T_Rex(),
                new Elephant()
            }));

            // 1 medium and 1 small carnivore and 1 medium meateater
            Assert.IsFalse(wagonAlgorithms.IsWagonCompatibleWithMeatEaters(new List<Animal>
            {
                new Camel(),
                new Monkey(),
                new Tiger()
            }));
        }
        #endregion

        #region Unit/Integration test where all rules should be accepted. All checks on the amount of wagons
        /// <summary>
        /// Checks if 1 big and 5 small carnivores are compatible with each other in 1 wagon.
        /// </summary>
        [TestMethod]
        public void SortWagonsWith1BigAnd5SmallCarnivore()
        {
            Assert.AreEqual(1, wagonAlgorithms.SortAnimalsInWagons(new List<Animal>
            {
                new Elephant(),
                new Monkey(),
                new Monkey(),
                new Monkey(),
                new Monkey(),
                new Monkey(),
            }).Count);
        }

        /// <summary>
        /// Checks if 1 big meateater, 1 big carnivore and 3 medium ones can fit in 3 seperate wagons
        /// </summary>
        [TestMethod]
        public void SortWagonsWith1BigMeateater1BigCarnivoreAnd3MediumCarnivores()
        {
            Assert.AreEqual(3, wagonAlgorithms.SortAnimalsInWagons(new List<Animal>
            {
                new T_Rex(),
                new Elephant(),
                new Camel(),
                new Camel(),
                new Camel(),
            }).Count);
        }

        /// <summary>
        /// Check if 1 medium meateater is compatible and fit with 1 big carnivore, requires 1 wagon
        /// </summary>
        [TestMethod]
        public void SortWagonsWith1MediumMeateaterAnd1BigCarnivore()
        {
            Assert.AreEqual(1, wagonAlgorithms.SortAnimalsInWagons(
                new List<Animal>
                {
                    new Elephant(),
                    new Tiger()
                }
                ).Count);
        }

        /// <summary>
        /// Check if 4 big, 1 medium meateaters and 4 big, 3 small carnivores fit in 7 seperate wagons
        /// </summary>
        [TestMethod]
        public void SortWagonsWith4BigAnd1MediumMeateatersAnd4BigAnd3SmallCarnivores()
        {
            Assert.AreEqual(7, wagonAlgorithms.SortAnimalsInWagons(new List<Animal>
            {
                new T_Rex(),
                new T_Rex(),
                new T_Rex(),
                new T_Rex(),
                new Tiger(),
                new Elephant(),
                new Elephant(),
                new Elephant(),
                new Elephant(),
                new Monkey(),
                new Monkey(),
                new Monkey(),
            }).Count);
        }

        /// <summary>
        /// Check if 1 medium meateater and 8 medium, 3 small carnivores fit and are compatible in 4 wagons
        /// </summary>
        [TestMethod]
        public void SortWagonsWith1MediumMeateaterAnd8MediumAnd3SmallCarnivores()
        {
            Assert.AreEqual(4, wagonAlgorithms.SortAnimalsInWagons(
                new List<Animal>
                {
                    new Tiger(),
                    new Camel(),
                    new Camel(),
                    new Camel(),
                    new Camel(),
                    new Camel(),
                    new Camel(),
                    new Camel(),
                    new Camel(),
                    new Monkey(),
                    new Monkey(),
                    new Monkey(),
                }).Count);
        }

        /// <summary>
        /// Final check if the SortWagonAlgorithm works through a series assert tests
        /// </summary>
        [TestMethod]
        public void SortWagonsAlgorithm()
        {
            // 1 big meateater, 1 big carnivore, 1 medium meateater and 2 medium carnivores
            Assert.AreEqual(3, wagonAlgorithms.SortAnimalsInWagons(new List<Animal>
            {
                new Elephant(),
                new T_Rex(),
                new Camel(),
                new Camel(),
                new Tiger(),
            }).Count);

            // 2 big and 2 medium meateaters and 1 big and 1 carnivores
            Assert.AreEqual(5, wagonAlgorithms.SortAnimalsInWagons(new List<Animal>
            {
                new Elephant(),
                new T_Rex(),
                new T_Rex(),
                new Camel(),
                new Tiger(),
                new Tiger(),
            }).Count);

            // 1 big, 2 medium and 1 small carnivores
            Assert.AreEqual(1, wagonAlgorithms.SortAnimalsInWagons(new List<Animal>
            {
                new Elephant(),
                new Camel(),
                new Monkey()
            }).Count);

            // 3 big carnivores and 3 medium meateaters
            Assert.AreEqual(3, wagonAlgorithms.SortAnimalsInWagons(new List<Animal>
            {
                new Elephant(),
                new Tiger(),
                new Elephant(),
                new Tiger(),
                new Elephant(),
                new Tiger(),
            }).Count);
        }

        #endregion
    }
}
