using System.Diagnostics;
using System.Reflection;
using AoC2025.Helpers;

// ============================================
// Advent of Code 2025 - Solution Runner
// ============================================

Console.WriteLine("🎄 Advent of Code 2025 🎄");
Console.WriteLine(new string('=', 40));
Console.WriteLine();

// Get all available solvers using reflection
var solvers = Assembly.GetExecutingAssembly()
    .GetTypes()
    .Where(t => typeof(ISolver).IsAssignableFrom(t) && !t.IsInterface && !t.IsAbstract)
    .Select(t => (ISolver)Activator.CreateInstance(t)!)
    .OrderBy(s => s.Day)
    .ToDictionary(s => s.Day, s => s);

if (args.Length > 0 && int.TryParse(args[0], out var dayArg))
{
    // Run specific day from command line argument
    RunDay(dayArg);
}
else
{
    // Interactive mode
    while (true)
    {
        Console.WriteLine("Available days: " + string.Join(", ", solvers.Keys));
        Console.WriteLine();
        Console.Write("Enter day number to run (or 'all' to run all, 'q' to quit): ");
        
        var input = Console.ReadLine()?.Trim().ToLower();
        
        if (string.IsNullOrEmpty(input) || input == "q")
            break;

        Console.WriteLine();

        if (input == "all")
        {
            foreach (var day in solvers.Keys.Order())
            {
                RunDay(day);
            }
        }
        else if (int.TryParse(input, out var day))
        {
            RunDay(day);
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a day number, 'all', or 'q'.");
        }

        Console.WriteLine();
    }
}

Console.WriteLine("Happy coding! 🌟");

void RunDay(int day)
{
    if (!solvers.TryGetValue(day, out var solver))
    {
        Console.WriteLine($"❌ Day {day} solver not found.");
        return;
    }

    Console.WriteLine($"📅 Day {day}");
    Console.WriteLine(new string('-', 30));

    try
    {
        var sw = Stopwatch.StartNew();
        var part1 = solver.SolvePart1();
        sw.Stop();
        Console.WriteLine($"  Part 1: {part1} ({sw.ElapsedMilliseconds}ms)");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"  Part 1: ❌ Error - {ex.Message}");
    }

    try
    {
        var sw = Stopwatch.StartNew();
        var part2 = solver.SolvePart2();
        sw.Stop();
        Console.WriteLine($"  Part 2: {part2} ({sw.ElapsedMilliseconds}ms)");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"  Part 2: ❌ Error - {ex.Message}");
    }

    Console.WriteLine();
}

