namespace LootTables.Domain.Entities.LootTable
{
    /// <summary>
    /// Type of loot used for drops of "values" like gold or experience.
    /// But can be used for more complex items.
    /// </summary>
    /// <typeparam name="T">Type of dropped value</typeparam>
    public class ValueEntryEntity<T> : LootEntryEntity
    {
        public T Value { get; set; }
    }
}
