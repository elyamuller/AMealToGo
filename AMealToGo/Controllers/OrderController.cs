using AMealToGo.models;
using AMealToGo.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AMealToGo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly MealToGoDbContext _context;

        public OrderController(MealToGoDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task <ActionResult<IEnumerable< Order>>> GetOrders() 
        {
        return await _context.Orders
                .Include(r => r.Customer)
                .Include(i => i.OrderItems).ThenInclude(oi => oi.Product)
                .Include(i => i.OrderStatus)
                .ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Order>> PostOrderItems(OrderView orderView)
        {
            List<OrderItem> orderItems = new List<OrderItem>();
            if (orderView.CustomerId != null && !_context.Customer.Any(t => t.CustomerId == orderView.CustomerId))
            {
                return NotFound("CustomerId does not Exists");
            }
            foreach (var item in orderView.Items)
            {
                if (!ProductExists(item.ProductId))
                {
                    return BadRequest("This product " + item.ProductId + " does not Exist");
                }
                orderItems.Add(new OrderItem
                {
                    ProductId = item.ProductId,
                    Quantity = item.Quantity
                });
            }
            Order newOrder = new Order
            {
                OrderItems = orderItems,
                OrderStatusId = (int)Status.OrderPlaced,
                DateOrdered = DateTime.Now,
                CustomerId = orderView.CustomerId              
            };
            _context.Orders.Add(newOrder);
            await _context.SaveChangesAsync();
            var order  = await _context.Orders.Include( a => a.OrderItems).ThenInclude(b => b.Product).FirstOrDefaultAsync(x => x.OrderId == newOrder.OrderId);
            order.Customer = order.Customer;
            order.OrderTotal = order.OrderItems.Sum(o => o.Quantity * o.Product.Price);
            await _context.SaveChangesAsync();
            return Ok(order);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> OrderStatus(int id, Order order)
        {
            if (id != order.OrderId)
            {
                return BadRequest();
            }
            else
            {
                _context.Entry(OrderStatus).State = EntityState.Modified;
            }
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderExists(id))
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

        private bool OrderExists(int id)
        {
            return _context.Orders.Any(x => x.OrderId == id);
        }
        private bool ProductExists(int id)
        {
            return _context.Product.Any(e => e.ProductId == id);
        }
    }
}
