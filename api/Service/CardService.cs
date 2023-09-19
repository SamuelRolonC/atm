using Core.Interfaces.Repositories;
using Core.Interfaces.Services;
using Core.Models;

namespace Service
{
    public class CardService : ICardService
    {
        public readonly ICardRepository _cardRepository;

        public CardService(ICardRepository cardRepository)
        {
            _cardRepository = cardRepository;
        }

        public async Task<CardNumberResultModel> ValidateNumberAsync(string number)
        {
            var card = await _cardRepository.GetCardByNumberAsync(number);
            
            return new CardNumberResultModel
            {
                CardId = card != null ? card.Id : 0,
                IsValid = card != null,
                Message = card != null ? string.Empty : "Card not found"
            };
        }

        public async Task<CardPinResultModel> ValidatePinAsync(int id, string pin)
        {
            var card = await _cardRepository.GetCardByIdAsync(id);

            var isValid = card != null && BCrypt.Net.BCrypt.Verify(pin, card.Pin);

            await _cardRepository.SetAttempts(id, isValid);

            return new CardPinResultModel
            {
                CardId = card != null ? card.Id : 0,
                IsValid = isValid,
                Message = card != null ? string.Empty : "Card not found"
            };
        }

        public async Task SetHashField()
        {
            var cards = await _cardRepository.GetAllCardsAsTrackingAsync();
            if (cards == null) return;

            cards.ForEach(c =>
            {
                c.Pin = BCrypt.Net.BCrypt.HashPassword(c.Pin);
            });

            await _cardRepository.UpdateCards(cards);
        }
    }
}
