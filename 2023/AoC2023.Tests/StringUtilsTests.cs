using FluentAssertions;
using Xunit.Sdk;

namespace AoC2023;

public class StringUtilsTests
{
    [Theory]
    [InlineData("eightwothree", "8wo3")]
    [InlineData("7pqrstsixteen", "7pqrst6teen")]
    [InlineData("4nineeightseven2", "49872")]
    [InlineData("35zrgthreetwonesz", "35zrg32nesz")]
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

    [Fact]
    public void IndexTest()
    {
        var line = "7pqsixrstsixteen";
        var matchList = StringUtils.NumbersDictionary.Keys.Concat(StringUtils.NumbersDictionary.Values.Select(a => a.ToString()));
        var matches = matchList
        .Select(m => new { Indexes = line.AllIndexesOf(m).OrderBy(a=>a), Match = m })
        .Where(a => a.Indexes.Any());

        //matches.First(a=>a.Indexes)
        
    }


    [Fact]
    public void IndexTes2t()
    {
        var line = "7pqsixrstsixteen";
        var matchList = StringUtils.NumbersDictionary.Keys.Concat(StringUtils.NumbersDictionary.Values.Select(a => a.ToString()));

        var first = 1000;
        var firstMatch = "";
        var last = -1;
        var lastMatch = "";

        foreach (var item in matchList)
        {
            var matches = line.AllIndexesOf(item);
            if (!matches.Any())
            {
                continue;
            }
            if(matches.First() < first)
            {
                first = matches.First();
                firstMatch = item;
            }
            if (matches.Last() > last)
            {
                last = matches.Last();
                lastMatch = item;
            }
        }

        

    }

}