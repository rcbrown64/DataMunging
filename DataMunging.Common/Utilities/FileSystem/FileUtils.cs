namespace DataMunging.Common.Utilities.FileSystem
{
    public static class FileUtils
    {
        public static string[] GetFileLines(string filePath)
        {
            return File.ReadAllLines(filePath);
        }
    }
}
