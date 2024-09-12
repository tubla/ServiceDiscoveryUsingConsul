using Deliveries.API.DTOs;
using Deliveries.API.Repositories;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace Deliveries.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeliveriesController(IDeliveriesRepository deliveriesRepository) : ControllerBase
    {

        [HttpGet("orders/{orderId:guid}")] // api/deliveries/orders/xxxxx-xxxxx-xxxxx-xxxxx
        [ProducesResponseType(typeof(IEnumerable<DeliveryDto>), 200)]
        public IActionResult GetDeliveryDetailsOfOrder(Guid orderId)
        {
            if (orderId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(orderId));
            }
            var deliveries = deliveriesRepository.GetDeliveryDetailsOfOrder(orderId);
            return Ok(deliveries.Adapt<IEnumerable<DeliveryDto>>());
        }

        [HttpGet("{deliveryId:guid}")] // api/deliveries/xxxxx-xxxxx-xxxxx-xxxxx
        [ProducesResponseType(typeof(DeliveryDto), 200)]
        public IActionResult GetDeliveryDetails(Guid deliveryId)
        {
            if (deliveryId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(deliveryId));
            }
            var deliveries = deliveriesRepository.GetDeliveryDetails(deliveryId);
            return Ok(deliveries.Adapt<DeliveryDto>());
        }

    }
}
