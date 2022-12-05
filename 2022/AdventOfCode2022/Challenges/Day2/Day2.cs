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

    public static int GetScorePart2(Func<List<(string, string)>> inputReader)
    {
        var total = 0;
        foreach (var inputValue in inputReader())
        {
            if (inputValue.Item2 == "Y")
            {
                total += ScoreList[inputValue.Item1] + 3;
            }
            else if (inputValue.Item2 == "X")
            {
                total += GetHand(ScoreList[inputValue.Item1], GameResult.Lose);
            }
            else
            {
                total += GetHand(ScoreList[inputValue.Item1], GameResult.Win) + 6;
            }
        }

        return total;
    }

    private enum GameResult
    {
        Win,
        Lose,
        Draw
    }

    private static int GetHand(int opponentHand, GameResult desiredGameResult)
    {
        if (opponentHand == Rock)
        {
            switch (desiredGameResult)
            {
                case GameResult.Win: return Paper;
                case GameResult.Lose: return Scissors;
                case GameResult.Draw: return Rock;
            }
        }
        else if (opponentHand == Paper)
        {
            switch (desiredGameResult)
            {
                case GameResult.Win: return Scissors;
                case GameResult.Lose: return Rock;
                case GameResult.Draw: return Paper;
            }
        }
        else
        {
            switch (desiredGameResult)
            {
                case GameResult.Win: return Rock;
                case GameResult.Lose: return Paper;
                case GameResult.Draw: return Scissors;
            }
        }

        throw new ArgumentException(opponentHand + desiredGameResult.ToString());
    }
}