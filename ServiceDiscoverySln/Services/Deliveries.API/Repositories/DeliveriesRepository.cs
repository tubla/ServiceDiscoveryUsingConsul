using Deliveries.API.Models;

namespace Deliveries.API.Repositories
{

    public class DeliveriesRepository : IDeliveriesRepository
    {
        private static readonly Random _random = new Random();

        public Delivery GetDeliveryDetails(Guid deliveryId)
        {
            return CreateDelivery(deliveryId, Guid.NewGuid());
        }

        public IEnumerable<Delivery> GetDeliveryDetailsOfOrder(Guid orderId)
        {
            var numberOfDeliveries = _random.Next(0, 10);
            var deliveryDetails = new List<Delivery>(numberOfDeliveries);
            for (var i = 0; i < numberOfDeliveries; i++)
            {
                var delivery = CreateDelivery(Guid.NewGuid(), orderId);
                deliveryDetails.Add(delivery);
            }

            return deliveryDetails;
        }


        private static Delivery CreateDelivery(Guid deliveryId, Guid orderId)
        {
            var delivery = new Delivery
            {
                Id = deliveryId,
                Comment = $"This is the delivery for the order {orderId}",
                Contact = _random.Next(1, 9) + _random.Next(5, 9) + "423" + _random.Next(1, 5) + "14" + _random.Next(1, 9) + _random.Next(1, 9),
                FromAddress = new Address { Id = Guid.NewGuid(), City = "Bangalore", StreetAddress = "R J Nagar", PostalCode = "565456", Country = "India" },
                ToAddress = new Address { Id = Guid.NewGuid(), City = "Kolkata", StreetAddress = "Barakhamba Street", PostalCode = "709898", Country = "India" },
                OrderId = orderId
            };

            return delivery;
        }
    }
}
