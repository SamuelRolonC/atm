using Atm.Controllers;
using Atm.Models;
using AtmTests.Data;
using Core.Interfaces.Services;
using Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace Tests.Controller
{
    public class HomeControllerTest
    {
        private readonly Mock<ICardService> _cardServiceMock;
        private readonly Mock<ILogger<HomeController>> _loggerMock;

        public HomeControllerTest()
        {
            _cardServiceMock = new Mock<ICardService>();
            _loggerMock = new Mock<ILogger<HomeController>>();
        }

        [Fact]
        public async Task CardNumber_NotValid()
        {
            // Arrange
            _cardServiceMock.Setup(x => x.ValidateNumberAsync(It.IsAny<string>()))
                .ReturnsAsync(CardNumberResultModelData.GetNonValid());

            var homeController = new HomeController(_cardServiceMock.Object, _loggerMock.Object);

            var cardNumberRequestModel = new CardNumberRequestModel
            {
                Number = "1234567890123456"
            };

            // Act
            var result = await homeController.CardNumber(cardNumberRequestModel);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(typeof(OkObjectResult), result.GetType());

            var okObjectResult = result as OkObjectResult;
            var cardNumberResultModel = okObjectResult.Value as CardNumberResultModel;

            Assert.NotNull(cardNumberResultModel);

            Assert.False(cardNumberResultModel.IsValid, "Value of IsValid is not true");
            Assert.Equal(0, cardNumberResultModel.CardId);
            Assert.NotEmpty(cardNumberResultModel.Message);
        }

        [Fact]
        public async Task CardNumber_Valid()
        {
            // Arrange
            _cardServiceMock.Setup(x => x.ValidateNumberAsync(It.IsAny<string>()))
                .ReturnsAsync(CardNumberResultModelData.GetValid());

            var homeController = new HomeController(_cardServiceMock.Object, _loggerMock.Object);

            var cardNumberRequestModel = new CardNumberRequestModel
            {
                Number = "1234567890123456"
            };

            // Act
            var result = await homeController.CardNumber(cardNumberRequestModel);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(typeof(OkObjectResult), result.GetType());

            var okObjectResult = result as OkObjectResult;
            var cardNumberResultModel = okObjectResult.Value as CardNumberResultModel;

            Assert.NotNull(cardNumberResultModel);

            Assert.True(cardNumberResultModel.IsValid, "Value of IsValid is not true");
            Assert.True(cardNumberResultModel.CardId > 0, "Value of CardId is not a positive integer.");
            Assert.Empty(cardNumberResultModel.Message);
        }

        [Fact]
        public async Task CardNumber_Exception()
        {
            // Arrange
            _cardServiceMock.Setup(x => x.ValidateNumberAsync(It.IsAny<string>()))
                .ThrowsAsync(new Exception());

            var homeController = new HomeController(_cardServiceMock.Object, _loggerMock.Object);

            var cardNumberRequestModel = new CardNumberRequestModel
            {
                Number = "1234567890123456"
            };

            // Act
            var result = await homeController.CardNumber(cardNumberRequestModel);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(typeof(BadRequestObjectResult), result.GetType());

            var badRequestObjectResult = result as BadRequestObjectResult;
            var cardNumberResultModel = badRequestObjectResult.Value as CardNumberResultModel;

            Assert.NotNull(cardNumberResultModel);

            Assert.False(cardNumberResultModel.IsValid, "IsValid is true");
            Assert.Equal(0, cardNumberResultModel.CardId);
            Assert.NotEmpty(cardNumberResultModel.Message);
        }

        [Fact]
        public async Task CardPin_NotValid()
        {
            // Arrange
            _cardServiceMock.Setup(x => x.ValidatePinAsync(It.IsAny<int>(), It.IsAny<string>()))
                .ReturnsAsync(CardPinResultModelData.GetNonValid());

            var homeController = new HomeController(_cardServiceMock.Object, _loggerMock.Object);

            var cardPinRequestModel = new CardPinRequestModel
            {
                Id = 1,
                Pin = "1234"
            };

            // Act
            var result = await homeController.CardPin(cardPinRequestModel);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(typeof(OkObjectResult), result.GetType());

            var okObjectResult = result as OkObjectResult;
            var cardPinResultModel = okObjectResult.Value as CardPinResultModel;

            Assert.NotNull(cardPinResultModel);

            Assert.False(cardPinResultModel.IsValid, "Value of IsValid is not true");
            Assert.Equal(0, cardPinResultModel.CardId);
            Assert.NotEmpty(cardPinResultModel.Message);
        }

        [Fact]
        public async Task CardPin_Valid()
        {
            // Arrange
            _cardServiceMock.Setup(x => x.ValidatePinAsync(It.IsAny<int>(), It.IsAny<string>()))
                .ReturnsAsync(CardPinResultModelData.GetValid());

            var homeController = new HomeController(_cardServiceMock.Object, _loggerMock.Object);

            var cardPinRequestModel = new CardPinRequestModel
            {
                Id = 1,
                Pin = "1234"
            };

            // Act
            var result = await homeController.CardPin(cardPinRequestModel);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(typeof(OkObjectResult), result.GetType());

            var okObjectResult = result as OkObjectResult;
            var cardPinResultModel = okObjectResult.Value as CardPinResultModel;

            Assert.NotNull(cardPinResultModel);

            Assert.True(cardPinResultModel.IsValid, "Value of IsValid is not true");
            Assert.True(cardPinResultModel.CardId > 0, "Value of CardId is not a positive integer.");
            Assert.Empty(cardPinResultModel.Message);
        }

        [Fact]
        public async Task CardPin_Exception()
        {
            // Arrange
            _cardServiceMock.Setup(x => x.ValidatePinAsync(It.IsAny<int>(), It.IsAny<string>()))
                .ThrowsAsync(new Exception());

            var homeController = new HomeController(_cardServiceMock.Object, _loggerMock.Object);

            var cardPinRequestModel = new CardPinRequestModel
            {
                Id = 1,
                Pin = "1234"
            };

            // Act
            var result = await homeController.CardPin(cardPinRequestModel);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(typeof(BadRequestObjectResult), result.GetType());

            var badRequestObjectResult = result as BadRequestObjectResult;
            var cardPinResultModel = badRequestObjectResult.Value as CardPinResultModel;

            Assert.NotNull(cardPinResultModel);

            Assert.False(cardPinResultModel.IsValid, "IsValid is true");
            Assert.Equal(0, cardPinResultModel.CardId);
            Assert.NotEmpty(cardPinResultModel.Message);
        }
    }
}