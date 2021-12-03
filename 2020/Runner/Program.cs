using System;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using Challenges;
using Common;

namespace Runner
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var solver = new Day3Solver(new FileReader());
            Console.WriteLine(string.Join(", ", solver.GetSolutionStrings()));
            
            // Get all types from Challenges project
           // var types = Assembly.GetAssembly(typeof(Day1Solver)).GetTypes();
            // var type = typeof(IDaySolver);
            // var types = AppDomain.CurrentDomain.GetAssemblies()ð
            //     .SelectMany(s => s.GetTypes())
            //     .Where(p => type.IsAssignableFrom(p)).Except(new Type[]{typeof(IDaySolver)});
            //
            // foreach (var solverType in types)
            // {
            //     var instance = Activator.CreateInstance(solverType) as IDaySolver;
            //     Console.WriteLine($"Solution for {solverType.Name}: {instance.GetSolutionStrings()}");
            // }
            
            /// -----
            
            // Filter on Day{x}Solver
            // Call interface method GetSolutionString

            //var solver = new Day7Solver();
            // Console.WriteLine("Answer is " + solver.SolvePartTwo("Data\\Day7.txt"));

            // if (false)
            // {
            //     var toolName = "Advent of Code master solver 2000 2.0 FULL HD 16k";
            //     Console.WriteLine(new string('=', toolName.Length));
            //     Console.WriteLine(toolName);
            //     Console.WriteLine(new string('=', toolName.Length));
            //
            //     Console.WriteLine("Which day do you want to solve?");
            //
            //     RetryInput:
            //     var dayToSolve = Console.ReadLine();
            //     var regexMatch = Regex.Match(dayToSolve, "\\d+");
            //     if (!regexMatch.Success)
            //     {
            //         Console.WriteLine("Incorrect format, try again stupid!");
            //         goto RetryInput;
            //     }
            //     else
            //     {
            //         var selectedDay = Convert.ToInt32(regexMatch.ToString());
            //         if (selectedDay < 1 || selectedDay > 31)
            //         {
            //             Console.WriteLine("Do you know how months work!? Try again!");
            //             goto RetryInput;
            //         }
            //         else
            //         {
            //             var types = Assembly.GetAssembly(typeof(Day1Solver)).GetTypes();
            //             var requestedType = $"Day{selectedDay}Solver";
            //             if (!types.Select(a => a.Name).Contains(requestedType))
            //             {
            //                 Console.WriteLine("We don't have a solution for that one yet. Pick another day.");
            //                 goto RetryInput;
            //             }
            //
            //             var selectedType = types.Single(a => a.Name.Equals(requestedType));
            //             var instance = Activator.CreateInstance(selectedType) as IDaySolver;
            //
            //             //  Console.WriteLine();
            //             // instance.Solve()
            //         }
            //     }
            // }
        }
    }
}