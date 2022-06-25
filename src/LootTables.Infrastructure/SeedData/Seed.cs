using LootTables.Domain.Constants;
using LootTables.Domain.Entities;

namespace LootTables.Infrastructure.SeedData
{
    public static class Seed
    {
        public static MasterTableEntity GetLoot()
        {
            return new MasterTableEntity
            {
                TableId = MongoConstants.MongoTable_LootTable,
                LootTables = new List<LootTableEntity>
                {
                    new LootTableEntity
                    {
                        Description = "Drop items",
                        DropCount = 5,
                        SubTables = new List<LootTableEntity>
                        {
                            new LootTableEntity
                            {
                                Description = "Epics",
                                DropCount = 1,
                                DropRate = 1,
                                Loot = new List<LootEntity>
                                {
                                    new LootEntity
                                    {
                                        Name = "Sword of Doom",
                                        Rarity = "Epic",
                                        DropRate = 1
                                    },
                                    new LootEntity
                                    {
                                        Name = "Ring of Wisdom",
                                        Rarity = "Epic",
                                        DropRate = 1
                                    },
                                    new LootEntity
                                    {
                                        Name = "Gladiator's Mask",
                                        Rarity = "Epic",
                                        DropRate = 1
                                    }
                                }
                            },
                            new LootTableEntity
                            {
                                Description = "Rare",
                                DropCount = 1,
                                DropRate = 3,
                                Loot = new List<LootEntity>
                                {
                                    new LootEntity
                                    {
                                        Name = "Boots of Speed",
                                        Rarity = "Rare",
                                        DropRate = 1
                                    },
                                    new LootEntity
                                    {
                                        Name = "Steel Sword",
                                        Rarity = "Rare",
                                        DropRate = 1
                                    },
                                    new LootEntity
                                    {
                                        Name = "Ring of Light",
                                        Rarity = "Rare",
                                        DropRate = 1
                                    }
                                }
                            },
                            new LootTableEntity
                            {
                                Description = "Common",
                                DropCount = 1,
                                DropRate = 5,
                                Loot = new List<LootEntity>
                                {
                                    new LootEntity
                                    {
                                        Name = "Iron Sword",
                                        Rarity = "Common",
                                        DropRate = 1
                                    },
                                    new LootEntity
                                    {
                                        Name = "Mace",
                                        Rarity = "Common",
                                        DropRate = 1
                                    },
                                    new LootEntity
                                    {
                                        Name = "Chainmail",
                                        Rarity = "Common",
                                        DropRate = 1
                                    }
                                }
                            }
                        }
                    },
                    new LootTableEntity
                    {
                        Description = "Misc items",
                        DropCount = 3,
                        Loot = new List<LootEntity>
                        {
                            new LootEntity
                            {
                                Name = "Linen cloth",
                                Rarity = "Common",
                                DropRate = 5,
                                IsUnique = true,
                                MinQuantity = 5,
                                MaxQuantity = 15
                            },
                            new LootEntity
                            {
                                Name = "Wool cloth",
                                Rarity = "Common",
                                DropRate = 2,
                                IsUnique = true,
                                MinQuantity = 1,
                                MaxQuantity = 5
                            },
                            new LootEntity
                            {
                                DropRate = 2,
                                IsNull = true
                            }
                        }
                    },
                    new LootTableEntity
                    {
                        Description = "Gold",
                        DropCount = 1,
                        Loot = new List<LootEntity>
                        {
                            new LootEntity
                            {
                                Name = "Gold",
                                DropRate = 1,
                                MinQuantity = 100,
                                MaxQuantity = 200
                            }
                        }
                    }
                }
            };
        }

        public static MasterTableEntity GetGachaDrops()
        {
            return new MasterTableEntity
            {
                TableId = MongoConstants.MongoTable_GachaTable,
                LootTables = new List<LootTableEntity>
                {
                    new LootTableEntity
                    {
                        Description = "Random 9 pulls",
                        DropCount = 9,
                        SubTables = new List<LootTableEntity>
                        {
                            new LootTableEntity
                            {
                                Description = "Common pull chance",
                                DropCount = 1,
                                DropRate = 50,
                                SubTables = new List<LootTableEntity>
                                {
                                    CommonItems
                                }
                            },
                            new LootTableEntity
                            {
                                Description = "Rare pull chance",
                                DropCount = 1,
                                DropRate = 35,
                                SubTables = new List<LootTableEntity>
                                {
                                    RareItems
                                }
                            },
                            new LootTableEntity
                            {
                                Description = "Epic pull chance",
                                DropCount = 1,
                                DropRate = 15,
                                SubTables = new List<LootTableEntity>
                                {
                                    EpicItems
                                }
                            }
                        }
                    },
                    new LootTableEntity
                    {
                        Description = "Guaranteed 1 pull",
                        DropCount = 1,
                        SubTables = new List<LootTableEntity>
                        {
                            new LootTableEntity
                            {
                                Description = "Rare pull chance",
                                DropCount = 1,
                                DropRate = 85,
                                SubTables = new List<LootTableEntity>
                                {
                                    RareItems
                                }
                            },
                            new LootTableEntity
                            {
                                Description = "Epic pull chance",
                                DropCount = 1,
                                DropRate = 15,
                                SubTables = new List<LootTableEntity>
                                {
                                    EpicItems
                                }
                            }
                        }
                    }
                }
            };
        }

        public static LootTableEntity CommonItems
            => new()
            {
                Description = "Common items",
                DropCount = 1,
                DropRate = 1,
                Loot = new List<LootEntity>
                {
                    new LootEntity
                    {
                        Name = "Steel Sword",
                        Rarity = "Common",
                        DropRate = 1
                    },
                    new LootEntity
                    {
                        Name = "Iron Gauntlet",
                        Rarity = "Common",
                        DropRate = 1
                    },
                    new LootEntity
                    {
                        Name = "Magic Staff",
                        Rarity = "Common",
                        DropRate = 1
                    }
                }
            };

        public static LootTableEntity RareItems
            => new()
            {
                Description = "Rare Items",
                DropCount = 1,
                DropRate = 1,
                Loot = new List<LootEntity>
                {
                    new LootEntity
                    {
                        Name = "Ring of Speed",
                        Rarity = "Rare",
                        DropRate = 1
                    },
                    new LootEntity
                    {
                        Name = "Flame Claymore",
                        Rarity = "Rare",
                        DropRate = 1
                    },
                    new LootEntity
                    {
                        Name = "Invisibility Hat",
                        Rarity = "Rare",
                        DropRate = 1
                    }
                }
            };

        public static LootTableEntity EpicItems
            => new()
            {
                Description = "Epic Items",
                DropCount = 1,
                DropRate = 1,
                Loot = new List<LootEntity>
                {
                    new LootEntity
                    {
                        Name = "Sword of Doom",
                        Rarity = "Epic",
                        DropRate = 1
                    },
                    new LootEntity
                    {
                        Name = "Armageddon's Blade",
                        Rarity = "Epic",
                        DropRate = 1
                    },
                    new LootEntity
                    {
                        Name = "Frostmourne",
                        Rarity = "Epic",
                        DropRate = 1
                    }
                }
            };
    }
}
