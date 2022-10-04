using BankingSystem.Core.Domain.IRepository;
using BankingSystem.Core.Model.Entities;
using BankingSystem.Infrastructure.Repository.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankingSystem.Infrastructure.Repository.Repository
{
    public class ClientRepository : IClientRepository
    {
        private readonly BankingSystemContext _context;
        public ClientRepository(BankingSystemContext context)
        {
            _context = context;
        }
        public async Task addClient(Cliente cliente)
        {
            await _context.Clientes.AddAsync(cliente);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Cliente>> getAll()
        {
            return await _context.Clientes.ToListAsync();
        }

        public async Task<Cliente> getById(int idCliente)
        {
            return await _context.Clientes.FindAsync(idCliente);
        }

        public async Task<Cliente> getByIdentificacion(string identificacion)
        {
            return await _context.Clientes.Where(w => w.Identificacion == identificacion).FirstOrDefaultAsync();
        }

        public async Task updateClient(Cliente cliente)
        {
            _context.Update(cliente);
            await _context.SaveChangesAsync();
        }
    }
}
