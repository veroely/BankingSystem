using AutoMapper;
using BankingSystem.Core.Application.Interface;
using BankingSystem.Core.Domain;
using BankingSystem.Core.Domain.IRepository;
using BankingSystem.Core.Model.Entities;
using BankingSystem.Core.Services.Dto.Cuenta;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BankingSystem.Core.Services.Service
{
    public class CuentaService:ICuentaService
    {
        private readonly ICuentaRepository _cuentaRepository;
        private readonly IMapper _mapper;
        public CuentaService(ICuentaRepository cuentaRepository, IMapper mapper)
        {
            _cuentaRepository = cuentaRepository;
            _mapper = mapper;
        }

        public async Task addCuenta(CuentaDtoRequestInsert cuenta)
        {
            if (string.IsNullOrEmpty(cuenta.NumeroCuenta))
                throw new Exception("El campo NumeroCuenta no pude ser vacío");

            if (string.IsNullOrEmpty(cuenta.TipoCuenta))
                throw new Exception("El campo TipoCuenta no pude ser vacío");

            Cuenta cuentaBusqueda = new Cuenta();
            cuentaBusqueda = await _cuentaRepository.getByNumeroCuenta(cuenta.NumeroCuenta);

            if (cuentaBusqueda != null)
                throw new Exception($"El NumeroCuenta {cuenta.NumeroCuenta} ya existe");

            Cuenta cuentaNueva = new Cuenta();
            cuentaNueva = _mapper.Map<Cuenta>(cuenta);
            cuentaNueva.Estado = "ACTIVA";
            cuentaNueva.FechaCreacion = DateTime.Now;
            await _cuentaRepository.addCuenta(cuentaNueva);
        }

        public async Task<List<CuentaDtoResponse>> getByIdCliente(int idCliente)
        {
            List<Cuenta> lcuenta = await _cuentaRepository.getByIdCliente(idCliente);

            List<CuentaDtoResponse> cuentas = _mapper.Map <List<CuentaDtoResponse>>(lcuenta);
            return cuentas;
        }

        public async Task<CuentaDtoResponse> getByIdCuenta(int idCuenta)
        {
            Cuenta cuenta = await _cuentaRepository.getByIdCuenta(idCuenta);
            
            CuentaDtoResponse cuentaDto = _mapper.Map<CuentaDtoResponse>(cuenta);
            return cuentaDto;       
        }
        
        public async Task<CuentaDtoResponse> getByNumeroCuenta(string numeroCuenta)
        {
            Cuenta cuenta = await _cuentaRepository.getByNumeroCuenta(numeroCuenta);

            CuentaDtoResponse cuentaDto = _mapper.Map<CuentaDtoResponse>(cuenta);
            return cuentaDto;
        }

        public async Task updateCuenta(int idCuenta, CuentaDtoRequestUpdate cuentaDtoRequestUpdate)
        {
            if (string.IsNullOrEmpty(cuentaDtoRequestUpdate.Estado))
                throw new Exception("El campo Estado no puede ser nulo");

            Cuenta cuentaBusqueda = await _cuentaRepository.getByIdCuenta(idCuenta);

            if (cuentaBusqueda == null)
                throw new Exception($"La Cuenta de id {idCuenta} no existe");

            cuentaBusqueda.SaldoDisponible = cuentaDtoRequestUpdate.SaldoDisponible;
            cuentaBusqueda.Estado = cuentaDtoRequestUpdate.Estado;
            cuentaBusqueda.FechaModificacion = DateTime.Now;

            await _cuentaRepository.updateCuenta(cuentaBusqueda);
        }

        public async Task updateSaldo(decimal saldo)
        {
            Cuenta cuentaBusqueda = await _cuentaRepository.getByIdCuenta(0);

            if (cuentaBusqueda == null)
                throw new Exception("La Cuenta no existe");

            cuentaBusqueda.SaldoDisponible = saldo;
            cuentaBusqueda.FechaModificacion = DateTime.Now;

            await _cuentaRepository.updateCuenta(cuentaBusqueda);
        }
    }
}
