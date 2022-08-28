using BankingSystem.Core.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BankingSystem.Infrastructure.Repository.Configuration
{
    public class MovimientoConfiguracion : IEntityTypeConfiguration<Movimiento>
    {
        public void Configure(EntityTypeBuilder<Movimiento> builder)
        {
            builder.HasKey(m => m.IdMovimiento);
            builder.Property(m => m.TipoMovimiento).HasMaxLength(16);
            builder.Property(m => m.Valor).HasColumnType("decimal(10,2)").HasDefaultValue(0.00);
            builder.Property(m => m.Saldo).HasColumnType("decimal(10,2)").HasDefaultValue(0.00);
            builder.HasOne(m=>m.Cuenta).WithMany().HasForeignKey(m => m.IdCuenta);
        }
    }
}
