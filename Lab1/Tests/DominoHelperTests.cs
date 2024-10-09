using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App;
using Xunit.Abstractions;

namespace Tests
{
    public class DominoHelperTests(ITestOutputHelper output)
    {
        [Theory]
        [InlineData(2ul, 12ul)]
        [InlineData(3ul, 30ul)]
        [InlineData(4ul, 60ul)]
        [InlineData(10000ul, 500150010000ul)]
        public void CountDots_ReturnsCorrectResult_WhenInputIsCorrect(ulong n, ulong expected)
        {
            var actual = DominoHelper.CountDots(n);
            output.WriteLine($"{nameof(CountDots_ReturnsCorrectResult_WhenInputIsCorrect)}; Input: {n}; Expected: {expected}; Actual: {actual}");
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CountDots_Returns1_WhenInputIsZero()
        {
            var actual = DominoHelper.CountDots(0);
            output.WriteLine($"{nameof(CountDots_Returns1_WhenInputIsZero)}; Input: 0; Expected: 1; Actual: {actual}");
            Assert.Equal(1ul, actual);
        }

        [Fact]
        public void CountDots_Returns3_WhenInputIsOne()
        {
            var actual = DominoHelper.CountDots(1);
            output.WriteLine($"{nameof(CountDots_Returns3_WhenInputIsOne)}; Input: 1; Expected: 3; Actual: {actual}");
            Assert.Equal(3ul, actual);
        }

        [Fact]
        public void CountDots_ThrowsArgumentException_WhenInputIsGreaterThan10000()
        {
            output.WriteLine($"{nameof(CountDots_ThrowsArgumentException_WhenInputIsGreaterThan10000)}; Input: 10001; Expected: ArgumentException");
            Assert.Throws<ArgumentException>(() => DominoHelper.CountDots(10001));
        }
    }
}
