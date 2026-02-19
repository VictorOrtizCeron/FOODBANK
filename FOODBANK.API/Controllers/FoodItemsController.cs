using FOODBANK.Data;
using FOODBANK.Data.Context;
using FOODBANK.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FOODBANK.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodItemsController : ControllerBase
    {
        private readonly FoodbankDbContext _context;

        public FoodItemsController(FoodbankDbContext context)
        {
            _context = context;
        }

        // GET: api/FoodItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FoodItem>>> GetAll()
        {
            return await _context.FoodItems.ToListAsync();
        }

        // GET: api/FoodItems/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<FoodItem>> GetById(int id)
        {
            var foodItem = await _context.FoodItems
                .FirstOrDefaultAsync(f => f.FoodItemId == id);

            if (foodItem == null)
                return NotFound();

            return foodItem;
        }

        // GET: api/FoodItems/name/rice
        [HttpGet("name/{name}")]
        public async Task<ActionResult<IEnumerable<FoodItem>>> GetByName(string name)
        {
            var items = await _context.FoodItems
                .Where(f => f.Name.Contains(name))
                .ToListAsync();

            if (!items.Any())
                return NotFound();

            return items;
        }
    }
}
