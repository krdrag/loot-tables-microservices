using LootTables.Domain.Constants;
using LootTables.Domain.Entities;
using LootTables.Domain.Entities.LootTable;
using LootTables.Domain.Exceptions;
using LootTables.Infrastructure.Repositories;
using LootTables.Infrastructure.Seed;
using MongoDB.Driver;

namespace LootTables.Infrastructure.Mongo
{
    public class LootTableDbContext
    {
        private readonly MongoClient _client;
        private readonly IMongoDatabase _database;

        public LootTableDbContext()
        {
            var connstring = Environment.GetEnvironmentVariable(MongoConstants.MongoConnectionStringEnvVar);
            var userName = Environment.GetEnvironmentVariable(MongoConstants.MongoUserNameEnvVar);
            var password = Environment.GetEnvironmentVariable(MongoConstants.MongoPasswordEnvVar);

            if (string.IsNullOrEmpty(connstring) || string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password))
                throw new EnvironmentVariableNotFoundException(connstring, userName, password);

            connstring = string.Format(connstring, userName, password);

            _client = new MongoClient(connstring);
            _database = _client.GetDatabase(MongoConstants.MongoDatabase_LootTables);

            //Seed();
        }

        public IMongoClient Client => _client;

        public IMongoDatabase Database => _database;

        private void Seed()
        {
            var collection = _database.GetCollection<MasterTableEntity>(MongoConstants.MongoCollection_LootTables);
            _database.CreateCollection(MongoConstants.MongoCollection_LootTables);

            var repo = new LootTableEntityRepository(this);
            repo.Insert(LootSeeds.BasicScenario());
        }
    }
}
