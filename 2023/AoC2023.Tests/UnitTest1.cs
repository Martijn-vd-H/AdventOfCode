using FluentAssertions;

namespace AoC2023;

public class UnitTest1
{
    [Theory]
    [InlineData("eightwothree", "8wo3")]
    [InlineData("7pqrstsixteen", "7pqrst6teen")]
    [InlineData("4nineeightseven2", "49872")]
    public void ReplaceWrittenNumbersWithActualNumbersTest(string input, string output)
    {
        var result = input.ReplaceWrittenNumbersWithActualNumbers();
        result.Should().Be(output);
    }

    [Theory]
    [InlineData("eightwothree", "eerhtowthgie")]
    [InlineData("7pqrstsixteen", "neetxistsrqp7")]
    [InlineData("4nineeightseven2", "2nevesthgieenin4")]
    public void ReverseStringTest(string input, string output)
    {
        var result = input.ReverseString();
        result.Should().Be(output);
    }
}