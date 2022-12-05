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
    public void RunDay1()
    {
        var scoreFromInput = Day2.GetScoreFromInput();
        Console.WriteLine(scoreFromInput);
        Assert.That(scoreFromInput, Is.LessThan(13637));
    }
    
    
}