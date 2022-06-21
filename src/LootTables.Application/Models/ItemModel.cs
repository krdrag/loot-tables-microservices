namespace LootTables.Application.Models
{
    public class ItemModel
    {
        public string Name { get; set; } = string.Empty;
        public string Rarity { get; set; } = string.Empty;
        public bool IsGuaranteed { get; set; } = false;
        public int Quantity { get; set; } = 1;

    }
}
