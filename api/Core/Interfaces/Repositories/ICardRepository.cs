using Core.Entities;
using Core.Models;

namespace Core.Interfaces.Repositories
{
    public interface ICardRepository
    {
        public Task<Card> GetCardByNumberAsync(string number);
        public Task<Card> GetCardByIdAsync(int id);
        public Task SetAttempts(int id, bool isValid);
        public Task<List<Card>> GetAllCardsAsTrackingAsync();
        public Task UpdateCards(IEnumerable<Card> cards);
    }
}
