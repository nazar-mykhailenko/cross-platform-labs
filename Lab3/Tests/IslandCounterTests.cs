using App;
using Xunit;
using Xunit.Abstractions;

namespace Tests
{
    public class IslandCounterTests(ITestOutputHelper output)
    {
        [Fact]
        public void CountIslands_SingleIsland_Returns1()
        {
            int[,] gridData = {
            { 0, 0, 1 },
            { 0, 1, 1 },
            { 1, 1, 1 }
        };

            var grid = new Grid(gridData);
            output.WriteLine("Grid: \n" + grid.ToString());

            var counter = new IslandCounter(grid);

            int result = counter.CountIslands();
            output.WriteLine("Number of islands: " + result);

            Assert.Equal(1, result);
        }

        [Fact]
        public void CountIslands_MultipleIslands_ReturnsCorrectResult()
        {
            int[,] gridData = {
            { 0, 1, 0, 1 },
            { 1, 1, 0, 0 },
            { 0, 0, 1, 0 }
        };

            var grid = new Grid(gridData);
            output.WriteLine("Grid: \n" + grid.ToString());

            var counter = new IslandCounter(grid);

            int result = counter.CountIslands();
            output.WriteLine("Number of islands: " + result);

            Assert.Equal(3, result);
        }

        [Fact]
        public void CountIslands_NoIslands_Returns0()
        {
            int[,] gridData = {
            { 1, 1, 1 },
            { 1, 1, 1 },
            { 1, 1, 1 }
        };

            var grid = new Grid(gridData);
            output.WriteLine("Grid: \n" + grid.ToString());

            var counter = new IslandCounter(grid);

            int result = counter.CountIslands();
            output.WriteLine("Number of islands: " + result);

            Assert.Equal(0, result);
        }

        [Fact]
        public void CountIslands_ZeroMatrix_Returns1()
        {
            int[,] gridData = {
            { 0, 0, 0 },
            { 0, 0, 0 },
            { 0, 0, 0 }
        };

            var grid = new Grid(gridData);
            output.WriteLine("Grid: \n" + grid.ToString());

            var counter = new IslandCounter(grid);

            int result = counter.CountIslands();
            output.WriteLine("Number of islands: " + result);

            Assert.Equal(1, result);
        }

        [Fact]
        public void CountIslands_GridWithMultipleDisconnectedIslands_ReturnsCorrectResult()
        {
            int[,] gridData = {
            { 0, 1, 0, 0, 1 },
            { 1, 1, 1, 1, 1 },
            { 0, 1, 0, 1, 0 },
            { 0, 0, 0, 0, 0 }
        };

            var grid = new Grid(gridData);
            output.WriteLine("Grid: \n" + grid.ToString());

            var counter = new IslandCounter(grid);

            int result = counter.CountIslands();
            output.WriteLine("Number of islands: " + result);

            Assert.Equal(3, result);
        }
    }
}