using BankingSystem.Core.Services.Dto.Cliente;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BankingSystem.Core.Application.Interface
{
    public interface IClientService
    {
        Task<List<ClienteDtoResponse>> getAll();
        Task<ClienteDtoResponse> getByIdentificacion(string identificacion);
        Task<ClienteDtoResponse> getById(int idCliente);
        Task addClient(ClienteDtoRequestInsert cliente);
        Task updateClient(int idCliente,ClienteDtoRequestUpdate cliente);
        Task deleteCliente(int idCliente);
    }
}
