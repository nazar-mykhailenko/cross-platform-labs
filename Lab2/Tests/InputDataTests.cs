using Xunit;
using Moq;
using System.Collections.Generic;
using App;
using Xunit.Abstractions;

namespace Tests
{
    public class InputDataTests(ITestOutputHelper output)
    {
        [Fact]
        public void ReadFromFile_CorrectInput_ParsesSuccessfully()
        {
            // Arrange
            var mockFileReader = new Mock<IFileReader>();

            mockFileReader.Setup(fr => fr.ReadLines(It.IsAny<string>())).Returns(
            [
                "10 3",
                "7 2 1",
                "6 7",
                "1",
                "4"
            ]);

            // Act
            InputData inputData = InputData.ReadFromFile("fakepath.txt", mockFileReader.Object);
            output.WriteLine("Read input data: " + inputData);

            // Assert
            Assert.Equal(10, inputData.N);
            Assert.Equal(3, inputData.K);
            Assert.Equal(7, inputData.W);
            Assert.Equal(1, inputData.S);
            Assert.Contains(6, inputData.ForbiddenWeekdays);
            Assert.Contains(7, inputData.ForbiddenWeekdays);
            Assert.Contains(4, inputData.ForbiddenMonthDays);
        }
    }
}