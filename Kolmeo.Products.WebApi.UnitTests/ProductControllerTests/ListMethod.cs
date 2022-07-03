using Kolmeo.Products.Domain;
using Kolmeo.Products.Services.Interfaces;
using Kolmeo.Products.WebApi.Controllers;
using Moq;
using NUnit.Framework;

namespace Kolmeo.Products.WebApi.UnitTests.ProductControllerTests
{
    [TestFixture]
    public class ListMethod
    {
        [Test]
        public void ShouldCallServiceOnceWithNoArgumentsAndReturnsProductList()
        {
            // Arrange
            var mockProductService = new Mock<IProductService>();
            var products = new List<Product>
            {
                new Product
                    {
                        Id = 1,
                        Name = "Corn Flakes",
                        Description = "Cereal",
                        Price = 2.98m
                    },
                    new Product
                    {
                        Id = 2,
                        Name = "English Breakfast Tea",
                        Description = "Tea (pack of 100)",
                        Price = 6.37m
                    },
                    new Product
                    {
                        Id = 3,
                        Name = "Chocolate Bar",
                        Description = "Nougat chocolate bar",
                        Price = 1.99m
                    },
            };

            mockProductService.Setup(x => x.GetAll()).Returns(products);

            var sut = new ProductController(mockProductService.Object);

            // Act
            var result = sut.List();

            // Assert
            mockProductService.Verify(u => u.GetAll(), Times.Once, "GetAll method was not called exactly once");
            Assert.AreEqual(products.Count, 3, "Not exactly 3 products were returned");
        }
    }
}
