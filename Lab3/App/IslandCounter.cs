namespace App;

public class IslandCounter(Grid grid)
{
    private readonly Grid grid = grid;
    private readonly int[] dx = { -1, 1, 0, 0 };
    private readonly int[] dy = { 0, 0, -1, 1 };

    public int CountIslands()
    {
        int count = 0;

        for (int i = 0; i < grid.Rows; i++)
        {
            for (int j = 0; j < grid.Cols; j++)
            {
                if (grid.IsUnvisitedZero(i, j))
                {
                    DFS(i, j);
                    count++;
                }
            }
        }

        return count;
    }

    private void DFS(int startX, int startY)
    {
        Stack<(int, int)> stack = new();
        stack.Push((startX, startY));

        while (stack.Count > 0)
        {
            var (x, y) = stack.Pop();

            if (!grid.IsUnvisitedZero(x, y))
                continue;

            grid.MarkVisited(x, y);

            for (int i = 0; i < 4; i++)
            {
                int newX = x + dx[i];
                int newY = y + dy[i];

                if (grid.IsValidPosition(newX, newY) && grid.IsUnvisitedZero(newX, newY))
                {
                    stack.Push((newX, newY));
                }
            }
        }
    }

}