using Microsoft.AspNetCore.Mvc;
using Moq;
using PizzaExpress.Controllers;
using PizzaExpress.IService;
using PizzaExpress.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace PizzaAPI.Test
{
    public class PizzaControllerTest
    {
        private readonly Mock<IPizzaService> _mockPizzaService;
        private readonly PizzaController _pizzaController;

        public PizzaControllerTest()
        {
            _mockPizzaService = new Mock<IPizzaService>();
            _pizzaController = new PizzaController(_mockPizzaService.Object);
        }

        [Fact]
        public async Task GetPizzas_ShouldReturnAllPizzas()
        {
            // Arrange
            var pizzas = new List<Pizza> { new Pizza { Id = 1 }, new Pizza { Id = 2 } };
            _mockPizzaService.Setup(service => service.GetPizzas()).ReturnsAsync(pizzas);

            // Act
            var result = await _pizzaController.GetPizzas();

            // Assert
            var actionResult = Assert.IsType<ActionResult<IEnumerable<Pizza>>>(result);
            var returnValue = Assert.IsType<List<Pizza>>(actionResult.Value);
            Assert.Equal(2, returnValue.Count);
        }

        [Fact]
        public async Task GetPizza_ShouldReturnPizzaById()
        {
            // Arrange
            var pizza = new Pizza { Id = 1 };
            _mockPizzaService.Setup(service => service.GetPizza(1)).ReturnsAsync(pizza);

            // Act
            var result = await _pizzaController.GetPizza(1);

            // Assert
            var actionResult = Assert.IsType<ActionResult<Pizza>>(result);
            var returnValue = Assert.IsType<Pizza>(actionResult.Value);
            Assert.Equal(1, returnValue.Id);
        }

        [Fact]
        public async Task CreatePizza_ShouldReturnCreatedPizza()
        {
            // Arrange
            var pizza = new Pizza { Id = 1 };
            _mockPizzaService.Setup(service => service.CreatePizza(pizza)).ReturnsAsync(pizza);

            // Act
            var result = await _pizzaController.CreatePizza(pizza);

            // Assert
            var actionResult = Assert.IsType<ActionResult<Pizza>>(result);
            var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(actionResult.Result);
            var returnValue = Assert.IsType<Pizza>(createdAtActionResult.Value);
            Assert.Equal(1, returnValue.Id);
        }

        [Fact]
        public async Task UpdatePizza_ShouldReturnUpdatedPizza()
        {
            // Arrange
            var pizza = new Pizza { Id = 1 };
            _mockPizzaService.Setup(service => service.UpdatePizza(1, pizza)).ReturnsAsync(pizza);

            // Act
            var result = await _pizzaController.UpdatePizza(1, pizza);

            // Assert
            var actionResult = Assert.IsType<ActionResult<Pizza>>(result);
            var returnValue = Assert.IsType<Pizza>(actionResult.Value);
            Assert.Equal(1, returnValue.Id);
        }

        [Fact]
        public async Task DeletePizza_ShouldReturnNoContent()
        {
            // Arrange
            _mockPizzaService.Setup(service => service.DeletePizza(1)).ReturnsAsync(true);

            // Act
            var result = await _pizzaController.DeletePizza(1);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }
    }
}
