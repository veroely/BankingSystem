using BankingSystem.Core.Domain.Entities;
using System.Threading.Tasks;

namespace BankingSystem.Core.Domain.IRepository
{
    public interface IParametroRepository
    {
        Task<Parametro> GetParametroPorCodigo(string codigo);
    }
}
