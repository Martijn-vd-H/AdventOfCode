using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Common;

namespace Challenges
{
    /// <summary>
    /// Quick and Dirty
    /// </summary>
    public class Day7Solver : IDaySolver
    {
        private List<BagSpec> _bagSpecs;

        public int Solve(string pathToInput)
        {
            var input = System.IO.File.ReadAllLines(pathToInput);

            //Parse bag specifications
            _bagSpecs = new List<BagSpec>();
            foreach (var bagSpec in input)
            {
                //format: [Color] bags contain [amount] color bag(s) (,[amount] [color] bag(s).)*
                var mainBagRegexMatch = Regex.Match(bagSpec, @"(.+) bags contain");
                var color = mainBagRegexMatch.Groups[1].ToString();
                var mainBag = new BagSpec(color, 1);
                var subBagsRegex = new Regex(@"(\d+) ([a-z\s]+) bag");
                foreach (Match match in subBagsRegex.Matches(bagSpec))
                {
                    var amount = match.Groups[1];
                    var subColor = match.Groups[2];
                    mainBag.Bags.Add(new BagSpec(subColor.ToString(), Convert.ToInt32(amount.ToString())));
                }
                _bagSpecs.Add(mainBag);
            }
            
            //Find shiny gold bags
            var count = GoldBagCount(_bagSpecs, 1);
            return count;
        }

        private int GoldBagCount(List<BagSpec> bagSpecs, int multiplier)
        {
            var goldBag = "shiny gold";
            var count = 0;
            foreach (var bagSpec in bagSpecs)
            {
                if (bagSpec.ColorName.Equals(goldBag))
                {
                    count += (bagSpec.Amount * multiplier);
                }
                // var directHit = bagSpec.Bags.FirstOrDefault(a => a.ColorName.Equals(goldBag));
                // if (directHit != null)
                // {
                //     count += (directHit.Amount * multiplier);
                // }
                var bagsToLookFor = _bagSpecs.FirstOrDefault(a => a.ColorName.Equals(bagSpec.ColorName));
                if (bagsToLookFor != null)
                {
                    count += GoldBagCount(bagsToLookFor.Bags, bagSpec.Amount);
                }
            }

            return count;
        }

        private BagSpec ParseBagSpec(string text)
        {
            var regexMatch = Regex.Match(text, @"(\d+) (\w+) bag[s]?\.");
            var amount = Convert.ToInt32(regexMatch.Groups[1].ToString());
            var color = regexMatch.Groups[2].ToString();
            return new BagSpec(color, amount);
        }

        public class BagSpec
        {
            public string ColorName { get; set; }
            public int Amount { get; set; }
            public List<BagSpec> Bags { get; set; }

            public BagSpec(string colorName, int amount)
            {
                ColorName = colorName;
                Amount = amount;
                Bags = new List<BagSpec>();
            }
        }
    }
}