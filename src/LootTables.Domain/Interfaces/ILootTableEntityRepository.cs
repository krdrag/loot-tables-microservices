using LootTables.Domain.Entities.LootTable;

namespace LootTables.Domain.Interfaces
{
    public interface ILootTableEntityRepository
    {
        LootTableEntity GetLootTable(string tableId);
    }
}
