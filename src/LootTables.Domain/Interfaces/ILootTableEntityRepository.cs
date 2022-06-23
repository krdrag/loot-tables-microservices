using LootTables.Domain.Entities.LootTable;

namespace LootTables.Domain.Interfaces
{
    public interface ILootTableEntityRepository
    {
        Task<LootTableEntity> GetLootTable(string tableId);
    }
}
