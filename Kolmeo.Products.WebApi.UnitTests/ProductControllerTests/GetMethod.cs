using Kolmeo.Products.Domain;
using Kolmeo.Products.Services.Interfaces;
using Kolmeo.Products.WebApi.Controllers;
using Moq;
using NUnit.Framework;

namespace Kolmeo.Products.WebApi.UnitTests.ProductControllerTests
{
    [TestFixture]
    public class GetMethod
    {
        [Test]
        public void ShouldCallServiceOnceWithCorrectProductIdAndReturnProduct()
        {
            // Arrange
            var productId = 1;
            var mockProductService = new Mock<IProductService>();
            var product = new Product { Id = productId };
            mockProductService.Setup(x => x.Get(It.IsAny<int>())).Returns(product);

            var sut = new ProductController(mockProductService.Object);

            // Act
            var result = sut.Get(productId);

            // Assert
            mockProductService.Verify(u => u.Get(productId), Times.Once, "Get method was not called once with the correct ProductId");
            Assert.AreEqual(productId, result.Id, "Product Id does not match");
        }
    }
}
