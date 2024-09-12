using Deliveries.API.Models;

namespace Deliveries.API.Repositories
{
    public interface IDeliveriesRepository
    {
        IEnumerable<Delivery> GetDeliveryDetailsOfOrder(Guid orderId);
        Delivery GetDeliveryDetails(Guid deliveryId);
    }
}
