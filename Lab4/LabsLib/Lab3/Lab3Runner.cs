namespace LabsLib.Lab3;

public class Lab3Runner
{
    public static void Run(string inputPath, string outputPath)
    {
        try
        {
            int[,] gridData = IOHelper.ReadGrid(inputPath);

            var grid = new Grid(gridData);
            var islandCounter = new IslandCounter(grid);

            int result = islandCounter.CountIslands();

            IOHelper.WriteResult(outputPath, result);
        }
        catch (IndexOutOfRangeException e)
        {
            Console.WriteLine("The file is not in the correct format: " + e.Message);
        }
        catch (FileNotFoundException e)
        {
            Console.WriteLine("The file was not found: " + e.Message);
        }
        catch (IOException e)
        {
            Console.WriteLine("An error occurred while reading or writing to a file: " + e.Message);
        }
        catch (Exception e)
        {
            Console.WriteLine("An error occurred: " + e.Message);
        }
    }
}
