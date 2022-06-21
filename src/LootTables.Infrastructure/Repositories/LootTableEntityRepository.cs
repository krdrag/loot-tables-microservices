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

            var itemTable = new LootTableEntity();
            itemTable.IsGuaranteed = true;
            itemTable.DropCount = 5;

            itemTable.AddEntry(new ItemEntity
            {
                Name = "Item 1",
                Rarity = "Common",
                DropRate = 15
            });
            itemTable.AddEntry(new ItemEntity
            {
                Name = "Item 2",
                Rarity = "Rare",
                DropRate = 10
            });
            itemTable.AddEntry(new ItemEntity
            {
                Name = "Item 3",
                Rarity = "Epic",
                DropRate = 5
            });
            itemTable.AddEntry(new ItemEntity
            {
                Name = "Item 4",
                Rarity = "Legendary",
                DropRate = 1
            });
            itemTable.AddEntry(new ItemEntity
            {
                IsNull = true,
                DropRate = 10
            });

            var goldTable = new LootTableEntity();
            goldTable.IsGuaranteed = true;

            goldTable.AddEntry(new ItemEntity
            {
                Name = "Gold",
                IsGuaranteed = true,
                MinQuantity = 100,
                MaxQuantity = 200
            });

            lootTable.AddEntry(itemTable);
            lootTable.AddEntry(goldTable);

            return lootTable;
        }
    }
}
