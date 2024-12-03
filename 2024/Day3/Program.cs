using System.Text.RegularExpressions;
using FluentAssertions;

CalculateMultiplications("TestInput1").Should().Be(161);
CalculateMultiplications("InputPart1").Should().Be(157621318);
CalculateMultiplicationsWithConditionals("TestInput2").Should().Be(48);
CalculateMultiplicationsWithConditionals("InputPart1").Should().Be(79845780);
Console.WriteLine("Done!");
return;

// Part 1
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

// Part 2
int CalculateMultiplicationsWithConditionals(string filename)
{
    var input = System.IO.File.ReadAllText(filename);
    var matches = Regex.Matches(input, @"mul\((\d{1,3}),(\d{1,3})\)|do\(\)|don't\(\)");
    var total = 0;
    var enabled = true;
    foreach (Match match in matches)
    {
        switch (match.Value)
        {
            case "don't()":
                enabled = false;
                continue;
            case "do()":
                enabled = true;
                continue;
        }

        if (enabled)
        {
            total += int.Parse(match.Groups[1].Value) * int.Parse(match.Groups[2].Value);
        }
    }

    return total;
}

