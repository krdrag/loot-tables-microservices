using LootTables.Application.Models;

namespace LootTables.Application.Services
{
    public interface ILootService
    {
        Task<List<ItemModel>> GetLoot(string lootTableId);

        //List<ItemModel> GetGacha();
    }
}
