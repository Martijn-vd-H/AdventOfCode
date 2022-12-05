namespace Challenges.Test;

public class Day2Tests
{
    [Test]
    public void GetScoreShouldReturnGameScore()
    {
        //Arrange
        var expected = 16;
        List<(string, string)> InputReader()
        {
            return new List<(string, string)>()
            {
                ("A", "Y"),
                ("B", "X"),
                ("C", "Z"),
                ("C", "X"),
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
        Assert.That(Day2.GetScoreFromInput(), Is.LessThan(13637));
    }
    
    
}