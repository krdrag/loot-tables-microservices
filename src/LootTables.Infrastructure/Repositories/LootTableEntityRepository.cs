using LootTables.Domain.Entities;
using LootTables.Domain.Entities.LootTable;
using LootTables.Domain.Interfaces;
using LootTables.Infrastructure.Seed;

namespace LootTables.Infrastructure.Repositories
{
    public class LootTableEntityRepository : ILootTableEntityRepository
    {
        public LootTableEntity GetLootTable(string tableId)
        {
            return new LootSeeds().AdvancedScenario();
        }
    }
}
