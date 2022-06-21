using LootTables.Application.Models;
using LootTables.Application.Models.LootTable;

namespace LootTables.Application.Services
{
    public class LootService : ILootService
    {
        private readonly IRandomizerService _randomizer;

        public LootService(IRandomizerService randomizer)
        {
            _randomizer = randomizer;
        }

        public List<string?> GetLoot(string lootTableId)
        {
            //var lootTable = _lootTableRepo.GetlootTable(lootTableId);

            var lootTable = new LootTableModel();
            lootTable.DropCount = 5;

            lootTable.AddEntry(new DemoItemModel("Item 1", 5));
            lootTable.AddEntry(new DemoItemModel("Item 2", 5));
            lootTable.AddEntry(new DemoItemModel("Item 3", 5));
            lootTable.AddEntry(new DemoItemModel("Item 4", 5));
            lootTable.AddEntry(new NullEntryModel(15));

            return RollResults(lootTable)
                .Select(x => x.ToString())
                .ToList();
        }

        private List<LootEntryModel> RollResults(LootTableModel table)
        {
            var result = new List<LootEntryModel>();

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

        private void AddToResult(LootEntryModel entry, List<LootEntryModel> results)
        {
            if (entry.IsUnique && results.Contains(entry) || entry is NullEntryModel)
                return;

            if (entry is LootTableModel table)
                results.AddRange(RollResults(table));
            else
                results.Add(entry);
        }
    }
}
