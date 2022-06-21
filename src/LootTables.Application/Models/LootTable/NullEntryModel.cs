namespace LootTables.Application.Models.LootTable
{
    /// <summary>
    /// Class used for representation of dropping nothing from loot table.
    /// </summary>
    public class NullEntryModel : LootEntryModel
    {
        public NullEntryModel(double dropRate) : base(dropRate, false, false, true)
        {
        }
    }
}
