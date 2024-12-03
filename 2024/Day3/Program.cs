using System.Text.RegularExpressions;
using FluentAssertions;

CalculateMultiplications("TestInput1").Should().Be(161);
CalculateMultiplications("InputPart1").Should().Be(157621318);

Console.WriteLine("Done!");
return;

int CalculateMultiplications(string filename)
{
    var input = System.IO.File.ReadAllText(filename);
    var matches = Regex.Matches(input, @"mul\((\d{1,3}),(\d{1,3})\)");
    var total = 0;
    foreach (Match match in matches)
    {
        total += int.Parse(match.Groups[1].Value) * int.Parse(match.Groups[2].Value);
    }

    return total;
}

