using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestaurantAPI.Models;

namespace RestaurantAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodItemController : ControllerBase
    {
        private readonly RestaurantDbContext _context;

        public FoodItemController(RestaurantDbContext context)
        {
            _context = context;
        }

        // GET: api/FoodItem
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FoodItems>>> GetFoodItems()
        {
          if (_context.FoodItems == null)
          {
              return NotFound();
          }
            return await _context.FoodItems.ToListAsync();
        }

        //// GET: api/FoodItem/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<FoodItems>> GetFoodItems(int id)
        //{
        //  if (_context.FoodItems == null)
        //  {
        //      return NotFound();
        //  }
        //    var foodItems = await _context.FoodItems.FindAsync(id);

        //    if (foodItems == null)
        //    {
        //        return NotFound();
        //    }

        //    return foodItems;
        //}

        //// PUT: api/FoodItem/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutFoodItems(int id, FoodItems foodItems)
        //{
        //    if (id != foodItems.FoodItemId)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(foodItems).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!FoodItemsExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        //// POST: api/FoodItem
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<FoodItems>> PostFoodItems(FoodItems foodItems)
        //{
        //  if (_context.FoodItems == null)
        //  {
        //      return Problem("Entity set 'RestaurantDbContext.FoodItems'  is null.");
        //  }
        //    _context.FoodItems.Add(foodItems);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetFoodItems", new { id = foodItems.FoodItemId }, foodItems);
        //}

        //// DELETE: api/FoodItem/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteFoodItems(int id)
        //{
        //    if (_context.FoodItems == null)
        //    {
        //        return NotFound();
        //    }
        //    var foodItems = await _context.FoodItems.FindAsync(id);
        //    if (foodItems == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.FoodItems.Remove(foodItems);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        //private bool FoodItemsExists(int id)
        //{
        //    return (_context.FoodItems?.Any(e => e.FoodItemId == id)).GetValueOrDefault();
        //}
    }
}
