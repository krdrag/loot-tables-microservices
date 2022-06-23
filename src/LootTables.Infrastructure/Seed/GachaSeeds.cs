using LootTables.Domain.Entities;
using LootTables.Domain.Entities.LootTable;

namespace LootTables.Infrastructure.Seed
{
    public static class GachaSeeds
    {
        public static LootTableEntity GetDraw10LootTable()
        {
            var lootTable = new LootTableEntity
            {
                TableId = "GachaDrawRates"
            };

            var nineRandom = new LootTableEntity
            {
                DropCount = 9,
                IsGuaranteed = true
            };

            nineRandom.AddEntry(new ItemEntity
            {
                DropRate = 50,
                Name = "Common",
                Rarity = "Common"
            });
            nineRandom.AddEntry(new ItemEntity
            {
                DropRate = 30,
                Name = "Rare",
                Rarity = "Rare"
            });
            nineRandom.AddEntry(new ItemEntity
            {
                DropRate = 15,
                Name = "Epic",
                Rarity = "Epic"
            });
            nineRandom.AddEntry(new ItemEntity
            {
                DropRate = 5,
                Name = "Legendary",
                Rarity = "Legendary"
            });

            var oneGuaranteed = new LootTableEntity
            {
                DropCount = 1,
                IsGuaranteed = true
            };
            oneGuaranteed.AddEntry(new ItemEntity
            {
                DropRate = 95,
                Name = "Epic",
                Rarity = "Epic"
            });
            oneGuaranteed.AddEntry(new ItemEntity
            {
                DropRate = 5,
                Name = "Legendary",
                Rarity = "Legendary"
            });

            lootTable.AddEntry(nineRandom);
            lootTable.AddEntry(oneGuaranteed);

            return lootTable;
        }

        public static LootTableEntity GetLoot()
        {
            var result = new LootTableEntity
            {
                TableId = "GachaLoot"
            };

            var common = new LootTableEntity
            {
                TableId = "Common",
                DropCount = 1
            };

            common.AddEntry(new ItemEntity
            {
                Name = "Rusty sword",
                DropRate = 1,
                Rarity = "Common"
            });
            common.AddEntry(new ItemEntity
            {
                Name = "Old staff",
                DropRate = 1,
                Rarity = "Common"
            });
            common.AddEntry(new ItemEntity
            {
                Name = "Dagger",
                DropRate = 1,
                Rarity = "Common"
            });
            common.AddEntry(new ItemEntity
            {
                Name = "Rusty armor",
                DropRate = 1,
                Rarity = "Common"
            });

            var rare = new LootTableEntity
            {
                TableId = "Rare",
                DropCount = 1
            };

            rare.AddEntry(new ItemEntity
            {
                Name = "Good sword",
                DropRate = 1,
                Rarity = "Rare"
            });
            rare.AddEntry(new ItemEntity
            {
                Name = "Iron mace",
                DropRate = 1,
                Rarity = "Rare"
            });
            rare.AddEntry(new ItemEntity
            {
                Name = "Wizard hat",
                DropRate = 1,
                Rarity = "Rare"
            });
            rare.AddEntry(new ItemEntity
            {
                Name = "Boots of speed",
                DropRate = 1,
                Rarity = "Rare"
            });

            var epic = new LootTableEntity
            {
                TableId = "Epic",
                DropCount = 1
            };

            epic.AddEntry(new ItemEntity
            {
                Name = "Fire sword",
                DropRate = 1,
                Rarity = "Epic"
            });
            epic.AddEntry(new ItemEntity
            {
                Name = "Glass dagger",
                DropRate = 1,
                Rarity = "Epic"
            });
            epic.AddEntry(new ItemEntity
            {
                Name = "Cursed armor",
                DropRate = 1,
                Rarity = "Epic"
            });
            epic.AddEntry(new ItemEntity
            {
                Name = "Ring of wisdom",
                DropRate = 1,
                Rarity = "Epic"
            });

            var legendary = new LootTableEntity
            {
                TableId = "Legendary",
                DropCount = 1
            };

            legendary.AddEntry(new ItemEntity
            {
                Name = "Sword of doom",
                DropRate = 1,
                Rarity = "Legendary"
            });
            legendary.AddEntry(new ItemEntity
            {
                Name = "Mithril amor",
                DropRate = 1,
                Rarity = "Legendary"
            });
            legendary.AddEntry(new ItemEntity
            {
                Name = "Necronomicon",
                DropRate = 0.5,
                Rarity = "Legendary"
            });
            legendary.AddEntry(new ItemEntity
            {
                Name = "Ring of justice",
                DropRate = 1,
                Rarity = "Legendary"
            });

            result.AddEntry(common);
            result.AddEntry(rare);
            result.AddEntry(epic);
            result.AddEntry(legendary);

            return result;
        }
    }
}
