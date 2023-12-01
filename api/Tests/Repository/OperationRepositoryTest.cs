using Atm.Controllers;
using Core.Entities;
using Infraestructure.Data;
using Infraestructure.Repositories;
using Microsoft.Extensions.Logging;
using Moq;
using Moq.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tests.Data;

namespace Tests.Repository
{
    public class OperationRepositoryTest
    {
        private readonly Mock<AtmContext> _atmContextMock;
        private readonly Mock<ILogger<OperationRepository>> _loggerMock;

        public OperationRepositoryTest()
        {
            _atmContextMock = new Mock<AtmContext>();
            _loggerMock = new Mock<ILogger<OperationRepository>>();
        }

        [Fact]
        public async Task BalanceAsync_Exist()
        {
            // Arrange
            var cards = CardData.GetCards();
            _atmContextMock.Setup(x => x.Cards).ReturnsDbSet(cards.AsQueryable());

            var operationRepository = new OperationRepository(_loggerMock.Object, _atmContextMock.Object);
            
            // Act
            var result = await operationRepository.BalanceAsync(cards.First().Id);

            // Assert
            Assert.NotNull(result);
            Assert.True(result.Success);
            Assert.Empty(result.Message);
        }

        [Fact]
        public async Task BalanceAsync_NotExist()
        {
            // Arrange
            var cards = CardData.GetCards();
            _atmContextMock.Setup(x => x.Cards).ReturnsDbSet(cards.AsQueryable());

            var operationRepository = new OperationRepository(_loggerMock.Object, _atmContextMock.Object);

            // Act
            var result = await operationRepository.BalanceAsync(int.MaxValue);

            // Assert
            Assert.NotNull(result);
            Assert.False(result.Success);
            Assert.NotEmpty(result.Message);
        }


        [Fact]
        public async Task BalanceAsync_Exception()
        {
            // Arrange
            _atmContextMock.Setup(x => x.Cards).Throws(new Exception());

            var operationRepository = new OperationRepository(_loggerMock.Object, _atmContextMock.Object);

            // Act
            var result = await operationRepository.BalanceAsync(It.IsAny<int>());

            // Assert
            Assert.NotNull(result);
            Assert.False(result.Success);
            Assert.NotEmpty(result.Message);
        }
    }
}
