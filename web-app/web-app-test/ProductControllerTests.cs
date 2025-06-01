using Microsoft.AspNetCore.Mvc;
using Moq;
using web_app.Business;
using web_app.Controllers;

namespace web_app_test
{
    public class ProductControllerTests
    {
        [Fact]
        public void GetById_ProductExists_ReturnsOkWithProduct()
        {
            // Arrange
            var mockService = new Mock<IProductService>();
            var product = new Product { Id = 1, Name = "Test Product" };
            mockService.Setup(s => s.GetById(1)).Returns(product);

            var controller = new ProductsController(mockService.Object);

            // Act
            var result = controller.GetById(1);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnedProduct = Assert.IsType<Product>(okResult.Value);
            Assert.Equal("Test Product", returnedProduct.Name);
        }
        [Fact]
        public void GetById_ProductDoesNotExist_ReturnsNotFound()
        {
            // Arrange
            var mockService = new Mock<IProductService>();
            mockService.Setup(s => s.GetById(99)).Returns((Product?)null);

            var controller = new ProductsController(mockService.Object);

            // Act
            var result = controller.GetById(99);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }
    }
}
