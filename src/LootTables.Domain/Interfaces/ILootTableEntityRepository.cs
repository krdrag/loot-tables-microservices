using LootTables.Domain.Entities;

namespace LootTables.Domain.Interfaces
{
    public interface ILootTableEntityRepository
    {
        Task<MasterTableEntity?> GetLootTableAsync(string tableId);

        void Insert(MasterTableEntity entity);
    }
}
