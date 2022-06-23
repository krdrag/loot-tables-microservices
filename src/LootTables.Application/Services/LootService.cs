using LootTables.Application.Models;
using LootTables.Domain.Entities;
using LootTables.Domain.Entities.LootTable;
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

            return RollResults(lootTable)
                .Select(x => new ItemModel
                {
                    Name = x.Name,
                    Rarity = x.Rarity,
                    IsGuaranteed = x.IsGuaranteed,
                    Quantity = _randomizer.GetIntValue(x.MinQuantity,x.MaxQuantity)
                })
                .ToList();
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

        private List<ItemEntity> RollResults(LootTableEntity table)
        {
            var result = new List<ItemEntity>();

            // Add guaranteed drops to result
            foreach (var drop in table.TableContents.Where(x => x.IsEnabled && x.IsGuaranteed))
                AddToResult(drop, result);

            for (int i = 0; i < table.DropCount; i++)
            {
                var dropables = table.TableContents
                    .Where(x => x.IsEnabled && !x.IsGuaranteed);

                var hitValue = _randomizer.GetDoubleValue(dropables.Sum(e => e.DropRate));
                double runningvalue = 0;

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

            return result;
        }

        private void AddToResult(LootEntryEntity entry, List<ItemEntity> results)
        {
            if (entry.IsUnique && results.Contains(entry) || entry.IsNull)
                return;

            if (entry is LootTableEntity table)
                results.AddRange(RollResults(table));
            else
                results.Add((ItemEntity)entry);
        }
    }
}
