using Core.Entities;

namespace Core.Interfaces.Repositories
{
    public interface IOperationTypeRepository
    {
        Task<OperationType> GetByCodeAsync(string code);
    }
}
