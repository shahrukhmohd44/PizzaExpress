using customerExpress.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using PizzaExpress.IService;
using PizzaExpress.Models;

namespace PizzaAPI.Test
{
    public class CustomerControllerTest
    {
        private readonly Mock<ICustomerService> _mockCustomerService;
        private readonly CustomerController _customerController;

        public CustomerControllerTest()
        {
            _mockCustomerService = new Mock<ICustomerService>();
            _customerController = new CustomerController(_mockCustomerService.Object);
        }

        [Fact]
        public async Task GetCustomers_ShouldReturnAllCustomers()
        {
            // Arrange
            var customers = new List<Customer> { new Customer { Id = 1 }, new Customer { Id = 2 } };
            _mockCustomerService.Setup(service => service.GetCustomers()).ReturnsAsync(customers);

            // Act
            var result = await _customerController.GetPizzas();

            // Assert
            var actionResult = Assert.IsType<ActionResult<IEnumerable<Customer>>>(result);
            var returnValue = Assert.IsType<List<Customer>>(actionResult.Value);
            Assert.Equal(2, returnValue.Count);
        }

        [Fact]
        public async Task GetCustomer_ShouldReturnCustomerById()
        {
            // Arrange
            var customer = new Customer { Id = 1 };
            _mockCustomerService.Setup(service => service.GetCustomerById(1)).ReturnsAsync(customer);

            // Act
            var result = await _customerController.GetPizza(1);

            // Assert
            var actionResult = Assert.IsType<ActionResult<Customer>>(result);
            var returnValue = Assert.IsType<Customer>(actionResult.Value);
            Assert.Equal(1, returnValue.Id);
        }

        [Fact]
        public async Task CreateCustomer_ShouldReturnCreatedCustomer()
        {
            // Arrange
            var customer = new Customer { Id = 1 };
            _mockCustomerService.Setup(service => service.CreateCustomer(customer)).ReturnsAsync(customer);

            // Act
            var result = await _customerController.CreatePizza(customer);

            // Assert
            var actionResult = Assert.IsType<ActionResult<Customer>>(result);
            var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(actionResult.Result);
            var returnValue = Assert.IsType<Customer>(createdAtActionResult.Value);
            Assert.Equal(1, returnValue.Id);
        }

        [Fact]
        public async Task UpdateCustomer_ShouldReturnUpdatedCustomer()
        {
            // Arrange
            var customer = new Customer { Id = 1 };
            _mockCustomerService.Setup(service => service.UpdateCustomer(1, customer)).ReturnsAsync(customer);

            // Act
            var result = await _customerController.UpdatePizza(1, customer);

            // Assert
            var actionResult = Assert.IsType<ActionResult<Customer>>(result);
            var returnValue = Assert.IsType<Customer>(actionResult.Value);
            Assert.Equal(1, returnValue.Id);
        }

        [Fact]
        public async Task DeleteCustomer_ShouldReturnNoContent()
        {
            // Arrange
            _mockCustomerService.Setup(service => service.DeleteCustomer(1)).ReturnsAsync(true);

            // Act
            var result = await _customerController.DeletePizza(1);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }
    }
}
