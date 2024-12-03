using FluentAssertions;

List<int> list1;
List<int> list2;

CalculateTotalDistance("TestInput1").Should().Be(11);
CalculateTotalDistance("InputPart1").Should().Be(1506483);

CalculateSimilarity("TestInput1").Should().Be(31);
CalculateSimilarity("InputPart1").Should().Be(23126924);
Console.WriteLine("Great succes!");
return;

// Part1
int CalculateTotalDistance(string filename)
{
    ReadLists(filename);
    
    list1.Sort();
    list2.Sort();

    return list1.Select((t, i) => new[] { t, list2[i] })
        .Sum(numbers => numbers.Max() - numbers.Min());
}

void ReadLists(string filename)
{
    list1 = [];
    list2 = [];
    
    foreach (var line in System.IO.File.ReadLines(filename))
    {
        var numbers = line.Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
        list1.Add(numbers[0]);
        list2.Add(numbers[1]);
    }

}

// Part2
int CalculateSimilarity(string filename)
{
    ReadLists(filename);
    return (list1.Select(item => new { item, count = list2.Count(a => a.Equals(item)) }).Select(@t => @t.count * @t.item)).Sum();
}