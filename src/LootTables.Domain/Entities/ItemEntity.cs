using LootTables.Domain.Entities.LootTable;

namespace LootTables.Domain.Entities
{
    public class ItemEntity : LootEntryEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Rarity { get; set; } = string.Empty;
    }
}
