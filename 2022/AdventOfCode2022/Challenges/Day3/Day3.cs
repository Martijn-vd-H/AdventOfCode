using Challenges.Helpers;

namespace Challenges.Day3;

public class Day3
{
    public static int CalculateItemScore(string[] input)
    {
        var total = 0;
        foreach (var s in input)
        {
            var splits = s.SplitStringInHalf();
            var duplicates = splits[0].Intersect(splits[1]);
            foreach (var duplicate in duplicates)
            {
                total += GetPriority(duplicate);
            }
        }

        return total;
    }

    public static int CalculateItemScorePart2(string[] input)
    {
        var total = 0;
        for (var i = 0; i < input.Length; i+=3)
        {
            total += GetPriority((input[i].Intersect(input[i + 1]).Intersect(input[i+2])).Single());
        }

        return total;
    }

    private static int GetPriority(char character)
    {
        var minus = character >= 'a' ? ('a' - 1) : ('A' - 27);
        return character - minus;
    }
}