using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Common;

namespace Challenges
{
    public class Day2Solver
    {
        private readonly IPasswordChecker _passwordChecker;
        private readonly IReader _reader;
        private readonly IDataParser _dataParser;

        public Day2Solver(IReader reader, IDataParser dataParser, IPasswordChecker checker)
        {
            _reader = reader;
            _dataParser = dataParser;
            _passwordChecker = checker;
        }

        public class PasswordChecker : IPasswordChecker
        {
            public int HowManyPasswordAreCorrect(List<PasswordSpecification> passwordSpecifications)
            {
                var correctPasswords = 0;
                foreach (var spec in passwordSpecifications)
                {
                    var count = spec.Password.Count(a=>a.Equals(spec.Character));
                    if(spec.MinCount <= count && count <= spec.MaxCount)
                    {
                        correctPasswords++;
                    }
                }

                return correctPasswords;
            }
        }

        public class DataParser : IDataParser
        {
            public IEnumerable<PasswordSpecification> Parse(List<string> testData)
            {
                foreach (var s in testData)
                {
                    //format \d+-\d+ [a-z]: [a-z]+
                    var specification = new PasswordSpecification();
                    var rangeMatch = Regex.Match(s, @"(\d+)-(\d+)");
                    specification.MinCount = Convert.ToInt32(rangeMatch.Groups[1].ToString());
                    specification.MaxCount = Convert.ToInt32(rangeMatch.Groups[2].ToString());
                    specification.Character = Regex.Match(s, @"[a-z]").ToString()[0];
                    specification.Password = Regex.Match(s, @":\s([a-z]+)").Groups[1].ToString();
                    yield return specification;
                }
            }
        }

        public class PasswordSpecification
        {
            public string Password { get; set; }
            public char Character { get; set; }
            public int MaxCount { get; set; }
            public int MinCount { get; set; }

            public override bool Equals(object obj)
            {
                var x = obj as PasswordSpecification;
                if (x == null)
                {
                    return false;
                }

                return MinCount == x.MinCount &&
                       MaxCount == x.MaxCount &&
                       Character == x.Character &&
                       Password == x.Password;
            }
        }

        public int Solve(string testPath)
        {
            var data = _reader.ReadText(testPath);
            var parsedData = _dataParser.Parse(data.Split('\n').ToList());
            return _passwordChecker.HowManyPasswordAreCorrect(parsedData.ToList());
        }
        
        
        public interface IDataParser
        {
            IEnumerable<PasswordSpecification> Parse(List<string> testData);
        }

        public interface IPasswordChecker
        {
            int HowManyPasswordAreCorrect(List<PasswordSpecification> passwordSpecifications);
        }

        public class PasswordCheckerPartTwo : IPasswordChecker
        {
            public int HowManyPasswordAreCorrect(List<PasswordSpecification> passwordSpecifications)
            {
                var correctPasswords = 0;
                foreach (var spec in passwordSpecifications)
                {
                    var aPositionChar = spec.Password[spec.MinCount - 1];
                    var bPositionChar = spec.Password[spec.MaxCount - 1];
                    if(aPositionChar.Equals(spec.Character) ^ bPositionChar.Equals(spec.Character))
                    {
                        correctPasswords++;
                    }
                }

                return correctPasswords;
            }
        }
    }
}