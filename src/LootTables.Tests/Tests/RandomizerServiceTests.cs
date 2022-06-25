using FluentAssertions;
using LootTables.Application.Services;
using System.Linq;
using Xunit;

namespace LootTables.Tests.Tests
{
    public class RandomizerServiceTests
    {

        [Theory]
        [InlineData(5d)]
        [InlineData(1d)]
        [InlineData(0.9d)]
        public void GetDoubleValue_RunFunction_ReturnsCorrectValue(double maxValue)
        {
            var service = new RandomizerService();

            var result = service.GetDoubleValue(maxValue);

            result.Should().BeLessThan(maxValue);
            result.Should().BeGreaterThanOrEqualTo(0);
        }

        [Theory]
        [InlineData(1d, 5d)]
        [InlineData(0, 1d)]
        [InlineData(0.1d, 0.9d)]
        public void GetDoubleValue_RunFunctionTwoParams_ReturnsCorrectValue(double minValue, double maxValue)
        {
            var service = new RandomizerService();

            var result = service.GetDoubleValue(minValue, maxValue);

            result.Should().BeLessThan(maxValue);
            result.Should().BeGreaterThanOrEqualTo(0);
        }

        [Theory]
        [InlineData(5)]
        [InlineData(1)]
        public void GetIntValue_RunFunction_ReturnsCorrectValue(int maxValue)
        {
            var service = new RandomizerService();

            var result = service.GetIntValue(maxValue);

            result.Should().BeLessThan(maxValue);
            result.Should().BeGreaterThanOrEqualTo(0);
        }

        [Theory]
        [InlineData(1, 5)]
        [InlineData(0, 1)]
        public void GetIntValue_RunFunctionTwoParams_ReturnsCorrectValue(int minValue, int maxValue)
        {
            var service = new RandomizerService();

            var result = service.GetIntValue(minValue, maxValue);

            result.Should().BeLessThan(maxValue);
            result.Should().BeGreaterThanOrEqualTo(0);
        }

        [Theory]
        [InlineData(1, 5)]
        [InlineData(4, 15)]
        public void RollDice_RunFunction_ReturnsCorrectValue(int diceCount, int sidesPerDice)
        {
            var service = new RandomizerService();

            var result = service.RollDice(diceCount, sidesPerDice);

            result.Should().HaveCount(diceCount + 1);
            result.First().Should().Be(result.Skip(1).Sum());
            result.Skip(1).Should().OnlyContain(x => x < sidesPerDice);
        }

    }
}
