using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Quinielas.Domain.Entities;

namespace Quinielas.Persistence.Configurations
{
    public class IndiceCatalogoConfiguration : IEntityTypeConfiguration<IndiceCatalogo>
    {
        public void Configure(EntityTypeBuilder<IndiceCatalogo> builder)
        {
            builder.Property(t => t.Nombre).HasMaxLength(100).IsRequired();
        }
    }
}