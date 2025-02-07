namespace PizzaExpress.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string OrderCode { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public List<OrderItem> Items { get; set; }
        public OrderStatus Status { get; set; }
    }

    public enum OrderStatus
    {
        Registered,
        Prepartion,
        ReadyToBeDelivered,
        Delivered
    }
}
