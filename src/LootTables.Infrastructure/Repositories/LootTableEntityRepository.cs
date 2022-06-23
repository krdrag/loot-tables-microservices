using LootTables.Domain.Entities.LootTable;
using LootTables.Domain.Interfaces;
using LootTables.Infrastructure.Seed;

namespace LootTables.Infrastructure.Repositories
{
    public class LootTableEntityRepository : ILootTableEntityRepository
    {
        public LootTableEntity GetLootTable(string tableId)
        {
            if (tableId == "loot")
                return LootSeeds.AdvancedScenario();
            else if(tableId == "GachaLoot")
                return GachaSeeds.GetLoot();
            else
                return GachaSeeds.GetDraw10LootTable();
        }
    }
}
