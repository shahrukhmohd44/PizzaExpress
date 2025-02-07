using PizzaExpress.Data;
using PizzaExpress.IRepositoary;
using PizzaExpress.Models;

namespace PizzaExpress.Repositoary
{
    public class PizzaRepositoary : IPizzaRepositoary
    {
        private readonly AppDbContext _context;

        public PizzaRepositoary(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Pizza> CreatePizza(Pizza pizza)
        {
            _context.Pizzas.Add(pizza);
            await _context.SaveChangesAsync();
            return pizza;
        }

        public async Task<bool> DeletePizza(int id)
        {

            var pizza = await _context.Pizzas.FindAsync(id);
            if (pizza == null)
            {
                return await Task.FromResult(false);
            }
            _context.Pizzas.Remove(pizza);
            return await Task.FromResult(true);
        }

        public async Task<Pizza> GetPizza(int id)
        {
            return await Task.FromResult(_context.Pizzas.Find(id));
        }

        public async Task<List<Pizza>> GetPizzas()
        {
            return await Task.FromResult(_context.Pizzas.ToList());
        }

        public async Task<Pizza> UpdatePizza(int id, Pizza pizza)
        {
            var existingPizza = await _context.Pizzas.FindAsync(id);
            if (existingPizza == null)
            {
                return null;
            }
            existingPizza.Name = pizza.Name;
            existingPizza.Price = pizza.Price;
            existingPizza.Description = pizza.Description;
            _context.Pizzas.Update(existingPizza);
            return await Task.FromResult(existingPizza);
        }
    }
}
