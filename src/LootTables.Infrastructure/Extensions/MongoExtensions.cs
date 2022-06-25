using MongoDB.Driver;

namespace LootTables.Infrastructure.Extensions
{
    public static class MongoExtensions
    {
        public static async Task<bool> CollectionExistsAsync(this IMongoDatabase database, string name)
        {
            var colNames = await (await database.ListCollectionNamesAsync()).ToListAsync();

            return colNames.Contains(name);
        }

        public static bool CollectionExists(this IMongoDatabase database, string name)
        {
            var colNames = database.ListCollectionNames().ToList();

            return colNames.Contains(name);
        }
    }
}
