namespace LootTables.Domain.Exceptions
{
    public class EnvVariableNotFoundException : Exception
    {
        public EnvVariableNotFoundException(string? connString, string? userName, string? password)
            : base($"Required environment variable not found. Provided variables: {connString}, {userName}, {password}")
        {

        }
    }
}
