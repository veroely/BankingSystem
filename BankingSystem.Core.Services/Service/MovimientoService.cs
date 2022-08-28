using AutoMapper;
using BankingSystem.Core.Application.Interface;
using BankingSystem.Core.Domain;
using BankingSystem.Core.Model.Entities;
using BankingSystem.Core.Services.Dto.Movimiento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankingSystem.Core.Services.Service
{
    public class MovimientoService:IMovimientoService
    {
        private readonly IMovimientoRepository _movimientoRepository;
        private readonly ICuentaRepository _cuentaRepository;
        private readonly IMapper _mapper;
        public MovimientoService(IMovimientoRepository movimientoRepository, ICuentaRepository cuentaRepository, IMapper mapper)
        {
            _movimientoRepository = movimientoRepository;
            _cuentaRepository = cuentaRepository;
            _mapper = mapper;
        }

        public async Task addMovimiento(MovimientoDtoRequestInsert movimiento)
        {
            if (string.IsNullOrEmpty(movimiento.NumeroCuenta))
                throw new Exception("En NumeroCuenta no puede ser vacío");

            if (string.IsNullOrEmpty(movimiento.TipoMovimiento))
                throw new Exception("En TipoMovimiento no puede ser vacío");

            if (movimiento.Valor <= 0)
                throw new Exception("EL valor no puede ser cero o menor a cero");

            Cuenta cuenta = await _cuentaRepository.getByNumeroCuenta(movimiento.NumeroCuenta);
            if (cuenta == null)
                throw new Exception($"El número de cuenta {movimiento.NumeroCuenta} no existe");

            decimal saldoActual = cuenta.SaldoDisponible;
            //Si el saldo es cero, y va a realizar una transacción débito, debe desplegar mensaje “Saldo no disponible”
            if (saldoActual == 0 && movimiento.TipoMovimiento == "RETIRO")
                throw new Exception("Saldo no disponible");

            List<Movimiento> movimientos = await _movimientoRepository.getMovimientosByIdCliente(cuenta.IdCliente, cuenta.NumeroCuenta);
            decimal retirosActual = movimientos.Where(w => w.Fecha.Date == DateTime.Now.Date && w.TipoMovimiento == "RETIRO")
                                          .Sum(s => s.Valor);

            decimal totalRetiros = retirosActual + movimiento.Valor;

            //Si el cupo disponible ya se cumplió no debe permitir realizar un debito y debe desplegar un mensaje “Cupo diario Excedido”
            if (movimiento.TipoMovimiento == "RETIRO" && totalRetiros > 1000)
                throw new Exception("Cupo diario Excedido");

            if (movimiento.TipoMovimiento == "RETIRO")
                saldoActual -= movimiento.Valor;
            else
                saldoActual += movimiento.Valor;

            Movimiento mov = new Movimiento();
            mov = _mapper.Map<Movimiento>(movimiento);
            mov.IdCuenta = cuenta.IdCuenta;
            mov.Fecha = DateTime.Now;
            mov.Saldo = saldoActual;
            await _movimientoRepository.addMovimiento(mov);

            cuenta.SaldoDisponible = saldoActual;
            await _cuentaRepository.updateCuenta(cuenta);

        }

        public async Task<List<MovimientoDto>> getMovimientosByIdCliente(int idCliente, string numeroCuenta)
        {
            List <Movimiento>  movimientos = await _movimientoRepository.getMovimientosByIdCliente(idCliente, numeroCuenta);

            List<MovimientoDto> movimientoDtos = _mapper.Map<List<MovimientoDto>>(movimientos);
            return movimientoDtos;
        }

        public async Task<List<MovimientoReporteDto>> getMovimientosByIdClienteFechas(int idCliente, string fechaDesde, string fechaHasta)
        {
            DateTime fecDesde;
            DateTime fecHasta;

            if (!DateTime.TryParse(fechaDesde, out fecDesde))
            {
                throw new Exception("La FechaDesde es incorrecta");
            }

            if (!DateTime.TryParse(fechaHasta, out fecHasta))
            {
                throw new Exception("La FechaHasta es incorrecta");
            }
            List<ReporteMovimientosCliente> movimientos = await _movimientoRepository.getMovimientosPOrClienteyFecha(idCliente, fecDesde, fecHasta);

            List<MovimientoReporteDto> movimientoDtos = movimientos.Select(s => new MovimientoReporteDto()
            {
                Fecha = s.Fecha,
                Cliente = s.Cliente,
                NumeroCuenta = s.NumeroCuenta,
                TipoCuenta = s.TipoCuenta,
                SaldoInicial = s.SaldoInicial,
                EstadoCuenta = s.EstadoCuenta,
                Movimiento = s.TipoMovimiento == "RETIRO" ? -s.Movimiento:s.Movimiento,
                SaldoDisponible =s.SaldoDisponible
            }).ToList();
            return movimientoDtos;
        }
    }
}
