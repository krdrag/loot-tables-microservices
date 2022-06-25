namespace LootTables.API.Middleware
{
    public class RequestError
    {
        public string ErrorCode { get; set; } = string.Empty;
        public string ErrorMessage { get; set; } = string.Empty;
        public string TranslatedErrorMessage { get; set; } = string.Empty;
        public string ErrorDetails { get; set; } = string.Empty;
    }
}
