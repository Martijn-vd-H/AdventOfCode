namespace AoC2025.Helpers;

/// <summary>
/// Interface for Advent of Code day solvers.
/// </summary>
public interface ISolver
{
    /// <summary>
    /// The day number this solver is for.
    /// </summary>
    int Day { get; }

    /// <summary>
    /// Solves part 1 of the puzzle.
    /// </summary>
    /// <returns>The solution as a string</returns>
    string SolvePart1();

    /// <summary>
    /// Solves part 2 of the puzzle.
    /// </summary>
    /// <returns>The solution as a string</returns>
    string SolvePart2();
}

