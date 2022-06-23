using LootTables.Domain.Entities.LootTable;

namespace LootTables.Domain.Entities
{
    public record LootEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Rarity { get; set; } = string.Empty;
        public double DropRate { get; set; }
        public bool IsUnique { get; set; } = false;
        public bool IsGuaranteed { get; set; } = false;
        public bool IsEnabled { get; set; } = true;
        public int MinQuantity { get; set; } = 1;
        public int MaxQuantity { get; set; } = 1;
        public bool IsNull { get; set; } = false;
    }
}
