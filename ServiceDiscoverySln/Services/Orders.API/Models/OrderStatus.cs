namespace Orders.API.Models
{
    public enum OrderStatus
    {
        Created = 1,
        Processing = 2,
        Delivering = 3,
        Finished = 4,
        Cancelled = 5
    }
}
