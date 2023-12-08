public static class StringUtils
{
    public static Dictionary<string, int> NumbersDictionary = new Dictionary<string, int>
    {
        {"one", 1},
        {"two", 2},
        {"three", 3},
        {"four", 4},
        {"five", 5},
        {"six", 6},
        {"seven", 7},
        {"eight", 8},
        {"nine", 9},
    };

    public static string ReplaceWrittenNumbersWithActualNumbers(this string input)
    {
        var index = 1000; // Just a number that is higher than any input we might receive
        var firstNumberToReplace = "";
        var hasNumbersToReplace = false;
        foreach (var number in NumbersDictionary.Keys)
        {
            var currentIndex = input.IndexOf(number);

            if (currentIndex > -1 && currentIndex < index)
            {
                index = currentIndex;
                firstNumberToReplace = number;
                hasNumbersToReplace = true;
            }
        }
        if (hasNumbersToReplace)
        {
            var replacedString = NumbersDictionary[firstNumberToReplace].ToString();
            return ReplaceWrittenNumbersWithActualNumbers(input.Replace(firstNumberToReplace, replacedString));
        }
        else
        {
            return input;
        }

    }

    public static string ReverseString(this string s)
    {
        char[] charArray = s.ToCharArray();
        Array.Reverse(charArray);
        return new string(charArray);
    }

    public static IEnumerable<int> AllIndexesOf(this string str, string searchstring)
    {
        int minIndex = str.IndexOf(searchstring);
        while (minIndex != -1)
        {
            yield return minIndex;
            minIndex = str.IndexOf(searchstring, minIndex + searchstring.Length);
        }
    }

}

