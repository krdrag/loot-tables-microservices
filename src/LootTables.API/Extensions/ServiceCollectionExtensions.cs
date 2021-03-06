using LootTables.Application.Services;
using LootTables.Domain.Interfaces;
using LootTables.Infrastructure.Mongo;
using LootTables.Infrastructure.Repositories;

namespace LootTables.API.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddCustomServices(this IServiceCollection services)
        {
            services.AddSingleton<LootTableDbContext>();

            // Repositories
            services.AddScoped<ILootTableEntityRepository, LootTableEntityRepository>();

            // Services
            services.AddScoped<IRandomizerService,RandomizerService>();
            services.AddScoped<ILootService, LootService>();
        }
    }
}
