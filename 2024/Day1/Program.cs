using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using FluentAssertions;

var result = Reader.ReadLists("TestInput1");
Calculators.CalculateTotalDistance(result.Item1, result.Item2).Should().Be(11);
Calculators.CalculateSimilarity(result.Item1, result.Item2).Should().Be(31);

result = Reader.ReadLists("InputPart1");
Calculators.CalculateTotalDistance(result.Item1, result.Item2).Should().Be(1506483);
Calculators.CalculateSimilarity(result.Item1, result.Item2).Should().Be(23126924);

Console.WriteLine("Great succes!");

BenchmarkRunner.Run<CalculatorBenchmarks>();

return;



public class CalculatorBenchmarks
{
    private (List<int>, List<int>) Data; 
        
    public CalculatorBenchmarks()
    {
        Data = Reader.ReadLists("InputPart1");
    }
    
    [Benchmark]
    public void Part1()
    {
        Calculators.CalculateSimilarity(Data.Item1, Data.Item2);
    }
}

internal class Calculators
{
    // Part1
    internal static int CalculateTotalDistance(List<int> list1, List<int> list2)
    {
        list1.Sort();
        list2.Sort();

        return list1.Select((t, i) => new[] { t, list2[i] })
            .Sum(numbers => numbers.Max() - numbers.Min());
    }
    
    // Part2
    internal static int CalculateSimilarity(List<int> list1, List<int> list2)
    {
        return list1
            .Select(item => new { item, count = list2.Count(a => a.Equals(item)) })
            .Select(@t => @t.count * @t.item)
            .Sum();
    }
}

internal class Reader
{
    internal static (List<int>, List<int>) ReadLists(string filename)
    {
        var list1 = new List<int>();
        var list2 = new List<int>();
        
        foreach (var line in File.ReadLines(filename))
        {
            var numbers = line.Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            list1.Add(numbers[0]);
            list2.Add(numbers[1]);
        }

        return (list1, list2);
    }
}