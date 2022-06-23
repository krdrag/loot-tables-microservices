using LootTables.Domain.Entities;
using LootTables.Domain.Entities.LootTable;

namespace LootTables.Infrastructure.Seed
{
    public static class LootSeeds
    {
        /// <summary>
        /// Base scenario with drops of various rarities and guaranteed gold drop.
        /// </summary>
        public static LootTableEntity BaseScenario()
        {
            var lootTable = new LootTableEntity
            {
                TableId = "BaseScenario"
            };

            var itemTable = new LootTableEntity
            {
                IsGuaranteed = true,
                DropCount = 5
            };

            itemTable.AddEntry(new ItemEntity
            {
                Name = "Rusty Sword",
                Rarity = "Common",
                DropRate = 15
            });
            itemTable.AddEntry(new ItemEntity
            {
                Name = "Iron Sword",
                Rarity = "Rare",
                DropRate = 10
            });
            itemTable.AddEntry(new ItemEntity
            {
                Name = "Magic Sword",
                Rarity = "Epic",
                DropRate = 5
            });
            itemTable.AddEntry(new ItemEntity
            {
                Name = "Excalibur",
                Rarity = "Legendary",
                DropRate = 1
            });
            itemTable.AddEntry(new ItemEntity
            {
                IsNull = true,
                DropRate = 10
            });

            var goldTable = new LootTableEntity
            {
                IsGuaranteed = true
            };

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

        /// <summary>
        /// Advanced scenario with drops of various rarities and guaranteed gold drop.
        /// </summary>
        public static LootTableEntity AdvancedScenario()
        {
            var lootTable = new LootTableEntity();
            lootTable.TableId = "AdvancedScenario";

            var rareTable = new LootTableEntity
            {
                IsGuaranteed = true,
                DropCount = 3
            };

            rareTable.AddEntry(new ItemEntity
            {
                Name = "Rusty sword",
                Rarity = "Common",
                DropRate = 5
            });
            rareTable.AddEntry(new ItemEntity
            {
                Name = "Old mace",
                Rarity = "Common",
                DropRate = 5
            });
            rareTable.AddEntry(new ItemEntity
            {
                Name = "Sword",
                Rarity = "Rare",
                DropRate = 2
            });
            rareTable.AddEntry(new ItemEntity
            {
                Name = "Staff",
                Rarity = "Common",
                DropRate = 2
            });

            var epicTable = new LootTableEntity
            {
                IsGuaranteed = true,
                DropCount = 3
            };

            epicTable.AddEntry(new ItemEntity
            {
                Name = "Magic Sword",
                Rarity = "Epic",
                DropRate = 5
            });
            epicTable.AddEntry(new ItemEntity
            {
                Name = "Magic Armor",
                Rarity = "Epic",
                DropRate = 5
            });
            epicTable.AddEntry(new ItemEntity
            {
                Name = "Cursed Dagger",
                Rarity = "Epic",
                DropRate = 4
            });
            epicTable.AddEntry(new ItemEntity
            {
                Name = "Arondight",
                Rarity = "Legendary",
                DropRate = .5
            });

            var goldTable = new LootTableEntity
            {
                IsGuaranteed = true
            };

            goldTable.AddEntry(new ItemEntity
            {
                Name = "Gold",
                IsGuaranteed = true,
                MinQuantity = 300,
                MaxQuantity = 600
            });

            lootTable.AddEntry(rareTable);
            lootTable.AddEntry(epicTable);
            lootTable.AddEntry(goldTable);

            return lootTable;
        }
    }
}
