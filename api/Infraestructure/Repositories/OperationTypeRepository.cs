using Core.Entities;
using Core.Interfaces.Repositories;
using Infraestructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Repositories
{
    public class OperationTypeRepository : IOperationTypeRepository
    {
        private readonly AtmContext _context;

        public OperationTypeRepository(AtmContext context)
        {
            _context = context;
        }

        public async Task<OperationType> GetByCodeAsync(string code)
        {
            return await _context.OperationTypes.FirstOrDefaultAsync(o => o.Code == code);
        }
    }
}
