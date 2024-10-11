using App;
using Xunit;
using Xunit.Abstractions;

namespace Tests;

public class GridTests(ITestOutputHelper output)
{
    [Theory]
    [InlineData(0, 0, true)]
    [InlineData(1, 1, true)]
    [InlineData(0, 1, false)]
    [InlineData(1, 0, false)]
    public void IsUnvisitedZero_GivenValidInput_ReturnsCorrectResult(int x, int y, bool expected)
    {
        int[,] gridData = {
        { 0, 1 },
        { 1, 0 }
    };

        var grid = new Grid(gridData);
        output.WriteLine("Grid: \n" + grid.ToString());
        output.WriteLine($"IsUnvisitedZero({x}, {y}): {grid.IsUnvisitedZero(x, y)}");

        Assert.Equal(expected, grid.IsUnvisitedZero(x, y));
    }

    [Fact]
    public void IsValidPosition_GivenValidInput_ReturnsCorrectResult()
    {
        int[,] gridData = {
        { 0, 1 },
        { 1, 0 }
    };

        var grid = new Grid(gridData);
        output.WriteLine("Grid: \n" + grid.ToString());
        output.WriteLine($"IsValidPosition(0, 0): {grid.IsValidPosition(0, 0)}");
        output.WriteLine($"IsValidPosition(-1, 0): {grid.IsValidPosition(-1, 0)}");
        output.WriteLine($"IsValidPosition(2, 1): {grid.IsValidPosition(2, 1)}");

        Assert.True(grid.IsValidPosition(0, 0));
        Assert.False(grid.IsValidPosition(-1, 0));
        Assert.False(grid.IsValidPosition(2, 1));
    }

    [Fact]
    public void MarkVisited_GivenValidInput_ReturnsCorrectResult()
    {
        int[,] gridData = {
        { 0, 1 },
        { 1, 0 }
    };

        var grid = new Grid(gridData);
        output.WriteLine("Grid: \n" + grid.ToString());

        Assert.True(grid.IsUnvisitedZero(0, 0));
        output.WriteLine($"IsUnvisitedZero(0, 0): {grid.IsUnvisitedZero(0, 0)}");
        grid.MarkVisited(0, 0);
        output.WriteLine("Marking (0, 0) as visited");
        Assert.False(grid.IsUnvisitedZero(0, 0));
        output.WriteLine($"IsUnvisitedZero(0, 0): {grid.IsUnvisitedZero(0, 0)}");
    }
}