using AutoMapper;
using BankingSystem.Core.Application.Interface;
using BankingSystem.Core.Domain;
using BankingSystem.Core.Services.Dto.Cuenta;
using BankingSystem.Core.Services.Mapping;
using BankingSystem.Core.Services.Service;
using Moq;
using System;
using Xunit;

namespace BankingSystem.UnitTesting
{
    public class CuentaServiceTest
    {
        Mock<ICuentaRepository> _cuentaRepository;
        private IMapper _mapper;

        public CuentaServiceTest()
        {
            var mappingProfile = new MappingProfile();
            var config = new MapperConfiguration(mappingProfile);
            _mapper = new Mapper(config);
            _cuentaRepository = new Mock<ICuentaRepository>();
        }

        [Fact]
        public void ValidarNumerCuentaNuloVacioAlCrearCuenta() 
        {
            ICuentaService _cuentaService = new CuentaService(_cuentaRepository.Object, _mapper);
            CuentaDtoRequestInsert cuentaDtoRequestInsert = new CuentaDtoRequestInsert()
            {
                IdCliente = 1,
                NumeroCuenta = "",
                SaldoDisponible = 100,
                TipoCuenta = "AHORROS"
            };

            var exception = Assert.ThrowsAsync<Exception>(() => _cuentaService.addCuenta(cuentaDtoRequestInsert));
            Assert.Equal("El campo NumeroCuenta no pude ser vacío", exception.Result.Message);
        }

    }
}
