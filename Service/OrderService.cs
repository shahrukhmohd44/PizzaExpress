using PizzaExpress.IRepositoary;
using PizzaExpress.IService;
using PizzaExpress.Models;

namespace PizzaExpress.Service
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepositoary _orderRepositoary;

        public OrderService(IOrderRepositoary orderRepositoary)
        {
            _orderRepositoary = orderRepositoary;
        }

        public async Task<Order> CreateOrder(Order order)
        {
            var result = await _orderRepositoary.CreateOrder(order);
            return result;
        }

        public async Task<bool> DeleteOrder(int id)
        {
            var result = await _orderRepositoary.DeleteOrder(id);
            return result;
        }

        public async Task<Order> GetOrderById(int id)
        {
            var result = await _orderRepositoary.GetOrderById(id);
            return result;
        }

        public async Task<List<Order>> GetOrders()
        {
            var result = await _orderRepositoary.GetOrders();
            return result;
        }

        public async Task<Order> UpdateOrder(int id, Order order)
        {
            var result = await _orderRepositoary.UpdateOrder(id, order);
            return result;
        }

        public async Task<Order> UpdateOrder(int id, OrderStatus status)
        {
            var result = await _orderRepositoary.UpdateOrder(id, status);
            return result;
        }
    }
}
