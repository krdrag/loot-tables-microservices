using FluentAssertions;
using LootTables.Application.Models;
using LootTables.Application.Services;
using LootTables.Domain.Entities;
using LootTables.Domain.Exceptions;
using LootTables.Domain.Interfaces;
using LootTables.Tests.Data;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace LootTables.Tests.Tests
{
    public class LootServiceTests
    {
        private readonly Mock<IRandomizerService> _randomizerMock;
        private readonly Mock<ILootTableEntityRepository> _repositoryMock;

        public LootServiceTests()
        {
            _randomizerMock = new Mock<IRandomizerService>();
            _repositoryMock = new Mock<ILootTableEntityRepository>();
        }

        [Theory]
        [MemberData(nameof(LootServiceData.ValidLootTables), MemberType = typeof(LootServiceData))]
        public async void GetLoot_ValidLootTables_ReturnsExpectedLoot(MasterTableEntity? lootTable, (double, int) randRoll, List<ItemModel> expectedResult)
        {
            _randomizerMock.Setup(x => x.GetDoubleValue(It.IsAny<double>())).Returns(randRoll.Item1);
            _randomizerMock.Setup(x => x.GetIntValue(It.IsAny<int>(), It.IsAny<int>())).Returns(randRoll.Item2);

            _repositoryMock.Setup(x => x.GetLootTableAsync(It.IsAny<string>())).Returns(Task.FromResult(lootTable));

            var service = new LootService(_randomizerMock.Object, _repositoryMock.Object);

            var results = await service.GetLoot("TestTable");

            results.Should().BeEquivalentTo(expectedResult);
        }

        [Fact]
        public async void GetLoot_NoLootTable_ThrowsException()
        {
            _repositoryMock.Setup(x => x.GetLootTableAsync(It.IsAny<string>())).Returns(Task.FromResult<MasterTableEntity?>(null));

            var service = new LootService(_randomizerMock.Object, _repositoryMock.Object);

            var act = async () => await service.GetLoot("TestTable");

            await act.Should().ThrowAsync<MongoDBException>();
        }
    }
}
