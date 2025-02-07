using Microsoft.AspNetCore.Mvc;
using PizzaExpress.IService;
using PizzaExpress.Models;

namespace PizzaExpress.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrders()
        {
            var orders = await _orderService.GetOrders();
            return orders;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetOrder(int id)
        {
            var order = await _orderService.GetOrderById(id);
            if (order == null)
            {
                return NotFound();
            }
            return order;
        }

        [HttpPost]
        public async Task<ActionResult<Order>> CreateOrder(Order order)
        {
            order.OrderCode = Guid.NewGuid().ToString().Substring(0, 8);
            order.Status = OrderStatus.Registered;
            var result = await _orderService.CreateOrder(order);
            return CreatedAtAction("GetOrder", new { id = result.Id }, result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Order>> UpdateOrder(int id, Order order)
        {
            var result = await _orderService.UpdateOrder(id, order);
            if (result == null)
            {
                return BadRequest();
            }
            return CreatedAtAction("GetOrder", result);
        }

        [HttpPatch("{id}/status")]
        public async Task<ActionResult<Order>> UpdateOrderStatus(int id, [FromBody] OrderStatus status)
        {
            var result = await _orderService.UpdateOrder(id, status);
            if (result == null)
            {
                return BadRequest();
            }
            return CreatedAtAction("GetOrder", result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteOrder(int id)
        {
            var result = await _orderService.DeleteOrder(id);

            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }


    }
}
