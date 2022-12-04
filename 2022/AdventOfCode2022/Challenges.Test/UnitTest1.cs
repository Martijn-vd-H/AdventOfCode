namespace Challenges.Test;

public class Tests
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
        var result = Day1.GetScore(InputReader);
        
        //Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void RunDay1()
    {
        Assert.Fail(Day1.GetScoreFromInput().ToString());
    }
    
    
}