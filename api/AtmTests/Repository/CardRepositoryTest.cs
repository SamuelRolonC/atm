using Core.Entities;
using Infraestructure.Data;
using Infraestructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Moq;
using Moq.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tests.Data;
using static Core.SystemParameters;

namespace Tests.Repository
{
    public class CardRepositoryTest
    {
        private readonly Mock<AtmContext> _atmContextMock;

        public CardRepositoryTest()
        {
            _atmContextMock = new Mock<AtmContext>();
        }

        [Fact]
        public async Task GetCardByNumberAsync()
        {
            // Arrange
            var cards = CardData.GetCards();
            _atmContextMock.Setup(x => x.Cards).ReturnsDbSet(cards.AsQueryable());

            var cardRepository = new CardRepository(_atmContextMock.Object);

            // Act
            var card = await cardRepository.GetCardByNumberAsync(cards.First().Number);

            // Assert
            Assert.NotNull(card);
            Assert.Equal(cards.First().Id, card.Id);
        }

        [Fact]
        public async Task GetCardByIdAsync()
        {
            // Arrange
            var cards = CardData.GetCards();
            _atmContextMock.Setup(x => x.Cards).ReturnsDbSet(cards.AsQueryable());

            var cardRepository = new CardRepository(_atmContextMock.Object);

            // Act
            var card = await cardRepository.GetCardByIdAsync(cards.First().Id);

            // Assert
            Assert.NotNull(card);
            Assert.Equal(cards.First().Id, card.Id);
        }

        [Fact]
        public async Task SetAttempts_CardExists()
        {
            // Arrange
            var cards = CardData.GetCards();
            _atmContextMock.Setup(x => x.Cards).ReturnsDbSet(cards.AsQueryable());
            var cardRepository = new CardRepository(_atmContextMock.Object);

            // Act
            await cardRepository.SetAttempts(cards.First().Id, true);

            // Assert
            Assert.True(true);
        }

        [Fact]
        public async Task SetAttempts_IsNotValid()
        {
            // Arrange
            var cards = CardData.GetCards();
            _atmContextMock.Setup(x => x.Cards).ReturnsDbSet(cards.AsQueryable());
            var cardRepository = new CardRepository(_atmContextMock.Object);

            // Act
            await cardRepository.SetAttempts(cards.First().Id, It.IsAny<bool>());

            // Assert
            Assert.True(true);
        }

        [Fact]
        public async Task SetAttempts_CardNotExist()
        {
            // Arrange
            var cards = CardData.GetCards();
            _atmContextMock.Setup(x => x.Cards).ReturnsDbSet(cards.AsQueryable());
            var cardRepository = new CardRepository(_atmContextMock.Object);

            // Act / Assert
            await Assert.ThrowsAsync<Exception>(() => cardRepository.SetAttempts(int.MaxValue, true));
        }

        [Fact]
        public async Task GetAllCardsAsTrackingAsync()
        {
            // Arrange
            var cards = CardData.GetCards();
            _atmContextMock.Setup(x => x.Cards).ReturnsDbSet(cards.AsQueryable());
            var cardRepository = new CardRepository(_atmContextMock.Object);

            // Act
            var cardsTracking = await cardRepository.GetAllCardsAsTrackingAsync();

            // Assert
            Assert.NotNull(cardsTracking);
            Assert.True(cardsTracking.Count > 0);
        }

        [Fact]
        public async Task UpdateCards()
        {
            // Arrange
            var cards = CardData.GetCards();
            _atmContextMock.Setup(x => x.Cards).ReturnsDbSet(cards.AsQueryable());
            var cardRepository = new CardRepository(_atmContextMock.Object);

            // Act
            await cardRepository.UpdateCards(cards);

            // Assert
            Assert.True(true);
        }
    }
}
