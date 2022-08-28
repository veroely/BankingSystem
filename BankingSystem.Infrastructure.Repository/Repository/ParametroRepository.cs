using BankingSystem.Core.Domain.Entities;
using BankingSystem.Core.Domain.IRepository;
using BankingSystem.Infrastructure.Repository.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace BankingSystem.Infrastructure.Repository.Repository
{
    public class ParametroRepository: IParametroRepository
    {
        private readonly BankingSystemContext _context;

        public ParametroRepository(BankingSystemContext context)
        {
            _context = context;
        }

        public async Task<Parametro> GetParametroPorCodigo(string codigo)
        {
            return await _context.Parametros.Where(w => w.Codigo == codigo).FirstOrDefaultAsync();
        }
    }
}
