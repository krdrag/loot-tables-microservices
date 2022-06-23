using LootTables.Domain.Constants;
using LootTables.Domain.Entities.LootTable;
using LootTables.Domain.Interfaces;
using LootTables.Infrastructure.Mongo;
using LootTables.Infrastructure.Seed;
using MongoDB.Bson;
using MongoDB.Driver;

namespace LootTables.Infrastructure.Repositories
{
    public class LootTableEntityRepository : ILootTableEntityRepository
    {
        private readonly IMongoCollection<LootTableEntity> _lootTables;

        public LootTableEntityRepository(LootTableDbContext context)
        {
            _lootTables = context.Database.GetCollection<LootTableEntity>(MongoConstants.MongoCollection_LootTables);
        }

        public LootTableEntity GetLootTable(string tableId)
        {
            if (tableId == "loot")
                return LootSeeds.AdvancedScenario();
            else if(tableId == "GachaLoot")
                return GachaSeeds.GetLoot();
            else
                return GachaSeeds.GetDraw10LootTable();
        }

        public void Insert(LootTableEntity entity)
        {
            entity.Id = GenerateNewId();

            _lootTables.InsertOne(entity);
        }

        public async Task InsertAsync(LootTableEntity entity)
        {
            entity.Id = GenerateNewId();

            await _lootTables.InsertOneAsync(entity);
        }

        private static string GenerateNewId() => ObjectId.GenerateNewId().ToString();
    }
}
