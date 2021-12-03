using System.Collections.Generic;

namespace Common
{
    public interface IReader
    {
        string ReadText(string testData);

        IEnumerable<string> ReadLines(string path);
    }
}