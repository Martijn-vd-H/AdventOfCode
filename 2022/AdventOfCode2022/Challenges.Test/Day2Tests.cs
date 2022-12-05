namespace Challenges.Test;

public class Day2Tests
{
    [Test]
    public void GetScoreShouldReturnGameScore()
    {
        //Arrange
        var expected = 25;
        List<(string, string)> InputReader()
        {
            return new List<(string, string)>()
            {
                ("A", "Y"),
                ("B", "X"),
                ("C", "Z"),
                ("C", "X"),
                ("A", "Z"),
            };
        }
        
        //Act
        var result = Day2.GetScore(InputReader);
        
        //Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void GetScorePart2()
    {
        //Arrange
        var expected = 12;
        List<(string, string)> InputReader()
        {
            return new List<(string, string)>()
            {
                ("A", "Y"),
                ("B", "X"),
                ("C", "Z"),
            };
        }
        
        //Act
        var result = Day2.GetScorePart2(InputReader);
        
        //Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void RunDay1()
    {
        var scoreFromInput = Day2.GetScore(InputReader);
        Console.WriteLine(scoreFromInput);
        Assert.That(scoreFromInput, Is.EqualTo(13565));
    }
    
    [Test]
    public void RunDay1Part2()
    {
        var scoreFromInput = Day2.GetScorePart2(InputReader);
        Console.WriteLine(scoreFromInput);
        Assert.That(scoreFromInput, Is.LessThan(13637));
    }
    
    private List<(string, string)> InputReader()
    {
        var listToReturn = new List<(string, string)>();
        foreach (var line in File.ReadAllLines(@".\Day2\input.txt"))
        {
            var strings = line.Split(" ");
            listToReturn.Add((strings[0], strings[1]));
        }

        return listToReturn;
    }
}