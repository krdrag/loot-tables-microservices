using LootTables.Domain.Constants;
using LootTables.Domain.Entities;
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
        private readonly IMongoCollection<LootTableDbEntry> _lootTables;

        public LootTableEntityRepository(LootTableDbContext context)
        {
            _lootTables = context.Database.GetCollection<LootTableDbEntry>(MongoConstants.MongoCollection_LootTables);
        }

        public async Task<LootTableEntity> GetLootTable(string tableId)
        {
            var tables = _lootTables.AsQueryable().ToList();

            var filter = Builders<LootTableDbEntry>.Filter.Where(x => x.Table.TableId.Equals(tableId));
            return (await _lootTables.FindAsync(filter)).FirstOrDefault().Table;




            if (tableId == "loot")
                return LootSeeds.AdvancedScenario();
            else if(tableId == "GachaLoot")
                return GachaSeeds.GetLoot();
            else
                return GachaSeeds.GetDraw10LootTable();
        }

        public void Insert(LootTableEntity entity)
        {
            var entry = new LootTableDbEntry
            {
                Id = GenerateNewId(),
                Table = entity
            };

            _lootTables.InsertOne(entry);
        }

        public async Task InsertAsync(LootTableEntity entity)
        {
            var entry = new LootTableDbEntry
            {
                Id = GenerateNewId(),
                Table = entity
            };

            await _lootTables.InsertOneAsync(entry);
        }

        private static string GenerateNewId() => ObjectId.GenerateNewId().ToString();
    }
}
