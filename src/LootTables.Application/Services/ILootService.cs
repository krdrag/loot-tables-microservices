using LootTables.Application.Models.LootTable;

namespace LootTables.Application.Services
{
    public interface ILootService
    {
        List<string?> GetLoot(string lootTableId);
    }
}
