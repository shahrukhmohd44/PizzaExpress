using PizzaExpress.IRepositoary;
using PizzaExpress.IService;
using PizzaExpress.Models;

namespace PizzaExpress.Service
{
    public class PizzaService : IPizzaService
    {
        private readonly IPizzaRepositoary _pizzaRepositoary;

        public PizzaService(IPizzaRepositoary pizzaRepositoary)
        {
            _pizzaRepositoary = pizzaRepositoary;
        }

        public async Task<Pizza> CreatePizza(Pizza pizza)
        {
            var result = await _pizzaRepositoary.CreatePizza(pizza);
            return result;
        }

        public async Task<bool> DeletePizza(int id)
        {
            var result = await _pizzaRepositoary.DeletePizza(id);
            return result;
        }

        public async Task<Pizza> GetPizza(int id)
        {
            var result = await _pizzaRepositoary.GetPizza(id);
            return result;
        }

        public async Task<List<Pizza>> GetPizzas()
        {
            var result = await _pizzaRepositoary.GetPizzas();
            return result;
        }

        public async Task<Pizza> UpdatePizza(int id, Pizza pizza)
        {
            var result = await _pizzaRepositoary.UpdatePizza(id, pizza);
            return result;
        }
    }
}
