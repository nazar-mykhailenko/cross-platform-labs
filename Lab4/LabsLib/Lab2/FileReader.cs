namespace LabsLib.Lab2
{
    class FileReader : IFileReader
    {
        public string[] ReadLines(string path)
        {
            return File.ReadAllLines(path);
        }
    }
}