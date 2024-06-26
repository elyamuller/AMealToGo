using AMealToGo.models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AMealToGo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderStatusController : ControllerBase
    {
        private readonly MealToGoDbContext _context;

        public OrderStatusController(MealToGoDbContext context)
        {
            _context = context;
        }
        [HttpPost]
        public async Task<ActionResult<Order>> ChangeOrderStatus(int orderId,int statusId )
        {
            Order? order = await _context.Orders.Include(i => i.OrderStatus).Where(x =>  x.OrderId == orderId).FirstOrDefaultAsync();
            if (order != null) 
            {
                order.OrderStatusId = statusId;

                await _context.SaveChangesAsync();
                return Ok(order);
            }
            return NotFound();
            
        }
    }
}
