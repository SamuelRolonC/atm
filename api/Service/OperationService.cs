using Core.Interfaces.Repositories;
using Core.Interfaces.Services;
using Core.Models;

namespace Service
{
    public class OperationService : IOperationService
    {
        private readonly IOperationRepository _operationRepository;

        public OperationService(IOperationRepository operationRepository)
        {
            _operationRepository = operationRepository;
        }

        public async Task<BalanceResultModel> BalanceAsync(int cardId)
        {
            return await _operationRepository.BalanceAsync(cardId);
        }

        public async Task<WithdrawResultModel> WithdrawAsync(int cardId, decimal amount)
        {
            return await _operationRepository.WithdrawAsync(cardId, amount);
        }
    }
}
