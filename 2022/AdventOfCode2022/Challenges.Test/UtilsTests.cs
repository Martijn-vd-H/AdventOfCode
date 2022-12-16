using Challenges.Helpers;

namespace Challenges.Test;

[TestFixture]
public class UtilsTests
{
    [Test]
    [TestCase("BlaatTest", "Blaat", "Test")]
    [TestCase("BlaaTest", "Blaa", "Test")]
    [TestCase("BlaatTest1", "Blaat", "Test1")]
    public void SplitStringInHalfTests(string fullString, string firstHalf, string secondHalf)
    {
        // Act
        var halfs = Utils.SplitStringInHalf(fullString);

        // Assert
        Assert.That(halfs.Length, Is.EqualTo(2));
        Assert.That(halfs[0], Is.EqualTo(firstHalf));
        Assert.That(halfs[1], Is.EqualTo(secondHalf));
    }
}