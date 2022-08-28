using BankingSystem.Core.Domain;
using BankingSystem.Core.Model.Entities;
using BankingSystem.Infrastructure.Repository.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankingSystem.Infrastructure.Repository.Implementation
{
    public class CuentaRepository:ICuentaRepository
    {
        private readonly BankingSystemContext _context;
        public CuentaRepository(BankingSystemContext context)
        {
            _context = context;
        }

        public async Task addCuenta(Cuenta cuenta)
        {
            await _context.Cuentas.AddAsync(cuenta);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Cuenta>> getByIdCliente(int idCliente)
        {
            var response = await(from cuenta in _context.Cuentas
                            join cliente in _context.Clientes on cuenta.IdCliente equals cliente.IdCliente
                            where cliente.IdCliente == idCliente
                            select cuenta).ToListAsync();

            return response;
        }

        public async Task<Cuenta> getByIdCuenta(int idCuenta)
        {
            return await _context.Cuentas.FindAsync(idCuenta);
        }

        public async Task<Cuenta> getByNumeroCuenta(string numeroCuenta)
        {
            return await _context.Cuentas.Where(w => w.NumeroCuenta == numeroCuenta).FirstOrDefaultAsync();
        }

        public async Task updateCuenta(Cuenta cuenta)
        {
            _context.Update(cuenta);
            await _context.SaveChangesAsync();
        }
    }
}
