using LootTables.Application.Services;

namespace LootTables.API.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddCustomServices(this IServiceCollection services)
        {
            services.AddScoped<IRandomizerService,RandomizerService>();
            services.AddScoped<ILootService, LootService>();
        }
    }
}
