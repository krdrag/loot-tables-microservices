namespace LootTables.Domain.Constants
{
    public class MongoConstants
    {
        public static readonly string MongoConnectionStringEnvVar = "MONGO_CONN_STRING";
        public static readonly string MongoUserNameEnvVar = "MONGO_INITDB_ROOT_USERNAME";
        public static readonly string MongoPasswordEnvVar = "MONGO_INITDB_ROOT_PASSWORD";

        public static readonly string MongoDatabase_LootTables = "LootSystem";
        public static readonly string MongoCollection_LootTables = "LootTables";
    }
}
