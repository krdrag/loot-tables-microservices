using LootTables.Domain.Constants;
using LootTables.Domain.Entities;
using LootTables.Domain.Interfaces;
using LootTables.Infrastructure.Mongo;
using MongoDB.Bson;
using MongoDB.Driver;

namespace LootTables.Infrastructure.Repositories
{
    public class LootTableEntityRepository : ILootTableEntityRepository
    {
        private readonly IMongoCollection<MasterTableEntity> _lootTables;

        public LootTableEntityRepository(LootTableDbContext context)
        {
            _lootTables = context.Database.GetCollection<MasterTableEntity>(MongoConstants.MongoCollection_LootTables);
        }

        public async Task<MasterTableEntity?> GetLootTableAsync(string tableId)
        {
            var filter = Builders<MasterTableEntity>.Filter.Where(x => x.TableId.Equals(tableId));
            return (await _lootTables.FindAsync(filter)).FirstOrDefault();
        }

        public void Insert(MasterTableEntity entity)
        {
            entity.Id = GenerateNewId();

            _lootTables.InsertOne(entity);
        }

        private static string GenerateNewId() => ObjectId.GenerateNewId().ToString();
    }
}
