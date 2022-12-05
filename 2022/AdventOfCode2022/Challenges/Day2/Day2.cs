namespace Challenges;

public class Day2
{
    private static readonly Dictionary<string, int> ScoreList = new()
    {
        { "A", Rock },
        { "B", Paper },
        { "C", Scissors },
        { "X", Rock },
        { "Y", Paper },
        { "Z", Scissors },
    };

    private const int Rock = 1;
    private const int Paper = 2;
    private const int Scissors = 3;

    public static int GetScoreFromInput()
    {
        List<(string, string)> InputReader()
        {
            var listToReturn = new List<(string, string)>();
            foreach (var line in File.ReadAllLines(@".\Day2\input.txt"))
            {
                var strings = line.Split(" ");
                listToReturn.Add((strings[0], strings[1]));
            }

            return listToReturn;
        }
        
        return GetScore(InputReader);
    }

    public static int GetScore(Func<List<(string, string)>> inputReader)
    {
        var total = 0;
        foreach (var inputValue in inputReader())
        {
            total += CalculateScore(inputValue);
        }

        return total;
    }

    private static int CalculateScore((string, string) inputValue)
    {
        var handElf = ScoreList[inputValue.Item1];
        var handPlayer = ScoreList[inputValue.Item2];
        
        if (handElf == Rock && handPlayer == Scissors ||
            handElf == Paper && handPlayer == Rock ||
            handElf == Scissors && handPlayer == Paper)
        {
            // lose
            return handPlayer;
        }   
        else if (handElf == Scissors && handPlayer == Rock ||
                  handElf == Paper && handPlayer == Scissors ||
                  handElf == Rock && handPlayer == Paper)
        {
            // win
            return handPlayer + 6;
        }
        else
        {
            //draw
            return handPlayer + 3;
        }
    }
}