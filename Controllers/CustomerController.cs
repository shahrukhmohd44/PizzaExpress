using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PizzaExpress.Data;
using PizzaExpress.IService;
using PizzaExpress.Models;

namespace customerExpress.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService customerService;

        public CustomerController(ICustomerService service)
        {
            customerService = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> GetPizzas()
        {
            return await customerService.GetCustomers();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetPizza(int id)
        {
            var pizza = await customerService.GetCustomerById(id);
            if (pizza == null)
            {
                return NotFound();
            }
            return pizza;
        }

        [HttpPost]
        public async Task<ActionResult<Customer>> CreatePizza(Customer pizza)
        {
            var result = await customerService.CreateCustomer(pizza);
            return CreatedAtAction("GetPizza", new { id = result.Id }, result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Customer>> UpdatePizza(int id, Customer pizza)
        {
            var result = await customerService.UpdateCustomer(id, pizza);
            return result;
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePizza(int id)
        {
            var result = await customerService.DeleteCustomer(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
