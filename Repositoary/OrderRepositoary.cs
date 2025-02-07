using Microsoft.EntityFrameworkCore;
using PizzaExpress.Data;
using PizzaExpress.IRepositoary;
using PizzaExpress.Models;

namespace PizzaExpress.Repositoary
{
    public class OrderRepositoary : IOrderRepositoary
    {
        private readonly AppDbContext _context;

        public OrderRepositoary(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Order> CreateOrder(Order order)
        {
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();
            return order;

        }

        public async Task<bool> DeleteOrder(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order == null)
            {
                return await Task.FromResult(false);
            }
            _context.Orders.Remove(order);
            return await Task.FromResult(true);
        }

        public async Task<Order> GetOrderById(int id)
        {
            return await Task.FromResult(_context.Orders.Find(id));
        }

        public async Task<List<Order>> GetOrders()
        {
            return await Task.FromResult(_context.Orders.ToList());
        }

        public async Task<Order> UpdateOrder(int id, Order order)
        {
            if (id != order.Id)
            {
                return null;
            }
            _context.Entry(order).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                if (!OrderExist(id))
                {
                    return null;
                }
                else
                {
                    throw ex;
                }
            }
            return await Task.FromResult(order);
        }

        private bool OrderExist(int id)
        {
            return _context.Orders.Any(e => e.Id == id);
        }

        public async Task<Order> UpdateOrder(int id, OrderStatus status)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order == null)
            {
                return null;
            }
            order.Status = status;
            await _context.SaveChangesAsync();
            return order;
        }
    }
}
