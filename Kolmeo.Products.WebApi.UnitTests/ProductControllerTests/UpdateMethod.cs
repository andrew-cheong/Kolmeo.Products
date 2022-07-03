using Kolmeo.Products.Services.Interfaces;
using Kolmeo.Products.WebApi.Controllers;
using Moq;
using NUnit.Framework;

namespace Kolmeo.Products.WebApi.UnitTests.ProductControllerTests
{
    [TestFixture]
    public class UpdateMethod
    {
        [Test]
        public void ShouldCallServiceOnceWithCorrectArguments()
        {
            // Arrange
            var productId = 1;
            var name = "Orange Marmalade";
            var description = "Jar of marmalade";
            var price = 3.99m;
            var mockProductService = new Mock<IProductService>();

            mockProductService.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<decimal>()));

            var sut = new ProductController(mockProductService.Object);

            // Act
            sut.Update(productId, name, description, price);

            // Assert
            mockProductService.Verify(u => u.Update(productId, name, description, price), Times.Once, "Update method was not called exactly once");
        }
    }
}
