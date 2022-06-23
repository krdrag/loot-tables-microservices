using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace LootTables.Domain.Entities
{
    /// <summary>
    /// Main table containing sub loot tables 
    /// </summary>
    public class MasterTableEntity
    {
        /// <summary>
        /// Id required for mongoDB
        /// </summary>
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = String.Empty;

        /// <summary>
        /// Id used to recognize separate tables
        /// </summary>
        public string TableId { get; set; } = string.Empty;

        /// <summary>
        /// Loot table stored in DB
        /// </summary>
        public IEnumerable<LootTableEntity> LootTables { get; set; } = Enumerable.Empty<LootTableEntity>();

        /// <summary>
        /// Loot table stored in DB
        /// </summary>
        public IEnumerable<LootEntity> GuranteedLoot { get; set; } = Enumerable.Empty<LootEntity>();
    }
}
