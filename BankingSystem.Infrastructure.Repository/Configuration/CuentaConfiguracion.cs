using BankingSystem.Core.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BankingSystem.Infrastructure.Repository.Configuration
{
    public class CuentaConfiguracion : IEntityTypeConfiguration<Cuenta>
    {
        public void Configure(EntityTypeBuilder<Cuenta> builder)
        {
            builder.HasKey(c => c.IdCuenta);
            builder.Property(c => c.NumeroCuenta).IsRequired().HasMaxLength(16);
            builder.Property(c => c.TipoCuenta).IsRequired().HasMaxLength(16);
            builder.Property(c => c.Estado).IsRequired().HasMaxLength(32);
            builder.Property(c => c.SaldoDisponible).HasColumnType("decimal(10,2)").HasDefaultValue(0.00);
            builder.HasOne(c => c.Cliente).WithMany().HasForeignKey(c => c.IdCliente);
        }
    }
}
