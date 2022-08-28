using BankingSystem.Core.Model.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BankingSystem.Core.Domain.IRepository
{
    public interface ICuentaRepository
    {
        Task<Cuenta> getByIdCuenta(int IdCuenta);
        Task<Cuenta> getByNumeroCuenta(string numeroCuenta);
        Task<List<Cuenta>> getByIdCliente(int idCliente);
        Task addCuenta(Cuenta cuenta);
        Task updateCuenta(Cuenta cuenta);
    }
}
