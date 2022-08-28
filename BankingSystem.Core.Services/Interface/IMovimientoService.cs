using BankingSystem.Core.Services.Dto.Movimiento;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BankingSystem.Core.Application.Interface
{
    public interface IMovimientoService
    {
        Task addMovimiento(MovimientoDtoRequestInsert movimineto);
        Task<List<MovimientoDto>> getMovimientosByIdCliente(int idCliente, string numeroCuenta);
        Task<List<MovimientoReporteDto>> getMovimientosByIdClienteFechas(int idCliente, string fechaDesde, string fechaHasta);
    }
}
