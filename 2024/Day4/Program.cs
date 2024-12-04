// Alle regels lezen
using System.Net.Sockets;

var path = "TestInput1";
var lines = System.IO.File.ReadAllLines(path);

// Langste regel tellen
var length = lines.Max(line => line.Length);
var height = lines.Length;

// 2D array maken met max lengte regel en aantal regels
// var array = new char[length, height];
// for (int i = 0; i < height; i++)
// {
//     var line = lines[i];
//     for (int j = 0; j < length; j++)
//     {
//         array[i, j] = line[j];
//     }
// }

// Zoek naar X
var totalCount = 0;

for (int i = 0; i < height; i++)
{
    var line = lines[i];
    for (int j = 0; j < length; j++)
    {
        if (line[j] == 'X')
        {
            // Search right
            if (j + 4 < line.Length)
            {
                var sub = line.Substring(j, 4);
                if (sub.Equals("XMAS"))
                {
                    totalCount++;
                }
            }

            // Search left
            if (j - 4 >= 0)
            {
                var sub = line.Substring(j - 4, 4);
                if (sub.Equals("SAMX"))
                {
                    totalCount++;
                }
            }

            // Search up
            if (i > 3)
            {
                var upString = $"{lines[i][j]}{lines[i - 1][j]}{lines[i - 2][j]}{lines[i - 3][j]}";
                if (upString.Equals("XMAS"))
                {
                    totalCount++;
                }
            }

            // Search down
            if (i + 3 < lines.Length)
            {
                var upString = $"{lines[i][j]}{lines[i + 1][j]}{lines[i + 2][j]}{lines[i + 3][j]}";
                if (upString.Equals("XMAS"))
                {
                    totalCount++;
                }
            }

            // Search diagonal left up
            if (i > 3 && j - 4 >= 0)
            {
                var diagString = $"{lines[i][j]}{lines[i - 1][j - 1]}{lines[i - 2][j - 2]}{lines[i - 3][j - 3]}";
                if (diagString.Equals("XMAS"))
                {
                    totalCount++;
                }
            }

            // Search diagonal left up
            if (i > 3 && j - 4 >= 0)
            {
                var diagString = $"{lines[i][j]}{lines[i - 1][j - 1]}{lines[i - 2][j - 2]}{lines[i - 3][j - 3]}";
                if (diagString.Equals("XMAS"))
                {
                    totalCount++;
                }
            }
        }
    }
}

System.Console.WriteLine(totalCount);


// Bij het vinden van X kijk naar links, naar rechts, naar boven, naar onder
// Pak 4 letters, als dat kan (max length en 0 zijn grenzen). check of het XMAS is.

// Kijk diagonaal. Dus 1 naar boven, 1 naar links. Of 1 naar onder 1 naar rechts.