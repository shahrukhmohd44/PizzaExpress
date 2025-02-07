using Microsoft.AspNetCore.Mvc;
using PizzaExpress.IService;
using PizzaExpress.Models;

namespace PizzaExpress.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PizzaController : ControllerBase
    {
        private readonly IPizzaService pizzaService;

        public PizzaController(IPizzaService service)
        {
            pizzaService = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pizza>>> GetPizzas()
        {
            return await pizzaService.GetPizzas();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Pizza>> GetPizza(int id)
        {
            var pizza = await pizzaService.GetPizza(id);
            if (pizza == null)
            {
                return NotFound();
            }
            return pizza;
        }

        [HttpPost]
        public async Task<ActionResult<Pizza>> CreatePizza(Pizza pizza)
        {
            var result = await pizzaService.CreatePizza(pizza);
            return CreatedAtAction("GetPizza", new { id = result.Id }, result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Pizza>> UpdatePizza(int id, Pizza pizza)
        {
            var result = await pizzaService.UpdatePizza(id, pizza);
            return result;
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePizza(int id)
        {
            var result = await pizzaService.DeletePizza(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
