using Core.Models;

namespace Core.Interfaces.Services
{
    public interface IOperationService
    {
        Task<BalanceResultModel> BalanceAsync(int cardId);
        Task<WithdrawResultModel> WithdrawAsync(int cardId, decimal amount);
    }
}
