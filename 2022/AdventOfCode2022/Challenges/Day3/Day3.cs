namespace Challenges.Day3;

public class Day3
{
    public static int CalculateItemScore(string[] input)
    {
        var total = 0;
        foreach (var s in input)
        {
            // TODO separate into utils class get half of string
            var stringMid = (s.Length - 1) / 2;
            var compartment1 = s.Substring(0, stringMid + 1);
            var compartment2 = s.Substring(stringMid + 1, s.Length - stringMid - 1);
            var duplicates = compartment1.Intersect(compartment2);
            foreach (var duplicate in duplicates)
            {
                total += GetPriority(duplicate);
            }
        }

        return total;
    }

    private static int GetPriority(char character)
    {
        var minus = character >= 'a' ? ('a' - 1) : ('A' - 27);
        return character - minus;
    }
}