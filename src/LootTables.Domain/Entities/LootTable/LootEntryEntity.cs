namespace LootTables.Domain.Entities.LootTable 
{
    /// <summary>
    /// Definition of single item's chance to be rolled.
    /// </summary>
    public class LootEntryEntity
    {
        /// <summary>
        /// Probability to roll this item. It is not eprcent. 
        /// It's value that describes the chance of being hit in relation to the other items in the table.
        /// </summary>
        public double DropRate { get; set; }
        /// <summary>
        /// Flag to make item only drop once per roll.
        /// </summary>
        public bool IsUnique { get; set; } = false;
        /// <summary>
        /// Flag to make the item drop always.
        /// </summary>
        public bool IsGuaranteed { get; set; } = false;
        /// <summary>
        /// Optional flag to conditionally disable item drop.
        /// </summary>
        public bool IsEnabled { get; set; } = true;

        /// <summary>
        /// Special flag used to indicate that this drop is empty.
        /// </summary>
        public bool IsNull { get; set; } = false;

        //public LootEntryEntity()
        //    : this(0)
        //{ }

        //public LootEntryEntity(double dropRate)
        //    : this(dropRate, false, false, true)
        //{ }

        //public LootEntryEntity(double dropRate, bool isUnique, bool guaranteed, bool isEnabled)
        //{
        //    DropRate = dropRate;
        //    IsUnique = isUnique;
        //    IsGuaranteed = guaranteed;
        //    IsEnabled = isEnabled;
        //}
    }
}
