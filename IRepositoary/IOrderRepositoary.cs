using PizzaExpress.Models;

namespace PizzaExpress.IRepositoary
{
    public interface IOrderRepositoary
    {
        Task<Order> GetOrderById(int id);
        Task<List<Order>> GetOrders();
        Task<Order> CreateOrder(Order order);
        Task<Order> UpdateOrder(int id, Order order);
        Task<Order> UpdateOrder(int id, OrderStatus status);
        Task<bool> DeleteOrder(int id);
    }
}
