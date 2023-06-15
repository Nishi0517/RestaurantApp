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
    public class OrderController : ControllerBase
    {
        private readonly RestaurantDbContext _context;

        public OrderController(RestaurantDbContext context)
        {
            _context = context;
        }

        //// GET: api/Order
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<OrderMasters>>> GetOrderMasters()
        //{
        //    if (_context.OrderMasters == null)
        //    {
        //        return NotFound();
        //    }

        //    return await _context.OrderMasters
        //        .Include(x => x.OrderDetails)
        //       // .Include(x => x.Customer)
        //        .ToListAsync();
        //}

        // GET: api/Order
        // GET: api/Order
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderWithCustomer>>> GetOrderMasters()
        {
            if (_context.OrderMasters == null)
            {
                return NotFound();
            }

            var orderMasters = await _context.OrderMasters
                .Include(x => x.OrderDetails)
                .ToListAsync();

            var ordersWithCustomers = orderMasters.Select(o => new OrderWithCustomer
            {
                OrderMasterId = o.OrderMasterId,
                OrderNumber = o.OrderNumber,
                CustomerId = o.CustomerId,
                pMethod = o.pMethod,
                gTotal = o.gTotal,
                Customer = _context.Customers.FirstOrDefault(c => c.CustomerId == o.CustomerId),
                OrderDetails = o.OrderDetails
            });

            return ordersWithCustomers.ToList();
        }





        // GET: api/Order/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderMasters>> GetOrderMasters(long id)
        {
          if (_context.OrderMasters == null)
          {
              return NotFound();
          }
            //get fooditem from order details

            var orderDetails = await (from master in _context.Set<OrderMasters>()
                                      join detail in _context.Set<OrderDetails>()
                                      on master.OrderMasterId equals detail.OrderMasterId
                                      join FoodItems in _context.Set<FoodItems>()
                                      on detail.FoodItemId equals FoodItems.FoodItemId
                                      where master.OrderMasterId == id

                                      select new
                                      {

                                          master.OrderMasterId,
                                          detail.OrderDetailId,
                                          detail.FoodItemId,
                                          detail.Quantity,
                                          detail.FoodItemPrice,
                                          FoodItems.FoodItemName
                                      }).ToListAsync();

            //get order master

            var orderMasters = await (from a in _context.Set<OrderMasters>()
                                     where a.OrderMasterId == id

                                     select new
                                     {
                                         a.OrderMasterId,
                                         a.OrderNumber,
                                         a.CustomerId,
                                         a.pMethod,
                                         a.gTotal,
                                         deletedOrderItemIds = "",
                                         orderDetails = orderDetails
                                     }).FirstOrDefaultAsync();


            //var orderMasters = await _context.OrderMasters.FindAsync(id);

            if (orderMasters == null)
            {
                return NotFound();
            }

            return Ok(orderMasters);
        }

        // PUT: api/Order/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrderMasters(long id, OrderMasters orderMasters)
        {
            if (id != orderMasters.OrderMasterId)
            {
                return BadRequest();
            }

            _context.Entry(orderMasters).State = EntityState.Modified;


            //exisiting food items & newly added food items

            foreach(OrderDetails item in orderMasters.OrderDetails)
            {
                if (item.OrderDetailId == 0)
                    _context.OrderDetails.Add(item);
                else
                    _context.Entry(item).State = EntityState.Modified;
            }

            //deleted food items
            foreach (var i in orderMasters.deletedOrderItemIds.Split(',').Where(x => x != ""))
            {
                
                OrderDetails y = _context.OrderDetails.Find(Convert.ToInt64(i));
                
                _context.OrderDetails.Remove(y);
            }


            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderMastersExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Order
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<OrderMasters>> PostOrderMasters(OrderMasters orderMasters)
        {
          if (_context.OrderMasters == null)
          {
              return Problem("Entity set 'RestaurantDbContext.OrderMasters'  is null.");
          }
            _context.OrderMasters.Add(orderMasters);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrderMasters", new { id = orderMasters.OrderMasterId }, orderMasters);
        }

        // DELETE: api/Order/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrderMasters(long id)
        {
            if (_context.OrderMasters == null)
            {
                return NotFound();
            }
            var orderMasters = await _context.OrderMasters.FindAsync(id);
            if (orderMasters == null)
            {
                return NotFound();
            }

            _context.OrderMasters.Remove(orderMasters);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OrderMastersExists(long id)
        {
            return (_context.OrderMasters?.Any(e => e.OrderMasterId == id)).GetValueOrDefault();
        }
    }
}
