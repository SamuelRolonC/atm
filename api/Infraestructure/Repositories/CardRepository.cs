using Core;
using Core.Entities;
using Core.Interfaces.Repositories;
using Core.Models;
using Infraestructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Repositories
{
    public class CardRepository : ICardRepository
    {
        private readonly AtmContext _context;

        public CardRepository(AtmContext context)
        {
            _context = context;
        }

        public async Task<Card> GetCardByNumberAsync(string number)
        {
            return await _context.Cards.FirstOrDefaultAsync(c => c.Number == number && c.Active && !c.IsBlocked);
        }

        public async Task<Card> GetCardByIdAsync(int id)
        {
            return await _context.Cards.FirstOrDefaultAsync(c => c.Id == id && c.Active && !c.IsBlocked);
        }

        public async Task SetAttempts(int id, bool isValid)
        {
            var card = await _context.Cards.AsTracking().FirstOrDefaultAsync(c => c.Id == id);
            if (card == null)
                throw new Exception("Card not found");

            if (isValid)
                card.FailAttempts = 0;
            else
            {
                if (card.FailAttempts >= SystemParameters.Card.MaxFailedAttempts)
                    card.IsBlocked = true;
                else
                    card.FailAttempts++;
            }

            await _context.SaveChangesAsync();
        }

        public async Task<List<Card>> GetAllCardsAsTrackingAsync()
        {
            return await _context.Cards.AsTracking().ToListAsync();
        }

        public async Task UpdateCards(IEnumerable<Card> cards)
        {
            _context.Cards.UpdateRange(cards);
            await _context.SaveChangesAsync();
        }
    }
}