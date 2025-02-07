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
    public class OrderControllerTest
    {
        private readonly Mock<IOrderService> _mockOrderService;
        private readonly OrderController _orderController;

        public OrderControllerTest()
        {
            _mockOrderService = new Mock<IOrderService>();
            _orderController = new OrderController(_mockOrderService.Object);
        }

        [Fact]
        public async Task GetOrders_ShouldReturnAllOrders()
        {
            // Arrange
            var orders = new List<Order> { new Order { Id = 1 }, new Order { Id = 2 } };
            _mockOrderService.Setup(service => service.GetOrders()).ReturnsAsync(orders);

            // Act
            var result = await _orderController.GetOrders();

            // Assert
            var actionResult = Assert.IsType<ActionResult<IEnumerable<Order>>>(result);
            var returnValue = Assert.IsType<List<Order>>(actionResult.Value);
            Assert.Equal(2, returnValue.Count);
        }

        [Fact]
        public async Task GetOrder_ShouldReturnOrderById()
        {
            // Arrange
            var order = new Order { Id = 1 };
            _mockOrderService.Setup(service => service.GetOrderById(1)).ReturnsAsync(order);

            // Act
            var result = await _orderController.GetOrder(1);

            // Assert
            var actionResult = Assert.IsType<ActionResult<Order>>(result);
            var returnValue = Assert.IsType<Order>(actionResult.Value);
            Assert.Equal(1, returnValue.Id);
        }

        [Fact]
        public async Task CreateOrder_ShouldReturnCreatedOrder()
        {
            // Arrange
            var order = new Order { Id = 1 };
            _mockOrderService.Setup(service => service.CreateOrder(order)).ReturnsAsync(order);

            // Act
            var result = await _orderController.CreateOrder(order);

            // Assert
            var actionResult = Assert.IsType<ActionResult<Order>>(result);
            var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(actionResult.Result);
            var returnValue = Assert.IsType<Order>(createdAtActionResult.Value);
            Assert.Equal(1, returnValue.Id);
        }

        [Fact]
        public async Task UpdateOrder_ShouldReturnUpdatedOrder()
        {
            // Arrange
            var order = new Order { Id = 1 };
            _mockOrderService.Setup(service => service.UpdateOrder(1, order)).ReturnsAsync(order);

            // Act
            var result = await _orderController.UpdateOrder(1, order);

            // Assert
            var actionResult = Assert.IsType<ActionResult<Order>>(result);
            var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(actionResult.Result);
            var returnValue = Assert.IsType<Order>(createdAtActionResult.Value);
            Assert.Equal(1, returnValue.Id);
        }

        [Fact]
        public async Task DeleteOrder_ShouldReturnNoContent()
        {
            // Arrange
            _mockOrderService.Setup(service => service.DeleteOrder(1)).ReturnsAsync(true);

            // Act
            var result = await _orderController.DeleteOrder(1);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }
    }
}
