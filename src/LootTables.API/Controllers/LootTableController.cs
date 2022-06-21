using LootTables.Application.Models.LootTable;
using LootTables.Application.Services;
using Microsoft.AspNetCore.Mvc;
using LootTables.Application.Models;

namespace LootTables.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LootTableController : ControllerBase
    {
        private readonly ILootService _lootService;

        public LootTableController(ILootService lootService)
        {
            _lootService = lootService;
        }

        [HttpGet]
        public async Task<IEnumerable<string?>> GetLoot()
        {
            return await Task.FromResult(_lootService.GetLoot("test"));
        }
    }
}
