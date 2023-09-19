using Core.Entities;
using Core.Models;

namespace Core.Interfaces.Repositories
{
    public interface SetAttempts
    {
        public Task<CardNumberResultModel> ValidateNumberAsync(string number);
        public Task<ValidateCardResultModel> ValidatePinAsync(int id, string pin);
        public Task SetAttempts(int id, bool isValid);
    }
}
