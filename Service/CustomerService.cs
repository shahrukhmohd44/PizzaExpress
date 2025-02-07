using PizzaExpress.IRepositoary;
using PizzaExpress.IService;
using PizzaExpress.Models;

namespace PizzaExpress.Service
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepositoary _CustomerRepositoary;

        public CustomerService(ICustomerRepositoary CustomerRepositoary)
        {
            _CustomerRepositoary = CustomerRepositoary;
        }

        public async Task<Customer> CreateCustomer(Customer customer)
        {
            var result = await _CustomerRepositoary.CreateCustomer(customer);
            return result;
        }

        public async Task<bool> DeleteCustomer(int id)
        {
            var result = await _CustomerRepositoary.DeleteCustomer(id);
            return result;
        }

        public async Task<Customer> GetCustomerById(int id)
        {
            var result = await _CustomerRepositoary.GetCustomerById(id);
            return result;
        }

        public async Task<List<Customer>> GetCustomers()
        {
            var result = await _CustomerRepositoary.GetCustomers();
            return result;
        }

        public async Task<Customer> UpdateCustomer(int id, Customer customer)
        {
            var result = await _CustomerRepositoary.UpdateCustomer(id, customer);
            return result;
        }
    }
}
