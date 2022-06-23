using LootTables.Domain.Entities.LootTable;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace LootTables.Domain.Entities
{
    /// <summary>
    /// Container class for storing tables in DB
    /// </summary>
    public class LootTableDbEntry
    {

        /// <summary>
        /// Id required for mongoDB
        /// </summary>
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = String.Empty;

        /// <summary>
        /// Loot table stored in DB
        /// </summary>
        public LootTableEntity Table { get; set; } = new LootTableEntity();
    }
}
