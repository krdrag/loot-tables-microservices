using LootTables.Application.Models;
using LootTables.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace LootTables.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LootTableController : ControllerBase
    {
        private readonly ILootService _lootService;
        private readonly ILogger<LootTableController> _logger;

        public LootTableController(ILootService lootService, ILogger<LootTableController> logger)
        {
            _lootService = lootService;
            _logger = logger;
        }

        [HttpGet("loot")]
        public async Task<IEnumerable<ItemModel>> GetLoot()
        {
            _logger.LogInformation(Environment.GetEnvironmentVariable("MONGO_INITDB_ROOT_PASSWORD"));


            return await Task.FromResult(_lootService.GetLoot("test"));
        }

        [HttpGet("gacha")]
        public async Task<IEnumerable<ItemModel>> GetGacha()
        {
            return await Task.FromResult(_lootService.GetGacha());
        }
    }
}
