using FluentAssertions;

public class Day1Tests
{
    [Theory]
    [InlineData("eightwothree", 83)]
    [InlineData("7pqrstsixteen", 76)]
    [InlineData("4nineeightseven2", 42)]
    [InlineData("35zrgthreetwonesz", 31)]
    [InlineData("oneight", 18)]
    [InlineData("sixthree8sixjxjqsjgjgp", 66)]
    public void CalculateTest(string input, int output)
    {
        var day1 = new Day1();
        var result = day1.CalculatePartTwo(new[]{input});
        result.Should().Be(output);
    }
}