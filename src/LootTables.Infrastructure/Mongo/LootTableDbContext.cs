using LootTables.Domain.Constants;
using LootTables.Domain.Exceptions;
using LootTables.Infrastructure.Extensions;
using LootTables.Infrastructure.Repositories;
using MongoDB.Driver;

namespace LootTables.Infrastructure.Mongo
{
    public class LootTableDbContext
    {
        private readonly MongoClient _client;
        private readonly IMongoDatabase _database;

        public LootTableDbContext()
        {
            string connstring = GetConnectionString();

            _client = new MongoClient(connstring);
            _database = _client.GetDatabase(MongoConstants.MongoDatabase_LootTables);

            Seed();
        }

        private static string GetConnectionString()
        {
            var connstring = Environment.GetEnvironmentVariable(MongoConstants.MongoConnectionStringEnvVar);
            var userName = Environment.GetEnvironmentVariable(MongoConstants.MongoUserNameEnvVar);
            var password = Environment.GetEnvironmentVariable(MongoConstants.MongoPasswordEnvVar);

            if (string.IsNullOrEmpty(connstring) || string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password))
                throw new EnvVariableNotFoundException(connstring, userName, password);

            connstring = string.Format(connstring, userName, password);
            return connstring;
        }

        public IMongoClient Client => _client;

        public IMongoDatabase Database => _database;

        private void Seed()
        {
            var collExists = _database.CollectionExists(MongoConstants.MongoCollection_LootTables);

            if (collExists)
                return;

            _database.CreateCollection(MongoConstants.MongoCollection_LootTables);

            var repo = new LootTableEntityRepository(this);
            repo.Insert(SeedData.Seed.GetLoot());
            repo.Insert(SeedData.Seed.GetGachaDrops());
        }
    }
}
