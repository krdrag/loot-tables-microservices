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

        public LootTableController(ILootService lootService)
        {
            _lootService = lootService;
        }

        [HttpGet]
        public async Task<IEnumerable<ItemModel>> GetLoot()
        {
            return await Task.FromResult(_lootService.GetLoot("test"));
        }
    }
}
