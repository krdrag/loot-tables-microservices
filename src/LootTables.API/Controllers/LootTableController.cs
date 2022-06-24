using LootTables.Application.Models;
using LootTables.Application.Services;
using LootTables.Domain.Constants;
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
            return await _lootService.GetLoot(MongoConstants.MongoTable_LootTable);
        }

        [HttpGet("gacha")]
        public async Task<IEnumerable<ItemModel>> GetGacha()
        {
            return await _lootService.GetLoot(MongoConstants.MongoTable_GachaTable);
        }
    }
}
