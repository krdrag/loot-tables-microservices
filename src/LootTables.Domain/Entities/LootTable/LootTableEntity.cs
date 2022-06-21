namespace LootTables.Domain.Entities.LootTable
{
    /// <summary>
    /// Class describing loot table. It extends LootTableEntryModel 
    /// to allow creating separate "thematic" tables for one roll.
    /// </summary>
    public class LootTableEntity : LootEntryEntity
    {
        /// <summary>
        /// How many items will drop from single roll (max amount)
        /// Does not include guaranteed drops
        /// </summary>
        public int DropCount { get; set; }

        /// <summary>
        /// Items that can drop from table.
        /// </summary>
        public ICollection<LootEntryEntity> TableContents { get; set; } = new List<LootEntryEntity>();

        public void AddEntry(LootEntryEntity entry)
        {
            TableContents.Add(entry);
        }
    }
}
