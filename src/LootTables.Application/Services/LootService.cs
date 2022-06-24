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
            var lootTable = await _repository.GetLootTableAsync(lootTableId);

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

                    hitValue = _randomizer.GetDoubleValue(dropables.Sum(e => e.DropRate));

                    foreach (var entry in dropables)
                    {
                        runningvalue += entry.DropRate;
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

        private static void AddToResult(IEnumerable<LootEntity> entries, List<LootEntity> results)
        {
            foreach (var entry in entries)
            {
                AddToResult(entry, results);
            }
        }

        private static void AddToResult(LootEntity entry, List<LootEntity> results)
        {
            if (entry.IsUnique && results.Contains(entry) || entry.IsNull)
                return;

            results.Add(entry);
        }
    }
}
