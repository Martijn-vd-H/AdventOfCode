using System;
using System.Collections.Generic;
using Challenges;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class Day1Tests
    {
        [Test]
        public void Day1Test()
        {
            // Arrange
            var testData = new List<int>()
            {
                1721,
                979,
                366,
                299,
                675,
                1456,
            };
            var challengeSolver = new Day1Solver();

            // Act
            var result = challengeSolver.SolveDay1(testData);
            
            // Assert
            Assert.AreEqual(514579, result);
        }
        
        [Test]
        public void Day1Actual()
        {
            // Arrange
            var challengeSolver = new Day1Solver();
            var input = GetChallengeInputDay1();
            
            // Act
            var result = challengeSolver.SolveDay1(input);
            
            // Assert
            Assert.AreEqual(921504, result);
        }

        [Test]
        public void Day1PartTwoActual()
        {
            // Arrange
            var challengeSolver = new Day1Solver();
            var input = GetChallengeInputDay1();
            
            // Act
            var result = challengeSolver.SolveDay1B(input);
            
            // Assert
            Assert.AreEqual(195700142, result);
        }

        private List<int> GetChallengeInputDay1()
        {
            var data = System.IO.File.ReadAllLines(@"Data\Day1.txt");
            var list = new List<int>();
            foreach (var s in data)
            {
                list.Add(Convert.ToInt32(s));
            }

            return list;
        }
    }
}