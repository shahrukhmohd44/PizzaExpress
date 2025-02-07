using PizzaExpress.Data;
using PizzaExpress.IRepositoary;
using PizzaExpress.Models;

namespace PizzaExpress.Repositoary
{
    public class CustomerRepositoary : ICustomerRepositoary
    {
        private readonly AppDbContext _context;

        public CustomerRepositoary(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Customer> CreateCustomer(Customer Customer)
        {
            _context.Customers.Add(Customer);
            await _context.SaveChangesAsync();
            return Customer;
        }

        public async Task<bool> DeleteCustomer(int id)
        {

            var Customer = await _context.Customers.FindAsync(id);
            if (Customer == null)
            {
                return await Task.FromResult(false);
            }
            _context.Customers.Remove(Customer);
            return await Task.FromResult(true);
        }

        public async Task<Customer> GetCustomerById(int id)
        {
            return await Task.FromResult(_context.Customers.Find(id));
        }

        public async Task<List<Customer>> GetCustomers()
        {
            return await Task.FromResult(_context.Customers.ToList());
        }

        public async Task<Customer> UpdateCustomer(int id, Customer Customer)
        {
            var existingCustomer = await _context.Customers.FindAsync(id);
            if (existingCustomer == null)
            {
                return null;
            }
            existingCustomer.Name = Customer.Name;
            existingCustomer.Address = Customer.Address;
            existingCustomer.Phone = Customer.Phone;
            _context.Customers.Update(existingCustomer);
            return await Task.FromResult(existingCustomer);
        }
    }
}
