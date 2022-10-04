using BankingSystem.Core.Model.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BankingSystem.Core.Domain.IRepository
{
    public interface IClientRepository
    {
        Task<List<Cliente>> getAll();
        Task<Cliente> getById(int idCliente);
        Task<Cliente> getByIdentificacion(string identificacion);
        Task addClient(Cliente cliente);
        Task updateClient(Cliente cliente);
    }
}
