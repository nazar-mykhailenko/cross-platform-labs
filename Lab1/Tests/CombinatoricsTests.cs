using App;
using Xunit;
using Xunit.Abstractions;

namespace Tests
{
    public class CombinatoricsTests(ITestOutputHelper output)
    {
        [Theory]
        [InlineData(4ul, 30ul)]
        [InlineData(3ul, 12ul)]
        [InlineData(10001ul, 500150010000ul)]
        public void CombinationsWithRepetition_ReturnsCorrectResult_WhenInputIsCorrect(ulong n, ulong expected)
        {
            var actual = Combinatorics.CombinationsWithRepetition(n);
            output.WriteLine($"{nameof(CombinationsWithRepetition_ReturnsCorrectResult_WhenInputIsCorrect)}; Input: {n}; Expected: {expected}; Actual: {actual}");
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(0ul, 0ul)]
        [InlineData(1ul, 1ul)]
        public void CombinationsWithRepetition_ReturnsCorrectResult_WhenInputIsZeroOrOne(ulong n, ulong expected)
        {
            var actual = Combinatorics.CombinationsWithRepetition(n);
            output.WriteLine($"{nameof(CombinationsWithRepetition_ReturnsCorrectResult_WhenInputIsZeroOrOne)}; Input: {n}; Expected: {expected}; Actual: {actual}");
            Assert.Equal(expected, actual);
        }
    }
}