using LootTables.Application.Models;

namespace LootTables.Application.Services
{
    public interface ILootService
    {
        /// <summary>
        /// Roll loot using provided loot table name
        /// </summary>
        /// <param name="lootTableId">Name of master table to roll from.</param>
        /// <returns>List of rolled items.</returns>
        Task<List<ItemModel>> GetLoot(string lootTableId);
    }
}
