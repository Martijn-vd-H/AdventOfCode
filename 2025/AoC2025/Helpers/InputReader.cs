namespace AoC2025.Helpers;

/// <summary>
/// Helper class for reading Advent of Code puzzle input files.
/// </summary>
public static class InputReader
{
    /// <summary>
    /// Reads all lines from a puzzle input file.
    /// </summary>
    /// <param name="day">The day number (1-25)</param>
    /// <param name="filename">The input filename (default: "input.txt")</param>
    /// <returns>An array of all lines in the file</returns>
    public static string[] ReadAllLines(int day, string filename = "input.txt")
    {
        var path = GetInputPath(day, filename);
        return File.ReadAllLines(path);
    }

    /// <summary>
    /// Reads the entire puzzle input as a single string.
    /// </summary>
    /// <param name="day">The day number (1-25)</param>
    /// <param name="filename">The input filename (default: "input.txt")</param>
    /// <returns>The entire file content as a string</returns>
    public static string ReadAllText(int day, string filename = "input.txt")
    {
        var path = GetInputPath(day, filename);
        return File.ReadAllText(path);
    }

    /// <summary>
    /// Reads lines and parses them as integers.
    /// </summary>
    /// <param name="day">The day number (1-25)</param>
    /// <param name="filename">The input filename (default: "input.txt")</param>
    /// <returns>An array of integers</returns>
    public static int[] ReadAsIntegers(int day, string filename = "input.txt")
    {
        return ReadAllLines(day, filename)
            .Where(line => !string.IsNullOrWhiteSpace(line))
            .Select(int.Parse)
            .ToArray();
    }

    /// <summary>
    /// Reads lines and parses them as long integers.
    /// </summary>
    /// <param name="day">The day number (1-25)</param>
    /// <param name="filename">The input filename (default: "input.txt")</param>
    /// <returns>An array of long integers</returns>
    public static long[] ReadAsLongs(int day, string filename = "input.txt")
    {
        return ReadAllLines(day, filename)
            .Where(line => !string.IsNullOrWhiteSpace(line))
            .Select(long.Parse)
            .ToArray();
    }

    /// <summary>
    /// Reads the input as a 2D character grid.
    /// </summary>
    /// <param name="day">The day number (1-25)</param>
    /// <param name="filename">The input filename (default: "input.txt")</param>
    /// <returns>A 2D character array representing the grid</returns>
    public static char[,] ReadAsGrid(int day, string filename = "input.txt")
    {
        var lines = ReadAllLines(day, filename);
        var rows = lines.Length;
        var cols = lines.Max(l => l.Length);
        var grid = new char[rows, cols];

        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < lines[row].Length; col++)
            {
                grid[row, col] = lines[row][col];
            }
        }

        return grid;
    }

    /// <summary>
    /// Reads lines split by a custom delimiter.
    /// </summary>
    /// <param name="day">The day number (1-25)</param>
    /// <param name="delimiter">The delimiter to split each line by</param>
    /// <param name="filename">The input filename (default: "input.txt")</param>
    /// <returns>An array of string arrays (one per line)</returns>
    public static string[][] ReadLinesSplit(int day, string delimiter, string filename = "input.txt")
    {
        return ReadAllLines(day, filename)
            .Where(line => !string.IsNullOrWhiteSpace(line))
            .Select(line => line.Split(delimiter, StringSplitOptions.RemoveEmptyEntries))
            .ToArray();
    }

    /// <summary>
    /// Reads the input split by blank lines into groups.
    /// Useful for puzzles with paragraph-style input.
    /// </summary>
    /// <param name="day">The day number (1-25)</param>
    /// <param name="filename">The input filename (default: "input.txt")</param>
    /// <returns>A list of groups, where each group is a list of lines</returns>
    public static List<List<string>> ReadGroups(int day, string filename = "input.txt")
    {
        var lines = ReadAllLines(day, filename);
        var groups = new List<List<string>>();
        var currentGroup = new List<string>();

        foreach (var line in lines)
        {
            if (string.IsNullOrWhiteSpace(line))
            {
                if (currentGroup.Count > 0)
                {
                    groups.Add(currentGroup);
                    currentGroup = [];
                }
            }
            else
            {
                currentGroup.Add(line);
            }
        }

        if (currentGroup.Count > 0)
        {
            groups.Add(currentGroup);
        }

        return groups;
    }

    /// <summary>
    /// Gets the full path to an input file for a specific day.
    /// </summary>
    private static string GetInputPath(int day, string filename)
    {
        var path = Path.Combine("Days", $"Day{day:D2}", filename);
        
        if (!File.Exists(path))
        {
            throw new FileNotFoundException(
                $"Input file not found: {path}. " +
                $"Make sure to create the file at Days/Day{day:D2}/{filename}");
        }

        return path;
    }
}

