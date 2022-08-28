using BankingSystem.Core.Model.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BankingSystem.Core.Domain.IRepository
{
    public interface IMovimientoRepository
    {
        Task addMovimiento(Movimiento movimiento);
        Task<List<Movimiento>> getMovimientosByIdCliente(int idCliente, string numeroCuenta);
        Task<List<ReporteMovimientosCliente>> getMovimientosPOrClienteyFecha(int idCliente, DateTime fechaDesde, DateTime fechaHasta);
    }
}
