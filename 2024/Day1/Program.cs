var total = 0;
var list1 = new List<int>();
var list2 = new List<int>();

foreach (var line in System.IO.File.ReadLines("InputPart1"))
{
    var numbers = line.Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
    list1.Add(numbers[0]);
    list2.Add(numbers[1]);
}

list1.Sort();
list2.Sort();

for (var i = 0; i < list1.Count; i++)
{
    var numbers = new[] { list1[i], list2[i] };
    total += numbers.Max() - numbers.Min();
}

Console.WriteLine(total);