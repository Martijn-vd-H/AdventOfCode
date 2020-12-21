using System;
using System.Collections.Generic;
using System.Linq;
using Common;

namespace Challenges
{
    public class Day3Solver : IDaySolver
    {
        private readonly IReader _reader;

        public Day3Solver(IReader reader)
        {
            _reader = reader;
        }

        private int Solve(string filePath, int right, int down)
        {
            var forest = _reader.ReadLines(filePath).ToList();
            return CountTrees(right, down, forest);
        }

        private static int CountTrees(int right, int down, List<string> forest)
        {
            var treeCount = 0;
            var x = 0;
            for (int y = down; y < forest.Count; y += down)
            {
                x += right;
                var row = forest[y];
                if (x >= row.Length)
                {
                    x -= row.Length;
                }

                var value = row[x];
                if (value.Equals('#'))
                {
                    treeCount++;
                }
            }

            return treeCount;
        }

        private Int64 SolvePartTwo(string filePath, List<(int right, int down)> directions)
        {
            var forest = _reader.ReadLines(filePath).ToList();

            Int64 result = 1;
            foreach (var direction in directions)
            {
                var treeCount = CountTrees(direction.right, direction.down, forest);
                result *= treeCount;
            }

            return result;
        }

        public List<string> GetSolutionStrings()
        {
            var partTwoDirections = new List<(int, int)>
            {
                (1, 1),
                (3, 1),
                (5, 1),
                (7, 1),
                (1, 2),
            };


            return new List<string>()
            {
                Solve(@"Data\Day3.txt", 3, 1).ToString(),
                SolvePartTwo(@"Data\Day3.txt", partTwoDirections).ToString()
            };
        }
    }
}