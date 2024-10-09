namespace App
{
    public interface IFileReader
    {
        string[] ReadLines(string path);
    }
}