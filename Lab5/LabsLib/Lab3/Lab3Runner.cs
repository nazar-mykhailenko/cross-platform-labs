namespace LabsLib.Lab3;

public class Lab3Runner
{
    public static string Run(string inputPath)
    {
        try
        {
            int[,] gridData = IOHelper.ReadGrid(inputPath);

            var grid = new Grid(gridData);
            var islandCounter = new IslandCounter(grid);

            int result = islandCounter.CountIslands();

            return result.ToString();
        }
        catch (IndexOutOfRangeException e)
        {
            return "The file is not in the correct format: " + e.Message;
        }
        catch (FileNotFoundException e)
        {
            return "The file was not found: " + e.Message;
        }
        catch (IOException e)
        {
            return "An error occurred while reading or writing to a file: " + e.Message;
        }
        catch (Exception e)
        {
            return "An error occurred: " + e.Message;
        }
    }
}
