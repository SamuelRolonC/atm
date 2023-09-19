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
        public async Task<Card> GetCardByNumberAsync(string number)
        {
            using var context = new AtmContext();
            return await context.Cards.FirstOrDefaultAsync(c => c.Number == number && c.Active && !c.IsBlocked);
        }

        public async Task<Card> GetCardByIdAsync(int id)
        {
            using var context = new AtmContext();
            return await context.Cards.FirstOrDefaultAsync(c => c.Id == id && c.Active && !c.IsBlocked);
        }

        public async Task SetAttempts(int id, bool isValid)
        {
            using (var context = new AtmContext())
            {
                var card = await context.Cards.AsTracking().FirstOrDefaultAsync(c => c.Id == id);
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

                await context.SaveChangesAsync();
            }
        }

        public async Task<List<Card>> GetAllCardsAsTrackingAsync()
        {
            using var context = new AtmContext();
            return await context.Cards.AsTracking().ToListAsync();
        }

        public async Task UpdateCards(IEnumerable<Card> cards)
        {
            using var context = new AtmContext();
            context.Cards.UpdateRange(cards);
            await context.SaveChangesAsync();
        }
    }
}