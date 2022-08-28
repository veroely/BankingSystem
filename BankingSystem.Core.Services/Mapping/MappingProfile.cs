using AutoMapper;
using BankingSystem.Core.Model.Entities;
using BankingSystem.Core.Services.Dto.Cliente;
using BankingSystem.Core.Services.Dto.Cuenta;
using BankingSystem.Core.Services.Dto.Movimiento;

namespace BankingSystem.Core.Services.Mapping
{
    public class MappingProfile:MapperConfigurationExpression
    {
        public MappingProfile()
        {
            CreateMap<Cliente, ClienteDtoResponse>().ReverseMap();
            CreateMap<Cliente, ClienteDtoRequestInsert>().ReverseMap();
            CreateMap<Cliente, ClienteDtoRequestUpdate>().ReverseMap();
            CreateMap<Cuenta, CuentaDtoRequestInsert>().ReverseMap();
            CreateMap<Cuenta, CuentaDtoRequestUpdate>().ReverseMap();
            CreateMap<Cuenta, CuentaDtoResponse>().ReverseMap();
            CreateMap<Movimiento, MovimientoDto>().ReverseMap();
            CreateMap<Movimiento, MovimientoDtoRequestInsert>().ReverseMap();
            CreateMap<ReporteMovimientosCliente, MovimientoReporteDto>().ReverseMap();
        }
    }
}
