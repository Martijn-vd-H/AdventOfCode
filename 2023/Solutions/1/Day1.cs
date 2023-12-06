using System.Numerics;
using System.Text.RegularExpressions;

public class Day1
{
    public void PartTwo(string path)
    {
        var total = 0;

        foreach (var line in File.ReadAllLines(path))
        {
            var numbersReplacedString = line.ReplaceWrittenNumbersWithActualNumbers();
            var currentTotal = GetTotalForLine(numbersReplacedString);
            total += currentTotal;
            if(currentTotal < 10 || currentTotal > 99){
                System.Console.WriteLine("break");
            }
            System.Console.WriteLine(line + " : " + numbersReplacedString + " : " + currentTotal);
        }

        System.Console.WriteLine(total);
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