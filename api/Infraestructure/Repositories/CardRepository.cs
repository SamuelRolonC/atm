using Core;
using Core.Interfaces.Repositories;
using Core.Models;
using Infraestructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Net.NetworkInformation;

namespace Infraestructure.Repositories
{
    public class CardRepository : SetAttempts
    {
        public async Task<CardNumberResultModel> ValidateNumberAsync(string number)
        {
            using (var context = new AtmContext())
            {
                var card = await context.Cards.FirstOrDefaultAsync(c => c.Number == number && c.Active && !c.IsBlocked);

                return new CardNumberResultModel
                {
                    CardId = card != null ? card.Id : 0,
                    IsValid = card != null,
                    Message = card != null ? string.Empty : "Card not found"
                };
            }
        }

        public async Task<ValidateCardResultModel> ValidatePinAsync(int id, string pin)
        {
            using (var context = new AtmContext())
            {
                var isValidPin = await context.Cards.AnyAsync(c => c.Id == id && c.Pin == pin && c.Active && !c.IsBlocked);

                return new ValidateCardResultModel
                {
                    IsValid = isValidPin,
                    Message = isValidPin ? string.Empty : "Card not found"
                };
            }
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
    }
}