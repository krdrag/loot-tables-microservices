using LootTables.Application.Models.LootTable;
using Newtonsoft.Json;

namespace LootTables.Application.Models
{
    public class DemoItemModel : LootEntryModel
    {
        public string Name { get; set; } = string.Empty;

        public DemoItemModel(string name, double dropRate) : base(dropRate)
        {
            Name = name;
        }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
