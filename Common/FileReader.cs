namespace Common
{
    public class FileReader : IReader
    {
        public string ReadText(string testData)
        {
            return System.IO.File.ReadAllText(testData);
        }
    }
}