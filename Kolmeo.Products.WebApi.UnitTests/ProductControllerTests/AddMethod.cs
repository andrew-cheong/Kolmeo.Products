using Kolmeo.Products.Services.Interfaces;
using Kolmeo.Products.WebApi.Controllers;
using Moq;
using NUnit.Framework;

namespace Kolmeo.Products.WebApi.UnitTests.ProductControllerTests
{
    [TestFixture]
    public class AddMethod
    {
        [Test]
        public void ShouldCallServiceOnceWithWithCorrectArgumentsAndReturnCorrectId()
        {
            // Arrange
            var productId = 1;
            var name = "Coca Cola";
            var description = "Bottle of Coca Cola 1L";
            var price = 1.99m;
            var mockProductService = new Mock<IProductService>();

            mockProductService.Setup(x => x.Add(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<decimal>())).Returns(productId);

            var sut = new ProductController(mockProductService.Object);

            // Act
            var result = sut.Add(name, description, price);

            // Assert
            mockProductService.Verify(u => u.Add(name, description, price), Times.Once, "Add method was not called exactly once");
            Assert.AreEqual(productId, result);
        }
    }
}
