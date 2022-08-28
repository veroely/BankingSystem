using BankingSystem.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BankingSystem.Infrastructure.Repository.Configuration
{
    public class ParametroConfiguration : IEntityTypeConfiguration<Parametro>
    {
        public void Configure(EntityTypeBuilder<Parametro> builder)
        {
            builder.HasKey(c => c.IdParametro);
            builder.Property(c => c.Codigo).IsRequired().HasMaxLength(32);
            builder.Property(c => c.Valor).HasColumnType("decimal(10,2)").HasDefaultValue(0.00);
        }
    }
}
