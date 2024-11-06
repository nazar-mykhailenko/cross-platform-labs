namespace LabsLib.Lab3;

public static class IOHelper
{
    public static int[,] ReadGrid(string filePath)
    {
        var input = File.ReadAllLines(filePath);
        var dimensions = input[0].Split(' ');
        var rows = int.Parse(dimensions[0]);
        var cols = int.Parse(dimensions[1]);

        int[,] grid = new int[rows, cols];

        for (int i = 0; i < rows; i++)
        {
            var row = input[i + 1].Split(' ');
            for (int j = 0; j < cols; j++)
            {
                grid[i, j] = int.Parse(row[j]);
            }
        }

        return grid;
    }

    public static void WriteResult(string filePath, int result)
    {
        File.WriteAllText(filePath, result.ToString());
    }
}