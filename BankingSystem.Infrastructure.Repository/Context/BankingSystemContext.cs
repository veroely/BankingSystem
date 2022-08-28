using BankingSystem.Core.Domain.Entities;
using BankingSystem.Core.Model.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace BankingSystem.Infrastructure.Repository.Context
{
    public class BankingSystemContext:DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Cuenta> Cuentas { get; set; }
        public DbSet<Movimiento> Movimientos { get; set; }
        public DbSet<Parametro> Parametros { get; set; }

        public BankingSystemContext(DbContextOptions options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        { 
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
