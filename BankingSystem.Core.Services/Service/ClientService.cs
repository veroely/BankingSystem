using AutoMapper;
using BankingSystem.Core.Application.Interface;
using BankingSystem.Core.Domain;
using BankingSystem.Core.Model.Entities;
using BankingSystem.Core.Services.Dto.Cliente;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BankingSystem.Core.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;
        private readonly IMapper _mapper;
        public ClientService(IClientRepository clientRepository, IMapper mapper)
        {
            _clientRepository = clientRepository;
            _mapper = mapper;
        }

        public async Task addClient(ClienteDtoRequestInsert cliente)
        {
            if(string.IsNullOrEmpty(cliente.Identificacion))
                throw new Exception("El campo Identificaciion no puede ser nulo");
            if (string.IsNullOrEmpty(cliente.Nombre))
                throw new Exception("El campó Nombre no puede ser nulo");
            if (string.IsNullOrEmpty(cliente.Direccion))
                throw new Exception("El campo Direccion no puede ser nulo");
            if (string.IsNullOrEmpty(cliente.Telefono))
                throw new Exception("El campo Telefono no puede ser nulo");
            if (string.IsNullOrEmpty(cliente.Contrasenia))
                throw new Exception("El campo Contrasenia no puede ser nulo");

            Cliente clienteBusqueda = await _clientRepository.getByIdentificacion(cliente.Identificacion);
            if (clienteBusqueda != null)
                throw new Exception($"Ya existe un cliente con la identificacion {cliente.Identificacion}");

            Cliente clienteNuevo = new Cliente();
            clienteNuevo = _mapper.Map<Cliente>(cliente);
            clienteNuevo.EsActivo = true;

            await _clientRepository.addClient(clienteNuevo);

        }

        public async Task<List<ClienteDtoResponse>> getAll()
        {
            List<Cliente> clientes = await _clientRepository.getAll();
            List<ClienteDtoResponse> clienteDto = _mapper.Map<List<ClienteDtoResponse>>(clientes);
            return clienteDto;
        }

        public async Task<ClienteDtoResponse> getById(int idCliente)
        {
            Cliente cliente = await _clientRepository.getById(idCliente);
            if (cliente == null)
                throw new Exception($"El Cliente con idCliente {idCliente} no existe ");

            ClienteDtoResponse clienteDto = _mapper.Map<ClienteDtoResponse>(cliente);
            return clienteDto;
        }

        public async Task<ClienteDtoResponse> getByIdentificacion(string identificacion)
        {
            Cliente cliente = await _clientRepository.getByIdentificacion(identificacion);

            ClienteDtoResponse clienteDto = _mapper.Map<ClienteDtoResponse>(cliente);
            return clienteDto;
        }

        public async Task updateClient(int idCliente, ClienteDtoRequestUpdate cliente)
        {
            if (string.IsNullOrEmpty(cliente.Nombre))
                throw new Exception("El campó Nombre no puede ser nulo");
            if (string.IsNullOrEmpty(cliente.Direccion))
                throw new Exception("El campo Direccion no puede ser nulo");
            if (string.IsNullOrEmpty(cliente.Telefono))
                throw new Exception("El campo Telefono no puede ser nulo");
            if (string.IsNullOrEmpty(cliente.Contrasenia))
                throw new Exception("El campo Contrasenia no puede ser nulo");

            Cliente clienteBusqueda = await _clientRepository.getById(idCliente);
            if (clienteBusqueda == null)
                throw new Exception("El cliente no existe");

            clienteBusqueda.Nombre = cliente.Nombre;
            clienteBusqueda.Telefono = cliente.Telefono;
            clienteBusqueda.Direccion = cliente.Direccion;
            clienteBusqueda.Contrasenia = cliente.Contrasenia;
            clienteBusqueda.EsActivo = cliente.EsActivo;

            await _clientRepository.updateClient(clienteBusqueda);
        }

        public async Task deleteCliente(int idCliente)
        {
            Cliente clienteBusqueda = await _clientRepository.getById(idCliente);
            if (clienteBusqueda == null)
                throw new Exception("El cliente no existe");

            clienteBusqueda.EsActivo = false;

            await _clientRepository.updateClient(clienteBusqueda);
        }
    }
}
