// Alle regels lezen
var path = "InputPart1";
var lines = System.IO.File.ReadAllLines(path);

// Langste regel tellen
var length = lines.Max(line => line.Length);

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


for (int verticalIndex = 0; verticalIndex < lines.Length; verticalIndex++)
{
    var line = lines[verticalIndex];
    for (int horizontalIndex = 0; horizontalIndex < length; horizontalIndex++)
    {
        if (line[horizontalIndex] == 'X')
        {
            foreach (var offsetPlan in offsetPlans)
            {
                try
                {
                    string sub = "" + lines[verticalIndex + offsetPlan.one.y][horizontalIndex + offsetPlan.one.x] +
                    lines[verticalIndex + offsetPlan.two.y][horizontalIndex + offsetPlan.two.x] +
                    lines[verticalIndex + offsetPlan.three.y][horizontalIndex + offsetPlan.three.x] +
                    lines[verticalIndex + offsetPlan.four.y][horizontalIndex + offsetPlan.four.x];

                    if (sub.Equals("XMAS")) totalCount++;
                }
                catch (IndexOutOfRangeException)
                {
                    continue;
                }
            }
        }
    }
}

System.Console.WriteLine(totalCount);

record OffsetPlan(Offset one, Offset two, Offset three, Offset four);
record Offset(int x, int y);