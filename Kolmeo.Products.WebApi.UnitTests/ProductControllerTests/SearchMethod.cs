using Kolmeo.Products.Domain;
using Kolmeo.Products.Services.Interfaces;
using Kolmeo.Products.WebApi.Controllers;
using Moq;
using NUnit.Framework;

namespace Kolmeo.Products.WebApi.UnitTests.ProductControllerTests
{
    public class SearchMethod
    {
        [Test]
        public void ShouldCallServiceOnceWithCorrectArgumentsAndReturnListOfProducts()
        {
            // Arrange
            var mockProductService = new Mock<IProductService>();
            var name = "Orange";
            var description = "marmalade";
            var minPrice = 3m;
            var maxPrice = 4m;
            var products = new List<Product>
            {
                new Product
                    {
                        Id = 1,
                        Name = "Orange Marmalade",
                        Description = "Jar of marmalade",
                        Price = 3.98m
                    },
            };

            mockProductService.Setup(x => x.Search(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<decimal>(), It.IsAny<decimal>())).Returns(products);

            var sut = new ProductController(mockProductService.Object);

            // Act
            var results = sut.Search(name, description, minPrice, maxPrice);

            // Assert
            mockProductService.Verify(u => u.Search(name, description, minPrice, maxPrice), Times.Once, "Search method was not called exactly once");
        }
    }
}
