using LootTables.Domain.Entities.LootTable;

namespace LootTables.Domain.Entities
{
    public class ItemEntity : LootEntryEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Rarity { get; set; } = string.Empty;

        //public bool IsTheSameItem(ItemEntity other)
        //{
        //    return Name.Equals(other.Name) && Rarity.Equals(other.Rarity);
        //}
    }
}
