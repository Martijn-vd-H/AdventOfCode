using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Common;

namespace Challenges
{
    /// <summary>
    /// Quick and Dirty
    /// </summary>
    public class Day7Solver
    {
        public int Solve(string pathToInput)
        {
            var input = System.IO.File.ReadAllLines("Data\\Day7TestData.txt");
            
            foreach (var bagSpec in input)
            {
                //format: [Color] bags contain [amount] color bag(s) (,[amount] [color] bag(s).)*
                var regexMatch = Regex.Match(bagSpec, @"(\w+) bags contain (\d+) (\w+)(, (\d+) (\w+) bags)*\.");
            }
            
            return 0;
        }

        public class BagSpec
        {
            public string ColorName { get; set; }
            public int Amount { get; set; }
            public List<BagSpec> Bags { get; set; }

            public BagSpec(string colorName, int amount)
            {
                
            }
        }
    }
}