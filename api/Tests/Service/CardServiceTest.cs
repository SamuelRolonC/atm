using Core.Interfaces.Repositories;
using Core.Models;
using Moq;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tests.Data;

namespace Tests.Service
{
    public class CardServiceTest
    {
        public readonly Mock<ICardRepository> _cardRepositoryMock;

        public CardServiceTest()
        {
            _cardRepositoryMock = new Mock<ICardRepository>();
        }

        [Fact]
        public async Task ValidateNumberAsync()
        {
            // Arrange
            _cardRepositoryMock.Setup(x => x.GetCardByNumberAsync(It.IsAny<string>()))
                .ReturnsAsync(CardData.GetCardActive());
            
            var cardService = new CardService(_cardRepositoryMock.Object);

            // Act
            var cardNumberResultModel = await cardService.ValidateNumberAsync(It.IsAny<string>());

            // Assert
            Assert.NotNull(cardNumberResultModel);
            Assert.Equal(typeof(CardNumberResultModel), cardNumberResultModel.GetType());
            Assert.True(cardNumberResultModel.IsValid, "IsValid is not true");
            Assert.True(cardNumberResultModel.CardId > 0, "CardId is not a positive integer.");
            Assert.Empty(cardNumberResultModel.Message);
        }
    }
}
