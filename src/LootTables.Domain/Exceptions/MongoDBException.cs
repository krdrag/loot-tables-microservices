namespace LootTables.Domain.Exceptions
{
    public class MongoDBException : Exception
    {
        public MongoDBException(string text)
            : base(text)
        {

        }
    }
}
