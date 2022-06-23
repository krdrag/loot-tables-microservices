namespace LootTables.Domain.Exceptions
{
    public class EnvironmentVariableNotFoundException : Exception
    {
        public EnvironmentVariableNotFoundException(string? connString, string? userName, string? password)
            : base($"Required environment variable not found. Provided variables: {connString}, {userName}, {password}")
        {

        }
    }
}
