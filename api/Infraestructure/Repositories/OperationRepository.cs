using Core;
using Core.Entities;
using Core.Interfaces.Repositories;
using Core.Models;
using Infraestructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Infraestructure.Repositories
{
    public class OperationRepository : IOperationRepository
    {
        private readonly ILogger<OperationRepository> _logger;

        public OperationRepository(ILogger<OperationRepository> logger)
        {
            _logger = logger;
        }

        public async Task<BalanceResultModel> BalanceAsync(int cardId)
        {
            try
            {
                using var context = new AtmContext();
                var card = await context.Cards.FirstOrDefaultAsync(c => c.Id == cardId);

                return new BalanceResultModel
                {
                    CardNumber = card != null ? card.Number : string.Empty,
                    CardDueDate = card != null ? card.DueDate.ToString("dd/MM/yyyy") : string.Empty,
                    CardBalance = card != null ? card.Balance : 0,
                    Success = card != null,
                    Message = card != null ? string.Empty : "No se encontraron datos para la operación."
                };
            }
            catch (Exception ex)
            {
                return new BalanceResultModel
                {
                    Success = false,
                    Message = "No se pudo procesar la operación. Por favor, vuelva a intentarlo más tarde."
                };
            }
        }

        public async Task<WithdrawResultModel> WithdrawAsync(int cardId, decimal amount)
        {
            using var context = new AtmContext();
            using var transaction = context.Database.BeginTransaction();

            try
            {
                var operationType = await context.OperationTypes.FirstOrDefaultAsync(o => o.Code == SystemParameters.OperationType.Withdrawal);
                if (operationType == null)
                    throw new Exception($"{nameof(OperationType)} {SystemParameters.OperationType.Withdrawal} not found.");

                var operation = new Operation()
                {
                    Amount = amount,
                    CardId = cardId,
                    DateTime = DateTime.Now,
                    OperationTypeId = operationType.Id
                };
                await context.Operations.AddAsync(operation);
                await context.SaveChangesAsync();

                if (operation == null || operation.Id == 0)
                    throw new Exception($"Error occured while creating an {nameof(Operation)}.");

                var card = await context.Cards.AsTracking().FirstOrDefaultAsync(c => c.Id == cardId && c.Active && !c.IsBlocked);
                if (card == null || card.Id == 0)
                    throw new Exception($"{nameof(Card)} {cardId} not found.");

                card.Balance -= amount;
                context.Cards.Update(card);
                await context.SaveChangesAsync();

                transaction.Commit();

                return new WithdrawResultModel
                {
                    CardBalance = card.Balance,
                    CardNumber = card.Number,
                    OperationAmount = operation.Amount ?? 0,
                    OperationDate = operation.DateTime,
                    Success = true,
                    Message = string.Empty
                };
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                _logger.LogError(ex, "Error en {1}.{2}({3},{4}): ", nameof(OperationRepository), nameof(WithdrawAsync), cardId, amount);
                return new WithdrawResultModel
                {
                    Success = false,
                    Message = "No se pudo procesar la operación. Por favor, vuelva a intentarlo más tarde."
                };
            }
        }
    }
}