using LootTables.Domain.Entities;

namespace LootTables.Domain.Interfaces
{
    public interface ILootTableEntityRepository
    {
        Task<MasterTableEntity?> GetLootTable(string tableId);
    }
}
