using System.Collections.Generic;

namespace Common
{
    public class FileReader : IReader
    {
        public string ReadText(string testData)
        {
            return System.IO.File.ReadAllText(testData);
        }

        public IEnumerable<string> ReadLines(string path)
        {
            return System.IO.File.ReadLines(path);
        }
    }
}