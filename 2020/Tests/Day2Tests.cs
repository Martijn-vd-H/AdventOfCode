using System.Collections.Generic;
using System.Linq;
using Challenges;
using Common;
using Moq;
using NUnit.Framework;

namespace Tests
{
    public class Day2Tests
    {
        [Test]
        public void Day2ActualPartTwo()
        {
            var solver = new Day2Solver(new FileReader(), new Day2Solver.DataParser(), new Day2Solver.PasswordCheckerPartTwo());
            var result = solver.Solve(@"Data\Day2.txt");
            Assert.AreEqual(284, result);
        }

        
        [Test]
        public void PasswordCheckerPartTwoTest()
        {
            //Arrange
            var checker = new Day2Solver.PasswordCheckerPartTwo();
            var testData = new List<Day2Solver.PasswordSpecification>
            {
                new Day2Solver.PasswordSpecification()
                {
                    MinCount = 1,
                    MaxCount = 3,
                    Character = 'a',
                    Password = "abcde"
                },
                new Day2Solver.PasswordSpecification()
                {
                    MinCount = 1,
                    MaxCount = 3,
                    Character = 'b',
                    Password = "cdefg"
                },
                new Day2Solver.PasswordSpecification()
                {
                    MinCount = 2,
                    MaxCount = 9,
                    Character = 'c',
                    Password = "ccccccccc"
                }
            };

            //Act
            var validPasswordCount = checker.HowManyPasswordAreCorrect(testData);

            //Assert
            Assert.AreEqual(1, validPasswordCount);
        }
        
        [Test]
        public void Day2Actual()
        {
            var solver = new Day2Solver(new FileReader(), new Day2Solver.DataParser(), new Day2Solver.PasswordChecker());
            var result = solver.Solve(@"Data\Day2.txt");
            Assert.AreEqual(517, result);
        }
        
        [Test]
        public void PasswordCheckerTest()
        {
            //Arrange
            var checker = new Day2Solver.PasswordChecker();
            var testData = new List<Day2Solver.PasswordSpecification>
            {
                new Day2Solver.PasswordSpecification()
                {
                    MinCount = 1,
                    MaxCount = 3,
                    Character = 'a',
                    Password = "abcde"
                },
                new Day2Solver.PasswordSpecification()
                {
                    MinCount = 1,
                    MaxCount = 3,
                    Character = 'b',
                    Password = "cdefg"
                },
                new Day2Solver.PasswordSpecification()
                {
                    MinCount = 2,
                    MaxCount = 9,
                    Character = 'c',
                    Password = "ccccccccc"
                }
            };

            //Act
            var validPasswordCount = checker.HowManyPasswordAreCorrect(testData);

            //Assert
            Assert.AreEqual(2, validPasswordCount);
        }

        [Test]
        public void Day2SolverTest()
        {
            //Arrange
            var passwordCheckerMock = new Mock<Day2Solver.IPasswordChecker>();
            var dataParserMock = new Mock<Day2Solver.IDataParser>();
            var fileReaderMock = new Mock<IReader>();
            var daySolver = new Day2Solver(fileReaderMock.Object, dataParserMock.Object, passwordCheckerMock.Object);
            var testPath = "blaat";
            var parsedTestData = new List<string> {"test", "data" };
            var mockSpecs = new List<Day2Solver.PasswordSpecification>();
            fileReaderMock.Setup(a => a.ReadText(testPath)).Returns("test\ndata");
            var expectedValue = 1337;
            passwordCheckerMock.Setup(a=>a.HowManyPasswordAreCorrect(mockSpecs)).Returns(expectedValue);
            
            //Act
            var result = daySolver.Solve(testPath);

            //Assert
            fileReaderMock.Verify(a=>a.ReadText(testPath), Times.Once);
            dataParserMock.Verify(a=>a.Parse(parsedTestData), Times.Once);
            passwordCheckerMock.Verify(a=>a.HowManyPasswordAreCorrect(mockSpecs), Times.Once);
            Assert.AreEqual(expectedValue, result);
        }

        [Test]
        public void ParseDay2InputTest()
        {
            //Arrange
            var testData = "13-16 k: kkkkkgmkbvkkrskhd\n5-6 p: qpppvzp";
            var dataParser = new Day2Solver.DataParser();

            //Act
            var result = dataParser.Parse(testData.Split('\n').ToList());

            //Assert
            var expectedData = new List<Day2Solver.PasswordSpecification>
            {
                new Day2Solver.PasswordSpecification()
                {
                    MinCount = 13,
                    MaxCount = 16,
                    Character = 'k',
                    Password = "kkkkkgmkbvkkrskhd"
                },
                new Day2Solver.PasswordSpecification()
                {
                    MinCount = 5,
                    MaxCount = 6,
                    Character = 'p',
                    Password = "qpppvzp"
                },
            };

            Assert.That(result, Is.EquivalentTo(expectedData));
        }
    }
}