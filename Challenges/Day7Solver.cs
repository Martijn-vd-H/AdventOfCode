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
        private const string GoldBagName = "shiny gold";
        private List<BagSpec> _bagSpecs;

        public int Solve(string pathToInput)
        {
            ParseBagSpecifications(pathToInput);

            //Find shiny gold bags
            var count = GoldBagCount(_bagSpecs);
            return count;
        }

        private void ParseBagSpecifications(string pathToInput)
        {
            var input = System.IO.File.ReadAllLines(pathToInput);
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
        }

        public int SolvePartTwo(string pathToInput)
        {
            ParseBagSpecifications(pathToInput);
            var goldBag = _bagSpecs.First(a => a.ColorName.Equals(GoldBagName));
            var count = CountBagsInside(goldBag);
            return count;
        }

        private int CountBagsInside(BagSpec bagToLookIn)
        {
            var count = 0;
            foreach (var bag in bagToLookIn.Bags)
            {
                count += bag.Amount;
                
                count += CountBagsInside(_bagSpecs.First(a => a.ColorName.Equals(bag.ColorName))) *
                         (bag.Amount == 0 ? 1 : bag.Amount);
            }

            return count;
        }

        private int GoldBagCount(List<BagSpec> bagSpecs)
        {
            var count = 0;
            foreach (var bagSpec in bagSpecs)
            {
                if (CanHoldGoldBag(bagSpec))
                {
                    count++;
                }
            }

            return count;
        }

        private bool CanHoldGoldBag(BagSpec bagSpec)
        {
            if (bagSpec.Bags.Any(a => a.ColorName.Equals(GoldBagName)))
            {
                return true;
            }

            foreach (var bag in bagSpec.Bags)
            {
                var bagToSearch = _bagSpecs.FirstOrDefault(a => a.ColorName.Equals(bag.ColorName));
                if (bagToSearch != null)
                {
                    if (CanHoldGoldBag(bagToSearch))
                    {
                        return true;
                    }
                }
            }

            return false;
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