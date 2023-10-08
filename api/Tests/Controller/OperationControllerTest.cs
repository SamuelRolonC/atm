using Atm.Controllers;
using AtmTests.Data;
using Core.Interfaces.Services;
using Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.Controller
{
    public class OperationControllerTest
    {
        public readonly Mock<IOperationService> _operationServiceMock;
        public readonly Mock<ILogger<OperationController>> _loggerMock;

        public OperationControllerTest()
        {
            _operationServiceMock = new Mock<IOperationService>();
            _loggerMock = new Mock<ILogger<OperationController>>();
        }

        [Fact]
        public async Task Balance_Success()
        {
            // Arrange
            _operationServiceMock.Setup(x => x.BalanceAsync(It.IsAny<int>()))
                .ReturnsAsync(BalanceResultModelData.GetSuccess());

            var operationController = new OperationController(_operationServiceMock.Object, _loggerMock.Object);

            // Act
            var result = await operationController.Balance(1);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(typeof(OkObjectResult), result.GetType());

            var okObjectResult = result as OkObjectResult;
            var balanceResultModel = okObjectResult.Value as BalanceResultModel;

            Assert.NotNull(balanceResultModel);

            Assert.True(balanceResultModel.Success, "Success is not true");
            Assert.NotEmpty(balanceResultModel.CardNumber);
            Assert.NotEmpty(balanceResultModel.CardDueDate);
            Assert.True(balanceResultModel.CardBalance > 0, "Card balance is not a positive integer.");
            Assert.Empty(balanceResultModel.Message);
        }

        [Fact]
        public async Task Balance_NonSuccess()
        {
            // Arrange
            _operationServiceMock.Setup(x => x.BalanceAsync(It.IsAny<int>()))
                .ReturnsAsync(BalanceResultModelData.GetNonSuccess());

            var operationController = new OperationController(_operationServiceMock.Object, _loggerMock.Object);

            // Act
            var result = await operationController.Balance(1);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(typeof(OkObjectResult), result.GetType());

            var okObjectResult = result as OkObjectResult;
            var balanceResultModel = okObjectResult.Value as BalanceResultModel;

            Assert.NotNull(balanceResultModel);

            Assert.False(balanceResultModel.Success, "Success is true");
            Assert.Empty(balanceResultModel.CardNumber);
            Assert.Empty(balanceResultModel.CardDueDate);
            Assert.Equal(0, balanceResultModel.CardBalance);
            Assert.NotEmpty(balanceResultModel.Message);
        }

        [Fact]
        public async Task Balance_Exception()
        {
            // Arrange
            _operationServiceMock.Setup(x => x.BalanceAsync(It.IsAny<int>()))
                .ThrowsAsync(new Exception());

            var operationController = new OperationController(_operationServiceMock.Object, _loggerMock.Object);

            // Act
            var result = await operationController.Balance(1);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(typeof(BadRequestObjectResult), result.GetType());

            var badRequestObjectResult = result as BadRequestObjectResult;
            var balanceResultModel = badRequestObjectResult.Value as BalanceResultModel;

            Assert.NotNull(balanceResultModel);

            Assert.False(balanceResultModel.Success, "Success is true");
            Assert.Empty(balanceResultModel.CardNumber);
            Assert.Empty(balanceResultModel.CardDueDate);
            Assert.Equal(0, balanceResultModel.CardBalance);
            Assert.NotEmpty(balanceResultModel.Message);
        }

        [Fact]
        public async Task Withdraw_Success()
        {
            // Arrange
            _operationServiceMock.Setup(x => x.WithdrawAsync(It.IsAny<int>(), It.IsAny<decimal>()))
                .ReturnsAsync(WithdrawResultModelData.GetSuccess());

            var operationController = new OperationController(_operationServiceMock.Object, _loggerMock.Object);

            // Act
            var result = await operationController.Withdraw(1, 100);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(typeof(OkObjectResult), result.GetType());

            var okObjectResult = result as OkObjectResult;
            var withdrawResultModel = okObjectResult.Value as WithdrawResultModel;

            Assert.NotNull(withdrawResultModel);

            Assert.NotEmpty(withdrawResultModel.CardNumber);
            Assert.True(withdrawResultModel.CardBalance > 0, "Card balance is not a positive integer.");
            Assert.NotEmpty(withdrawResultModel.OperationDate);
            Assert.True(withdrawResultModel.OperationAmount > 0, "Operation amount is not a positive decimal.");
            Assert.True(withdrawResultModel.Success, "Success is not true");
            Assert.Empty(withdrawResultModel.Message);
        }

        [Fact]
        public async Task Withdraw_NonSuccess()
        {
            // Arrange
            _operationServiceMock.Setup(x => x.WithdrawAsync(It.IsAny<int>(), It.IsAny<decimal>()))
                .ReturnsAsync(WithdrawResultModelData.GetNonSuccess());

            var operationController = new OperationController(_operationServiceMock.Object, _loggerMock.Object);

            // Act
            var result = await operationController.Withdraw(1, 100);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(typeof(OkObjectResult), result.GetType());

            var okObjectResult = result as OkObjectResult;
            var withdrawResultModel = okObjectResult.Value as WithdrawResultModel;

            Assert.NotNull(withdrawResultModel);

            Assert.Empty(withdrawResultModel.CardNumber);
            Assert.Equal(0, withdrawResultModel.CardBalance);
            Assert.Empty(withdrawResultModel.OperationDate);
            Assert.Equal(0, withdrawResultModel.OperationAmount);
            Assert.False(withdrawResultModel.Success, "Success is true");
            Assert.NotEmpty(withdrawResultModel.Message);
        }

        [Fact]
        public async Task Withdraw_Exception()
        {
            // Arrange
            _operationServiceMock.Setup(x => x.WithdrawAsync(It.IsAny<int>(), It.IsAny<decimal>()))
                .ThrowsAsync(new Exception());

            var operationController = new OperationController(_operationServiceMock.Object, _loggerMock.Object);

            // Act
            var result = await operationController.Withdraw(1, 100);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(typeof(BadRequestObjectResult), result.GetType());

            var badRequestObjectResult = result as BadRequestObjectResult;
            var withdrawResultModel = badRequestObjectResult.Value as WithdrawResultModel;

            Assert.NotNull(withdrawResultModel);

            Assert.Empty(withdrawResultModel.CardNumber);
            Assert.Equal(0, withdrawResultModel.CardBalance);
            Assert.Empty(withdrawResultModel.OperationDate);
            Assert.Equal(0, withdrawResultModel.OperationAmount);
            Assert.False(withdrawResultModel.Success, "Success is true");
            Assert.NotEmpty(withdrawResultModel.Message);
        }
    }
}
