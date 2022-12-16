namespace Challenges.Helpers;

public static class Utils
{
    public static string[] SplitStringInHalf(this string s)
    {
        var stringMid = (s.Length - 1) / 2;
        var firstHalf = s.Substring(0, stringMid + 1);
        var secondHalf = s.Substring(stringMid + 1, s.Length - stringMid - 1);
        return new[] { firstHalf, secondHalf };
    }
    
    public static IEnumerable<IEnumerable<T>> Chunk<T>(this IEnumerable<T> source, int chunksize)
    {
        while (source.Any())
        {
            yield return source.Take(chunksize);
            source = source.Skip(chunksize);
        }
    }
}