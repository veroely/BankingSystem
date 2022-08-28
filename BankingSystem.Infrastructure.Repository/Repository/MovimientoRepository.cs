using BankingSystem.Core.Domain;
using BankingSystem.Core.Domain.IRepository;
using BankingSystem.Core.Model.Entities;
using BankingSystem.Infrastructure.Repository.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankingSystem.Infrastructure.Repository.Repository
{
    public class MovimientoRepository: IMovimientoRepository
    {
        private readonly BankingSystemContext _context;
        public MovimientoRepository(BankingSystemContext context)
        {
            _context = context;
        }

        public async Task addMovimiento(Movimiento movimineto)
        {
            _context.Movimientos.Add(movimineto);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Movimiento>> getMovimientosByIdCliente(int idCliente, string numeroCuenta)
        {
            var response = await (from movimiento in _context.Movimientos
                                  join cuenta in _context.Cuentas on movimiento.IdCuenta equals cuenta.IdCuenta
                                  where cuenta.IdCliente == idCliente && cuenta.NumeroCuenta == numeroCuenta
                                  select movimiento).ToListAsync();
            return response;
        }

        public async Task<List<ReporteMovimientosCliente>> getMovimientosPOrClienteyFecha(int idCliente, DateTime fechaDesde, DateTime fechaHasta)
        {
            var response = await (from movimiento in _context.Movimientos
                                  join cuenta in _context.Cuentas on movimiento.IdCuenta equals cuenta.IdCuenta
                                  join cliente in _context.Clientes on cuenta.IdCliente equals cliente.IdCliente
                                  where cuenta.IdCliente == idCliente
                                     && movimiento.Fecha >= fechaDesde && movimiento.Fecha <= fechaHasta
                                  select new ReporteMovimientosCliente
                                  {
                                      Fecha = movimiento.Fecha,
                                      Cliente = cliente.Nombre,
                                      NumeroCuenta = cuenta.NumeroCuenta,
                                      TipoCuenta = cuenta.TipoCuenta,
                                      EstadoCuenta = cuenta.Estado,
                                      SaldoInicial = cuenta.SaldoDisponible,
                                      Movimiento = movimiento.Valor,
                                      TipoMovimiento = movimiento.TipoMovimiento,
                                      SaldoDisponible = movimiento.Saldo
                                  }).ToListAsync();
            return response;
        }
    }
}
