using BankingSystem.Core.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BankingSystem.Infrastructure.Repository.Configuration
{
    public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.HasKey(c => c.IdCliente);
            builder.Property(c => c.Nombre).IsRequired().HasMaxLength(256);
            builder.Property(c => c.Identificacion).IsRequired().HasMaxLength(16);
            builder.Property(c => c.Direccion).IsRequired().HasMaxLength(256);
            builder.Property(c => c.Telefono).IsRequired().HasMaxLength(16);
            builder.Property(c => c.Contrasenia).IsRequired().HasMaxLength(64);

        }
    }
}
