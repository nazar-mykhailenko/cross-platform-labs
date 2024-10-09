using Xunit;
using System.Collections.Generic;
using App;
using Xunit.Abstractions;

namespace Tests
{
    public class OlympiadSchedulerTests(ITestOutputHelper output)
    {
        [Fact]
        public void CountValidWays_ExampleScenario_ReturnsCorrectCount()
        {
            //Arrange
            InputData inputData = new()
            {
                N = 31,
                K = 3,
                W = 7,
                S = 7,
                ForbiddenWeekdays = [7],
                ForbiddenMonthDays = [1, 9]
            };

            Validator validator = new(inputData);
            output.WriteLine("Input data: " + inputData);
            // Act
            int validWays = OlympiadScheduler.CountValidWays(inputData, validator);

            output.WriteLine("Valid ways: " + validWays);

            // Assert
            Assert.Equal(15, validWays);
        }

        [Fact]
        public void CountValidWays_BasicScenario_ReturnsCorrectCount()
        {
            // Arrange
            InputData inputData = new()
            {
                N = 10,
                K = 3,
                W = 7,
                S = 1,
                ForbiddenWeekdays = [6, 7],
                ForbiddenMonthDays = [4]
            };

            Validator validator = new(inputData);
            output.WriteLine("Input data: " + inputData);

            // Act
            int validWays = OlympiadScheduler.CountValidWays(inputData, validator);
            output.WriteLine("Valid ways: " + validWays);

            // Assert
            Assert.Equal(2, validWays);
        }

        [Fact]
        public void CountValidWays_NoValidDays_ReturnsZero()
        {
            // Arrange
            InputData inputData = new()
            {
                N = 5,
                K = 3,
                W = 7,
                S = 1,
                ForbiddenWeekdays = [1, 2, 3, 4, 5, 6, 7],
                ForbiddenMonthDays = []
            };

            Validator validator = new(inputData);
            output.WriteLine("Input data: " + inputData);

            // Act
            int validWays = OlympiadScheduler.CountValidWays(inputData, validator);
            output.WriteLine("Valid ways: " + validWays);

            // Assert
            Assert.Equal(0, validWays);
        }

        [Fact]
        public void CountValidWays_AllDaysValid_ReturnsCorrectCount()
        {
            // Arrange
            InputData inputData = new()
            {
                N = 10,
                K = 2,
                W = 7,
                S = 1,
                ForbiddenWeekdays = [],
                ForbiddenMonthDays = []
            };

            Validator validator = new(inputData);
            output.WriteLine("Input data: " + inputData);

            // Act
            int validWays = OlympiadScheduler.CountValidWays(inputData, validator);
            output.WriteLine("Valid ways: " + validWays);

            // Assert
            Assert.Equal(9, validWays);
        }
    }
}