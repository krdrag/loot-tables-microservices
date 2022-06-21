using LootTables.Domain.Entities;
using LootTables.Domain.Entities.LootTable;
using LootTables.Domain.Interfaces;

namespace LootTables.Infrastructure.Repositories
{
    public class LootTableEntityRepository : ILootTableEntityRepository
    {
        public LootTableEntity GetLootTable(string tableId)
        {
            var lootTable = new LootTableEntity();
            lootTable.DropCount = 5;

            lootTable.AddEntry(new ItemEntity
            {
                Name = "Item 1",
                Rarity = "Common",
                DropRate = 15
            });
            lootTable.AddEntry(new ItemEntity
            {
                Name = "Item 2",
                Rarity = "Rare",
                DropRate = 10
            });
            lootTable.AddEntry(new ItemEntity
            {
                Name = "Item 3",
                Rarity = "Epic",
                DropRate = 5
            });
            lootTable.AddEntry(new ItemEntity
            {
                Name = "Item 4",
                Rarity = "Legendary",
                DropRate = 1
            });
            lootTable.AddEntry(new ItemEntity
            {
                IsNull = true,
                DropRate = 10
            });

            return lootTable;
        }
    }
}
