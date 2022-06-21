using LootTables.Application.Models;

namespace LootTables.Application.Services
{
    public interface ILootService
    {
        List<ItemModel> GetLoot(string lootTableId);
    }
}
