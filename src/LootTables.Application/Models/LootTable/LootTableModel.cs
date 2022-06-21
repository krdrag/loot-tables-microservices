namespace LootTables.Application.Models.LootTable
{
    /// <summary>
    /// Class describing loot table. It extends LootTableEntryModel 
    /// to allow creating separate "thematic" tables for one roll.
    /// </summary>
    public class LootTableModel : LootEntryModel
    {
        /// <summary>
        /// How many items will drop from single roll (max amount)
        /// Does not include guaranteed drops
        /// </summary>
        public int DropCount { get; set; }

        /// <summary>
        /// Items that can drop from table.
        /// </summary>
        public ICollection<LootEntryModel> TableContents { get; set; } = new List<LootEntryModel>();

        public LootTableModel()
            : this(null, 1, 1, false, false, true)
        {
        }

        public LootTableModel(IEnumerable<LootEntryModel>? contents, int count, double dropRate)
            : this(contents, count, dropRate, false, false, true)
        {
        }

        public LootTableModel(IEnumerable<LootEntryModel>? contents, int dropCount, double dropRate, bool isUnique, bool guaranteed, bool isEnabled)
            : base(dropRate, isUnique, guaranteed, isEnabled)
        {
            if (contents != null)
                TableContents = contents.ToList();
            else
                TableContents.Clear();

            DropCount = dropCount;
        }

        public void AddEntry(LootEntryModel entry)
        {
            TableContents.Add(entry);
        }
    }
}
