using BankingSystem.Core.Services.Dto.Cuenta;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BankingSystem.Core.Application.Interface
{
    public interface ICuentaService
    {
        Task<CuentaDtoResponse> getByIdCuenta(int IdCuenta);
        Task<CuentaDtoResponse> getByNumeroCuenta(string numeroCuenta);
        Task<List<CuentaDtoResponse>> getByIdCliente(int idCliente);
        Task addCuenta(CuentaDtoRequestInsert cuenta);
        Task updateCuenta(int idCuenta, CuentaDtoRequestUpdate cuentaDtoRequestUpdate);
    }
}
