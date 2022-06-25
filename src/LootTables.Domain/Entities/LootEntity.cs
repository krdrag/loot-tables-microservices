namespace LootTables.Domain.Entities
{
    public record LootEntity
    {
        /// <summary>
        /// Name of dropped item.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Rarity of dropped item
        /// </summary>
        public string Rarity { get; set; } = string.Empty;

        /// <summary>
        /// Chance to roll this item
        /// </summary>
        public double DropRate { get; set; }

        /// <summary>
        /// If this item will be rolled only once. 
        /// </summary>
        public bool IsUnique { get; set; } = false;

        /// <summary>
        /// Used for items that drop always (for example like quest items)
        /// </summary>
        public bool IsGuaranteed { get; set; } = false;

        /// <summary>
        /// Will only drop if enabled.
        /// </summary>
        public bool IsEnabled { get; set; } = true;

        /// <summary>
        /// Used for items that drop in bigger quantities (gold, experience)
        /// </summary>
        public int MinQuantity { get; set; } = 1;

        /// <summary>
        /// Used for items that drop in bigger quantities (gold, experience)
        /// </summary>
        public int MaxQuantity { get; set; } = 1;

        /// <summary>
        /// Special flag - if set then item will be considered as empty roll.
        /// </summary>
        public bool IsNull { get; set; } = false;
    }
}
