namespace Challenges.Test;

public class Day3Tests
{
    [Test]
    public void RuckSackTest()
    {
        // Arrange
        var input = new[]
        {
            "vJrwpWtwJgWrhcsFMMfFFhFp",
            "jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL",
            "PmmdzqPrVvPwwTWBwg",
            "wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn",
            "ttgJtRGJQctTZtZT",
            "CrZsJsPPZsGzwwsLwLmpwMDw",
        };

        // Act
        var result = Day3.Day3.CalculateItemScore(input);

        // Assert
        Assert.AreEqual(157, result);
    }

    [Test]
    public void GetAnswer()
    {
        // Arrange
        var input = File.ReadAllLines(@".\Day3\input.txt");
        
        // Act
        var result = Day3.Day3.CalculateItemScore(input);
        
        // Assert
        Assert.That(result, Is.EqualTo(7872));
    }
}