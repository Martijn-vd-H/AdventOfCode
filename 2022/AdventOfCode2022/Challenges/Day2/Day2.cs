namespace Challenges;

public class Day2
{
    private static readonly Dictionary<string, int> ScoreList = new()
    {
        { "A", 1 },
        { "B", 2 },
        { "C", 3 },
        { "X", 1 },
        { "Y", 2 },
        { "Z", 3 },
    };

    public static int GetScoreFromInput()
    {
        List<(string, string)> InputReader()
        {
            var listToReturn = new List<(string, string)>();
            foreach (var line in File.ReadAllLines(@".\Day1\input.txt"))
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
        var scoreElf = ScoreList[inputValue.Item1];
        var scorePlayer = ScoreList[inputValue.Item2];
        if (scorePlayer > scoreElf)
        {
            // win
            return scorePlayer + 6;
        }   
        else if (scorePlayer < scoreElf)
        {
            // lose
            return scorePlayer;
        }
        else
        {
            //draw
            return scorePlayer + 3;
        }
    }
    
}