using LootTables.Domain.Entities;

namespace LootTables.Infrastructure.Seed
{
    public static class LootSeeds
    {
        public static MasterTableEntity BasicScenario()
        {
            return new MasterTableEntity
            {
                TableId = "BasicScenario",
                LootTables = new List<LootTableEntity>
                {
                    new LootTableEntity
                    {
                        DropCount = 5,
                        Loot = new List<LootEntity>
                        {
                            new LootEntity
                            {
                                Name = "Sword",
                                Rarity = "Common",
                                DropRate = 5,
                                MaxQuantity = 1,
                                MinQuantity = 1
                            },
                            new LootEntity
                            {
                                Name = "Staff",
                                Rarity = "Common",
                                DropRate = 5,
                                MaxQuantity = 1,
                                MinQuantity = 1
                            }
                        }
                    },
                    new LootTableEntity
                    {
                        DropCount=2,
                        SubTables = new List<LootTableEntity>
                        {
                            new LootTableEntity
                            {
                                DropCount = 1,
                                Loot = new List<LootEntity>
                                {
                                    new LootEntity
                                    {
                                        Name = "test"
                                    }
                                }
                            },
                            new LootTableEntity
                            {
                                DropCount = 1,
                                Loot = new List<LootEntity>
                                {
                                    new LootEntity
                                    {
                                        Name = "test2"
                                    }
                                }
                            }
                        }
                    }
                }
            };
        }






        /// <summary>
        /// Base scenario with drops of various rarities and guaranteed gold drop.
        /// </summary>
        //public static LootTableEntity BaseScenario()
        //{
        //    var lootTable = new LootTableEntity
        //    {
        //        TableId = "BaseScenario"
        //    };

        //    var itemTable = new LootTableEntity
        //    {
        //        IsGuaranteed = true,
        //        DropCount = 5
        //    };

        //    itemTable.AddEntry(new LootEntity
        //    {
        //        Name = "Rusty Sword",
        //        Rarity = "Common",
        //        DropRate = 15
        //    });
        //    itemTable.AddEntry(new LootEntity
        //    {
        //        Name = "Iron Sword",
        //        Rarity = "Rare",
        //        DropRate = 10
        //    });
        //    itemTable.AddEntry(new LootEntity
        //    {
        //        Name = "Magic Sword",
        //        Rarity = "Epic",
        //        DropRate = 5
        //    });
        //    itemTable.AddEntry(new LootEntity
        //    {
        //        Name = "Excalibur",
        //        Rarity = "Legendary",
        //        DropRate = 1
        //    });
        //    itemTable.AddEntry(new LootEntity
        //    {
        //        IsNull = true,
        //        DropRate = 10
        //    });

        //    var goldTable = new LootTableEntity
        //    {
        //        IsGuaranteed = true
        //    };

        //    goldTable.AddEntry(new LootEntity
        //    {
        //        Name = "Gold",
        //        IsGuaranteed = true,
        //        MinQuantity = 100,
        //        MaxQuantity = 200
        //    });

        //    lootTable.AddEntry(itemTable);
        //    lootTable.AddEntry(goldTable);

        //    return lootTable;
        //}

        ///// <summary>
        ///// Advanced scenario with drops of various rarities and guaranteed gold drop.
        ///// </summary>
        //public static LootTableEntity AdvancedScenario()
        //{
        //    var lootTable = new LootTableEntity();
        //    lootTable.TableId = "AdvancedScenario";

        //    var rareTable = new LootTableEntity
        //    {
        //        IsGuaranteed = true,
        //        DropCount = 3
        //    };

        //    rareTable.AddEntry(new LootEntity
        //    {
        //        Name = "Rusty sword",
        //        Rarity = "Common",
        //        DropRate = 5
        //    });
        //    rareTable.AddEntry(new LootEntity
        //    {
        //        Name = "Old mace",
        //        Rarity = "Common",
        //        DropRate = 5
        //    });
        //    rareTable.AddEntry(new LootEntity
        //    {
        //        Name = "Sword",
        //        Rarity = "Rare",
        //        DropRate = 2
        //    });
        //    rareTable.AddEntry(new LootEntity
        //    {
        //        Name = "Staff",
        //        Rarity = "Common",
        //        DropRate = 2
        //    });

        //    var epicTable = new LootTableEntity
        //    {
        //        IsGuaranteed = true,
        //        DropCount = 3
        //    };

        //    epicTable.AddEntry(new LootEntity
        //    {
        //        Name = "Magic Sword",
        //        Rarity = "Epic",
        //        DropRate = 5
        //    });
        //    epicTable.AddEntry(new LootEntity
        //    {
        //        Name = "Magic Armor",
        //        Rarity = "Epic",
        //        DropRate = 5
        //    });
        //    epicTable.AddEntry(new LootEntity
        //    {
        //        Name = "Cursed Dagger",
        //        Rarity = "Epic",
        //        DropRate = 4
        //    });
        //    epicTable.AddEntry(new LootEntity
        //    {
        //        Name = "Arondight",
        //        Rarity = "Legendary",
        //        DropRate = .5
        //    });

        //    var goldTable = new LootTableEntity
        //    {
        //        IsGuaranteed = true
        //    };

        //    goldTable.AddEntry(new LootEntity
        //    {
        //        Name = "Gold",
        //        IsGuaranteed = true,
        //        MinQuantity = 300,
        //        MaxQuantity = 600
        //    });

        //    lootTable.AddEntry(rareTable);
        //    lootTable.AddEntry(epicTable);
        //    lootTable.AddEntry(goldTable);

        //    return lootTable;
        //}
    }
}
