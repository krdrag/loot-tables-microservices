namespace LootTables.Domain.Entities
{
    public class LootTableEntity
    {
        /// <summary>
        /// Sub tables for more complex cases.
        /// </summary>
        public IEnumerable<LootTableEntity> SubTables { get; set; } = Enumerable.Empty<LootTableEntity>();

        /// <summary>
        /// Loot dropped by this table.
        /// </summary>
        public IEnumerable<LootEntity> Loot { get; set; } = Enumerable.Empty<LootEntity>();

        /// <summary>
        /// Information about what this table may drop.
        /// </summary>
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// How many items (max) this table can drop from one roll.
        /// </summary>
        public int DropCount { get; set; }

        /// <summary>
        /// Chance for rolling from this table (if is a subtable of other LootTableEntity).
        /// </summary>
        public double DropRate { get; set; }

        /// <summary>
        /// Will only be rolled from if enabled.
        /// </summary>
        public bool IsEnabled { get; set; } = true;
    }
}
