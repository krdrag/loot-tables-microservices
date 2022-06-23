using LootTables.Application.Models;
using LootTables.Domain.Entities;
using LootTables.Domain.Interfaces;

namespace LootTables.Application.Services
{
    public class LootService : ILootService
    {
        private readonly IRandomizerService _randomizer;
        private readonly ILootTableEntityRepository _repository;

        public LootService(IRandomizerService randomizer, ILootTableEntityRepository repository)
        {
            _randomizer = randomizer;
            _repository = repository;
        }

        public async Task<List<ItemModel>> GetLoot(string lootTableId)
        {
            var lootTable = await _repository.GetLootTable(lootTableId);

            if (lootTable == null)
                throw new Exception();

            return RollFromMasterTable(lootTable);
        }

        private List<ItemModel> RollFromMasterTable(MasterTableEntity masterTable)
        {
            var result = new List<LootEntity>();

            foreach (var loot in masterTable.GuranteedLoot)
                AddToResult(loot, result);

            foreach (var table in masterTable.LootTables)
                result.AddRange(RollFromTable(table));


            return result
                .Select(x => new ItemModel
                {
                    Name = x.Name,
                    Rarity = x.Rarity,
                    IsGuaranteed = x.IsGuaranteed,
                    Quantity = _randomizer.GetIntValue(x.MinQuantity, x.MaxQuantity)
                })
                .ToList();
        }

        private List<LootEntity> RollFromTable(LootTableEntity lootTable)
        {
            var result = new List<LootEntity>();

            for (int i = 0; i < lootTable.DropCount; i++)
            {
                double runningvalue = 0;
                double hitValue = 0;

                if (lootTable.Loot.Any())
                {
                    var dropables = lootTable.Loot
                        .Where(x => x.IsEnabled);

                    hitValue = _randomizer.GetDoubleValue(dropables.Sum(e => e.DropRate));

                    foreach (var entry in dropables)
                    {
                        runningvalue += entry.DropRate;
                        if (hitValue < runningvalue)
                        {
                            AddToResult(entry, result);
                            break;
                        }
                    }
                }
                else
                {
                    var dropables = lootTable.SubTables
                        .Where(x => x.IsEnabled);

                    hitValue = _randomizer.GetDoubleValue(dropables.Sum(e => 2/*e.DropRate*/));

                    foreach (var entry in dropables)
                    {
                        runningvalue += 2; //entry.DropRate;
                        if (hitValue < runningvalue)
                        {
                            AddToResult(RollFromTable(entry), result);
                            break;
                        }
                    }
                }
            }

            return result;
        }

        private void AddToResult(IEnumerable<LootEntity> entries, List<LootEntity> results)
        {
            foreach (var entry in entries)
            {
                AddToResult(entry, results);
            }
        }

        private void AddToResult(LootEntity entry, List<LootEntity> results)
        {
            if (entry.IsUnique && results.Contains(entry) || entry.IsNull)
                return;

            results.Add(entry);
        }











        //public List<ItemModel> GetGacha()
        //{
        //    var rarityRollLootTable = _repository.GetLootTable("Gacha");
        //    var lootRollTable = _repository.GetLootTable("GachaLoot");

        //    var rarityRollResults = RollResults(rarityRollLootTable);

        //    var result = new List<ItemModel>();

        //    foreach(var rarityRollResult in rarityRollResults)
        //    {
        //        var lootTable = lootRollTable.TableContents
        //            .Where(x => x is LootTableEntity entity && entity.TableId.Equals(rarityRollResult.Rarity))
        //            .OfType<LootTableEntity>()
        //            .FirstOrDefault();

        //        if (lootTable == null)
        //            continue;

        //        var loot = RollResults(lootTable)
        //            .Select(x => new ItemModel
        //            {
        //                Name = x.Name,
        //                Rarity = x.Rarity
        //            })
        //        .ToList();

        //        result.AddRange(loot);
        //    }

        //    return result;
        //}

        //private List<LootEntity> RollResults(LootTableEntity table)
        //{
        //    var result = new List<LootEntity>();

        //    // Add guaranteed drops to result
        //    foreach (var drop in table.TableContents.Where(x => x.IsEnabled && x.IsGuaranteed))
        //        AddToResult(drop, result);

        //    for (int i = 0; i < table.DropCount; i++)
        //    {
        //        var dropables = table.TableContents
        //            .Where(x => x.IsEnabled && !x.IsGuaranteed);

        //        var hitValue = _randomizer.GetDoubleValue(dropables.Sum(e => e.DropRate));
        //        double runningvalue = 0;

        //        foreach (var entry in dropables)
        //        {
        //            runningvalue += entry.DropRate;
        //            if (hitValue < runningvalue)
        //            {
        //                AddToResult(entry, result);
        //                break;
        //            }
        //        }

        //    }

        //    return result;
        //}

        //private void AddToResult(LootEntryEntity entry, List<LootEntity> results)
        //{
        //    if (entry.IsUnique && results.Contains(entry) || entry.IsNull)
        //        return;

        //    if (entry is LootTableEntity table)
        //        results.AddRange(RollResults(table));
        //    else
        //        results.Add((LootEntity)entry);
        //}
    }
}
