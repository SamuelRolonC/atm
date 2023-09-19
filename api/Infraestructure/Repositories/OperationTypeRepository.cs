using Core.Entities;
using Core.Interfaces.Repositories;
using Infraestructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Repositories
{
    public class OperationTypeRepository : IOperationTypeRepository
    {
        public async Task<OperationType> GetByCodeAsync(string code)
        {
            using (var context = new AtmContext())
            {
                return await context.OperationTypes.FirstOrDefaultAsync(o => o.Code == code);
            }
        }
    }
}
