using Xunit;
using System.Collections.Generic;
using App;
using System.Configuration.Assemblies;
using Xunit.Abstractions;

namespace Tests
{
    public class ValidatorTests(ITestOutputHelper output)
    {
        [Fact]
        public void IsValidDay_ValidDay_ReturnsTrue()
        {
            // Arrange
            InputData inputData = new()
            {
                N = 30,
                K = 3,
                W = 7,
                S = 1,
                ForbiddenWeekdays = [6, 7],
                ForbiddenMonthDays = [4]
            };

            Validator validator = new(inputData);
            output.WriteLine("Input data: " + inputData);

            // Act
            bool isValid = validator.IsValidDay(1);
            output.WriteLine("Tested day: 1");
            output.WriteLine("Is valid: " + isValid);

            // Assert
            Assert.True(isValid);
        }

        [Fact]
        public void IsValidDay_ForbiddenWeekday_ReturnsFalse()
        {
            // Arrange
            InputData inputData = new()
            {
                N = 30,
                K = 3,
                W = 7,
                S = 1,
                ForbiddenWeekdays = [6, 7],
                ForbiddenMonthDays = []
            };

            Validator validator = new(inputData);
            output.WriteLine("Input data: " + inputData);

            // Act
            bool isValid = validator.IsValidDay(6);
            output.WriteLine("Tested day: 6");
            output.WriteLine("Is valid: " + isValid);

            // Assert
            Assert.False(isValid);
        }

        [Fact]
        public void IsValidDay_ForbiddenMonthDay_ReturnsFalse()
        {
            // Arrange
            InputData inputData = new()
            {
                N = 30,
                K = 3,
                W = 7,
                S = 1,
                ForbiddenWeekdays = [],
                ForbiddenMonthDays = [15]
            };

            Validator validator = new(inputData);
            output.WriteLine("Input data: " + inputData);

            // Act
            bool isValid = validator.IsValidDay(15);
            output.WriteLine("Tested day: 15");
            output.WriteLine("Is valid: " + isValid);

            // Assert
            Assert.False(isValid);
        }

        [Fact]
        public void Validator_InvalidInputData_ThrowsArgumentException()
        {
            // Arrange
            InputData inputData = new()
            {
                N = 0,
                K = 3,
                W = 7,
                S = 1,
                ForbiddenWeekdays = [],
                ForbiddenMonthDays = []
            };

            output.WriteLine("Input data: " + inputData);

            // Act & Assert
            Assert.Throws<System.ArgumentException>(() => new Validator(inputData));
        }
    }
}