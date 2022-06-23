using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LootTables.Domain.Entities
{
    public class LootTableEntity
    {
        public IEnumerable<LootTableEntity> SubTables { get; set; } = Enumerable.Empty<LootTableEntity>();

        public IEnumerable<LootEntity> Loot { get; set; } = Enumerable.Empty<LootEntity>();

        public int DropCount { get; set; }
        public double DropRate { get; set; }
        public bool IsEnabled { get; set; } = true;
    }
}
