using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProducersOrders.Data;
using ProducersOrders.RabbitMQ;

namespace ProducersOrders.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly OrderDbContext _context;
        private readonly IMessageProducer _messagePublisher;

        public OrdersController(OrderDbContext context, IMessageProducer messagePublisher)
        {
            _context = context;
            _messagePublisher = messagePublisher;
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder(Order order)
        {
          
            _context.Order.Add(order);

            await _context.SaveChangesAsync();

            _messagePublisher.SendMessage(order);

            return Ok(new { id = order.Id });
        }
    }
}
