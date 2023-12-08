using System.Text.RegularExpressions;

public class Day1
{
    public void PartTwo(string path)
    {
        System.Console.WriteLine(CalculatePartTwo(File.ReadAllLines(path)));
    }

    public int CalculatePartTwo(string[] input)
    {
        var total = 0;
        var matchList = StringUtils.NumbersDictionary.Keys.Concat(StringUtils.NumbersDictionary.Values.Select(a=>a.ToString()));
        
        foreach(var line in input) 
        {
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
                if (matches.First() < first)
                {
                    first = matches.First();
                    firstMatch = item;
                }
                if (matches.Last() > last)
                {
                    last = matches.Last();
                    lastMatch = item;
                }

                firstMatch = StringUtils.NumbersDictionary.ContainsKey(firstMatch) ? StringUtils.NumbersDictionary[firstMatch].ToString() : firstMatch;
                lastMatch = StringUtils.NumbersDictionary.ContainsKey(lastMatch) ? StringUtils.NumbersDictionary[lastMatch].ToString() : lastMatch;

            }
            total += Convert.ToInt32(firstMatch + lastMatch);
        }

        return total;
    }


    public void PartOne(string path)
    {
        var totalPartOne = 0;
        foreach (var line in File.ReadAllLines(path))
        {
            totalPartOne += GetTotalForLine(line);
        }

        System.Console.WriteLine("Part 1: " + totalPartOne);
    }

    int GetTotalForLine(string line)
    {
        var digit = Regex.Match(line, @"\d").Value + Regex.Match(line, @"\d", RegexOptions.RightToLeft).Value;
        return Convert.ToInt32(digit);
    }
}