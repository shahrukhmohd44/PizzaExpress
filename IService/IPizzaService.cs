using PizzaExpress.Models;

namespace PizzaExpress.IService
{
    public interface IPizzaService
    {
        Task<List<Pizza>> GetPizzas();
        Task<Pizza> GetPizza(int id);
        Task<Pizza> CreatePizza(Pizza pizza);
        Task<Pizza> UpdatePizza(int id, Pizza pizza);
        Task<bool> DeletePizza(int id);
    }
}
