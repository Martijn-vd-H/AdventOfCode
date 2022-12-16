namespace Challenges.Test;

public class Day3Tests
{
    [Test]
    public void RuckSackTestPart1()
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
        Assert.That(result, Is.EqualTo(157));
    }

    [Test]
    public void GetAnswerPart1()
    {
        // Arrange
        var input = File.ReadAllLines(@".\Day3\input.txt");
        
        // Act
        var result = Day3.Day3.CalculateItemScore(input);
        
        // Assert
        Assert.That(result, Is.EqualTo(7872));
    }

    [Test]
    public void RuckSackTestPart2()
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
        var result = Day3.Day3.CalculateItemScorePart2(input);

        // Assert
        Assert.That(result, Is.EqualTo(70));
    }
    
    [Test]
    public void GetAnswerPart2()
    {
        // Arrange
        var input = File.ReadAllLines(@".\Day3\input.txt");
        
        // Act
        var result = Day3.Day3.CalculateItemScorePart2(input);
        
        // Assert
        Assert.That(result, Is.EqualTo(2497));
    }
}