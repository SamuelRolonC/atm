using Core.Entities;
using Core.Models;

namespace Core.Interfaces.Repositories
{
    public interface IOperationRepository
    {
        Task<BalanceResultModel> BalanceAsync(int cardId);
        Task<WithdrawResultModel> WithdrawAsync(int cardId, decimal amount);
    }
}
