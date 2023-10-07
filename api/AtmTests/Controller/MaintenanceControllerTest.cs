using Atm.Controllers;
using Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;

namespace Tests.Controller
{
    public class MaintenanceControllerTest
    {
        private readonly Mock<ICardService> _cardServiceMock;
        private readonly Mock<ILogger<MaintenanceController>> _loggerMock;

        public MaintenanceControllerTest()
        {
            _cardServiceMock = new Mock<ICardService>();
            _loggerMock = new Mock<ILogger<MaintenanceController>>();
        }

        [Fact]
        public async Task Hash_Success()
        {
            // Arrange
            var maintenanceController = new MaintenanceController(_cardServiceMock.Object, _loggerMock.Object);

            // Act
            var result = await maintenanceController.Hash();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(typeof(OkObjectResult), result.GetType());

            var okObjectResult = result as OkObjectResult;
            var message = okObjectResult.Value as string;

            Assert.NotNull(message);
            Assert.Equal("Success", message);
        }

        [Fact]
        public async Task Hash_Exception()
        {
            // Arrange
            _cardServiceMock.Setup(x => x.SetHashField())
                .Throws(new Exception());

            var maintenanceController = new MaintenanceController(_cardServiceMock.Object, _loggerMock.Object);

            // Act
            var result = await maintenanceController.Hash();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(typeof(BadRequestObjectResult), result.GetType());

            var badRequestObjectResult = result as BadRequestObjectResult;
            var message = badRequestObjectResult.Value as string;

            Assert.NotNull(message);
            Assert.Equal("Error", message);
        }
    }
}
