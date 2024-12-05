using System.Reflection.PortableExecutable;
using FluentAssertions;

FindXmas(File.ReadAllLines("TestInput1")).Should().Be(18);
FindXmas(File.ReadAllLines("InputPart1")).Should().Be(2560);

// Part 1
int FindXmas(string[] strings)
{
    // Langste regel tellen
    var length = strings.Max(line => line.Length);

    var totalCount = 0;

    var offsetPlans = new List<OffsetPlan>
    {
        new(new Offset(0, 0), new Offset(1, 0), new Offset(2, 0), new Offset(3, 0)), // right
        new(new Offset(0, 0), new Offset(-1, 0), new Offset(-2, 0), new Offset(-3, 0)), // left
        new(new Offset(0, 0), new Offset(0, 1), new Offset(0, 2), new Offset(0, 3)), // up
        new(new Offset(0, 0), new Offset(0, -1), new Offset(0, -2), new Offset(0, -3)), // down
        new(new Offset(0, 0), new Offset(-1, 1), new Offset(-2, 2), new Offset(-3, 3)), // leftup
        new(new Offset(0, 0), new Offset(1, 1), new Offset(2, 2), new Offset(3, 3)), // rightup
        new(new Offset(0, 0), new Offset(-1, -1), new Offset(-2, -2), new Offset(-3, -3)), // leftdown
        new(new Offset(0, 0), new Offset(1, -1), new Offset(2, -2), new Offset(3, -3)), // rightdown
    };


    for (int verticalIndex = 0; verticalIndex < strings.Length; verticalIndex++)
    {
        var line = strings[verticalIndex];
        for (int horizontalIndex = 0; horizontalIndex < length; horizontalIndex++)
        {
            if (line[horizontalIndex] == 'X')
            {
                foreach (var offsetPlan in offsetPlans)
                {
                    try
                    {
                        var subString = "";
                        foreach (var offset in offsetPlan.offsets)
                        {
                            subString += strings[verticalIndex + offset.y][horizontalIndex + offset.x];
                        }
                        if (subString.Equals("XMAS")) totalCount++;
                    }
                    catch (IndexOutOfRangeException)
                    {
                        continue;
                    }
                }
            }
        }
    }

    return totalCount;
}

record OffsetPlan(params Offset[] offsets);
record Offset(int x, int y);