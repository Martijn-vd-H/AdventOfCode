using System.Collections.Generic;
using System.Linq;
using Challenges;
using Common;
using Moq;
using NUnit.Framework;

namespace Tests
{
    public class Day3Tests
    {
        private List<string> _forest = new List<string>
        {
            "..##.......",
            "#...#...#..",
            ".#....#..#.",
            "..#.#...#.#",
            ".#...##..#.",
            "..#.##.....",
            ".#.#.#....#",
            ".#........#",
            "#.##...#...",
            "#...##....#",
            ".#..#...#.#"
        };

        [Test]
        public void SolveTest()
        {
            //Arrange
            var fileReaderMock = new Mock<IReader>();
            fileReaderMock.Setup(a => a.ReadLines(It.IsAny<string>())).Returns(_forest);
            var solver = new Day3Solver(fileReaderMock.Object);

            //Act
            var result= solver.GetSolutionStrings();

            //Assert
            Assert.AreEqual("7, 336", string.Join(", ", result));
        }
        //
        // [Test]
        // public void SolvePartTwoTest()
        // {
        //     //Arrange
        //     var fileReaderMock = new Mock<IReader>();
        //     fileReaderMock.Setup(a => a.ReadLines(It.IsAny<string>())).Returns(_forest);
        //     var solver = new Day3Solver(fileReaderMock.Object);
        //
        //     //Act
        //     var result= solver.Solve("blaat", 3, 1);
        //
        //     //Assert
        //     Assert.AreEqual(7, result);
        // }
    }
}