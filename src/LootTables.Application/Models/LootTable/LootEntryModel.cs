namespace LootTables.Application.Models.LootTable
{
    /// <summary>
    /// Definition of single item's chance to be rolled.
    /// </summary>
    public class LootEntryModel
    {
        /// <summary>
        /// Probability to roll this item. It is not eprcent. 
        /// It's value that describes the chance of being hit in relation to the other items in the table.
        /// </summary>
        public double DropRate { get; set; }
        /// <summary>
        /// Flag to make item only drop once per roll.
        /// </summary>
        public bool IsUnique { get; set; }
        /// <summary>
        /// Flag to make the item drop always.
        /// </summary>
        public bool IsGuaranteed { get; set; }
        /// <summary>
        /// Optional flag to conditionally disable item drop.
        /// </summary>
        public bool IsEnabled { get; set; }

        public LootEntryModel()
            : this(0)
        { }

        public LootEntryModel(double dropRate)
            : this(dropRate, false, false, true)
        { }

        public LootEntryModel(double dropRate, bool isUnique, bool guaranteed, bool isEnabled)
        {
            DropRate = dropRate;
            IsUnique = isUnique;
            IsGuaranteed = guaranteed;
            IsEnabled = isEnabled;
        }
    }
}
