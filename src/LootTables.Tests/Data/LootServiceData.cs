using LootTables.Application.Models;
using LootTables.Domain.Entities;
using System.Collections.Generic;

namespace LootTables.Tests.Data
{
    public static class LootServiceData
    {
        public static IEnumerable<object[]> ValidLootTables()
        {
            yield return new object[]
            {
                new MasterTableEntity
                {
                    TableId = "TestTable",
                    LootTables = new List<LootTableEntity>
                    {
                        new LootTableEntity
                        {
                            DropCount = 1,
                            Loot = new List<LootEntity>
                            {
                                new LootEntity
                                {
                                    Name = "TestItem",
                                    DropRate = 5,
                                }
                            }
                        }
                    }
                },
                (2d, 1),
                new List<ItemModel>()
                {
                    new ItemModel
                    {
                        Name = "TestItem",
                        IsGuaranteed = false,
                        Quantity = 1,
                        Rarity = string.Empty
                    }
                }
            };

            yield return new object[]
            {
                new MasterTableEntity
                {
                    TableId = "TestTable",
                    LootTables = new List<LootTableEntity>
                    {
                        new LootTableEntity
                        {
                            DropCount = 1,
                            Loot = new List<LootEntity>
                            {
                                new LootEntity
                                {
                                    Name = "TestItem",
                                    DropRate = 5,
                                },
                                new LootEntity
                                {
                                    Name = "TestItem2",
                                    DropRate = 5,
                                }
                            }
                        }
                    }
                },
                (7d, 1),
                new List<ItemModel>()
                {
                    new ItemModel
                    {
                        Name = "TestItem2",
                        IsGuaranteed = false,
                        Quantity = 1,
                        Rarity = string.Empty
                    }
                }
            };

            yield return new object[]
            {
                new MasterTableEntity
                {
                    TableId = "TestTable",
                    LootTables = new List<LootTableEntity>
                    {
                        new LootTableEntity
                        {
                            DropCount = 1,
                            SubTables = new List<LootTableEntity>
                            {
                                new LootTableEntity
                                {
                                    DropCount = 1,
                                    DropRate = 5,
                                    Loot = new List<LootEntity>
                                    {
                                        new LootEntity
                                        {
                                            Name = "TestItem",
                                            DropRate = 5
                                        }
                                    }
                                }
                            }
                        }
                    }
                },
                (2d, 1),
                new List<ItemModel>()
                {
                    new ItemModel
                    {
                        Name = "TestItem",
                        IsGuaranteed = false,
                        Quantity = 1,
                        Rarity = string.Empty
                    }
                }
            };
        }
    }
}
