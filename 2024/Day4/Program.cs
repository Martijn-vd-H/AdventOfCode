using FluentAssertions;

FindXmas(File.ReadAllLines("TestInput1")).Should().Be(18);
FindXmas(File.ReadAllLines("InputPart1")).Should().Be(2560);

FindCrossMas(File.ReadAllLines("TestInput1")).Should().Be(9);
FindCrossMas(File.ReadAllLines("InputPart1")).Should().Be(1910);

return;

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


    for (var verticalIndex = 0; verticalIndex < strings.Length; verticalIndex++)
    {
        var line = strings[verticalIndex];
        for (var horizontalIndex = 0; horizontalIndex < length; horizontalIndex++)
        {
            if (line[horizontalIndex] != 'X') continue;
            foreach (var offsetPlan in offsetPlans)
            {
                try
                {
                    var subString = offsetPlan.offsets.Aggregate("", (current, offset) => current + strings[verticalIndex + offset.y][horizontalIndex + offset.x]);
                    if (subString.Equals("XMAS")) totalCount++;
                }
                catch (IndexOutOfRangeException)
                {
                }
            }
        }
    }

    return totalCount;
}

// Part 2
int FindCrossMas(string[] strings)
{
    // Langste regel tellen
    var length = strings.Max(line => line.Length);

    var totalCount = 0;

    var offsetPlans = new List<OffsetPlan>
    {
        new(new Offset(-1, -1), new Offset(0, 0), new Offset(1, 1)), // left up to right down
        new(new Offset(-1, 1), new Offset(0, 0), new Offset(1, -1)), // left down to right up
    };

    for (var verticalIndex = 0; verticalIndex < strings.Length; verticalIndex++)
    {
        var line = strings[verticalIndex];
        for (var horizontalIndex = 0; horizontalIndex < length; horizontalIndex++)
        {
            if (line[horizontalIndex] != 'A') continue;
            var foundHalfCross = false;
            foreach (var offsetPlan in offsetPlans)
            {
                try
                {
                    var subString = offsetPlan.offsets.Aggregate("", (current, offset) => current + strings[verticalIndex + offset.y][horizontalIndex + offset.x]);
                    if (subString.Equals("MAS") || subString.Equals("SAM"))
                    {
                        if (foundHalfCross)
                        {
                            totalCount++;
                        }

                        foundHalfCross = true;
                    }
                }
                catch (IndexOutOfRangeException)
                {
                }
            }
        }
    }

    return totalCount;
}

record OffsetPlan(params Offset[] offsets);

record Offset(int x, int y);