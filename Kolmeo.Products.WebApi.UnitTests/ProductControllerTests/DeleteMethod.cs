using Kolmeo.Products.Services.Interfaces;
using Kolmeo.Products.WebApi.Controllers;
using Moq;
using NUnit.Framework;

namespace Kolmeo.Products.WebApi.UnitTests.ProductControllerTests
{
    [TestFixture]
    public class DeleteMethod
    {
        [Test]
        public void ShouldCallServiceOnceWithCorrectId()
        {
            // Arrange
            var productId = 1;
            var mockProductService = new Mock<IProductService>();

            mockProductService.Setup(x => x.Delete(It.IsAny<int>()));

            var sut = new ProductController(mockProductService.Object);

            // Act
            sut.Delete(productId);

            // Assert
            mockProductService.Verify(u => u.Delete(productId), Times.Once, "Delete method was not called exactly once");
        }
    }
}
