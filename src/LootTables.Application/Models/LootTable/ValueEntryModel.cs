namespace LootTables.Application.Models.LootTable
{
    /// <summary>
    /// Type of loot used for drops of "values" like gold or experience.
    /// But can be used for more complex items.
    /// </summary>
    /// <typeparam name="T">Type of dropped value</typeparam>
    public class ValueEntryModel<T> : LootEntryModel
    {
        public T Value { get; set; }

        public ValueEntryModel(T value, double dropRate)
            : this(value, dropRate, false, false, true)
        { }

        public ValueEntryModel(T value, double dropRate, bool isUnique, bool guaranteed, bool isEnabled)
            : base(dropRate, isUnique, guaranteed, isEnabled)
        {
            Value = value;
        }
    }
}
