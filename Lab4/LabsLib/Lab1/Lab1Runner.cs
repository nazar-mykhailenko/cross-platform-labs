namespace LabsLib.Lab1;

public class Lab1Runner
{
    public static void Run(string inputPath, string outputPath)
    {
        try
        {
            string input = File.ReadAllText(inputPath);
            ulong n = ulong.Parse(input);
            ulong result = DominoHelper.CountDots(n);
            File.WriteAllText(outputPath, result.ToString());
        }
        catch (IOException)
        {
            Console.WriteLine("Error when reading file!");
        }
        catch (FormatException)
        {
            Console.WriteLine("Error when parsing input!");
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
