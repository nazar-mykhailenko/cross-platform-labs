namespace App;

public class Grid
{
    private readonly int[,] grid;
    private readonly bool[,] visited;
    public int Rows { get; }
    public int Cols { get; }

    public Grid(int[,] initialGrid)
    {
        grid = initialGrid;
        Rows = grid.GetLength(0);
        Cols = grid.GetLength(1);
        visited = new bool[Rows, Cols];
    }

    public bool IsUnvisitedZero(int x, int y)
    {
        return grid[x, y] == 0 && !visited[x, y];
    }

    public void MarkVisited(int x, int y)
    {
        visited[x, y] = true;
    }

    public bool IsValidPosition(int x, int y)
    {
        return x >= 0 && x < Rows && y >= 0 && y < Cols;
    }

    override public string ToString()
    {
        string result = "";
        for (int i = 0; i < Rows; i++)
        {
            for (int j = 0; j < Cols; j++)
            {
                result += grid[i, j] + " ";
            }
            result += "\n";
        }

        return result;
    }
}