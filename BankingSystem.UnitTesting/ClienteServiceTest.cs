using AutoMapper;
using BankingSystem.Core.Application.Interface;
using BankingSystem.Core.Domain;
using BankingSystem.Core.Model.Entities;
using BankingSystem.Core.Services;
using BankingSystem.Core.Services.Dto.Cliente;
using BankingSystem.Core.Services.Mapping;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace BankingSystem.UnitTesting
{
    public class ClienteServiceTest
    {
        Mock<IClientRepository> _clienteRepository;
        private IMapper _mapper;

        public ClienteServiceTest()
        {
            var mappingProfile = new MappingProfile();
            var config = new MapperConfiguration(mappingProfile);
            _mapper = new Mapper(config);
            _clienteRepository = new Mock<IClientRepository>();
        }

        [Fact]
        public async Task BusquedaClientePorIdentificacion()
        {
            _clienteRepository
                        .Setup(x => x.getByIdentificacion(It.IsAny<string>()))
                        .ReturnsAsync(new Cliente
                        {
                            IdCliente = 1,
                            Nombre = "Verónica Vicente",
                            Identificacion = "1234567890",
                            Direccion = "La Forestal",
                            Telefono = "0939481545",
                            Contrasenia = "",
                            EsActivo = true
                        });
            IClientService _clienteService = new ClientService(_clienteRepository.Object, _mapper);
            var response = await _clienteService.getByIdentificacion("1234567890");
            Assert.NotNull(response);
            Assert.Equal("Verónica Vicente", response.Nombre);
            Assert.IsType<ClienteDtoResponse>(response);
        }
    }
}
