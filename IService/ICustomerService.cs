using PizzaExpress.Models;

namespace PizzaExpress.IService
{
    public interface ICustomerService
    {
        Task<Customer> GetCustomerById(int id);
        Task<List<Customer>> GetCustomers();
        Task<Customer> CreateCustomer(Customer customer);
        Task<Customer> UpdateCustomer(int id, Customer customer);
        Task<bool> DeleteCustomer(int id);
    }
}
