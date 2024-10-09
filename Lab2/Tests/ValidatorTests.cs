using Xunit;
using System.Collections.Generic;
using App;
using System.Configuration.Assemblies;

namespace Tests
{
    public class ValidatorTests
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

            // Act
            bool isValid = validator.IsValidDay(1);

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

            // Act
            bool isValid = validator.IsValidDay(6);

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

            // Act
            bool isValid = validator.IsValidDay(15);

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

            // Act & Assert
            Assert.Throws<System.ArgumentException>(() => new Validator(inputData));
        }
    }
}