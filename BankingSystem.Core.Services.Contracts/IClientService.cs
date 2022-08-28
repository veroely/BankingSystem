using System.Threading.Tasks;

namespace BankingSystem.Core.Services.Contracts
{
    public interface IClientService
    {
        Task<ClienteDto> getById(int idCliente);
        Task addClient(Cliente cliente);
        Task updateClient(Cliente cliente);
    }
}
