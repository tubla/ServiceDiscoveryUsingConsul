using Mapster;
using Microsoft.AspNetCore.Mvc;
using Orders.API.DTOs;
using Orders.API.Repositories;

namespace Orders.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController(IOrderRepository orderRepository) : ControllerBase
    {
        [HttpGet("customers/{customerId:guid}")]
        [ProducesResponseType(typeof(IEnumerable<OrderDto>), 200)]
        public IActionResult GetOrders(Guid customerId)
        {
            if (customerId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(customerId));
            }

            var orders = orderRepository.GetOrders(customerId);
            return Ok(orders.Adapt<IEnumerable<OrderDto>>());
        }

        [HttpGet("{orderId:guid}")]
        [ProducesResponseType(typeof(OrderDto), 200)]
        public IActionResult GetOrder(Guid orderId)
        {
            if (orderId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(orderId));
            }

            var orders = orderRepository.GetOrder(orderId);
            return Ok(orders.Adapt<OrderDto>());
        }
    }
}
