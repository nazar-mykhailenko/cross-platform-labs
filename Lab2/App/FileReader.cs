namespace App
{
    class FileReader : IFileReader
    {
        public string[] ReadLines(string path)
        {
            return File.ReadAllLines(path);
        }
    }
}