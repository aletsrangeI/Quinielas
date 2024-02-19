using Quinielas.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Quinielas.Persistence.Configurations
{
    public class ContenidoCatalogoConfiguration : IEntityTypeConfiguration<ContenidoCatalogo>
    {
        public void Configure(EntityTypeBuilder<ContenidoCatalogo> builder)
        {
            builder.Property(t => t.Categoria).HasMaxLength(100).IsRequired();
            builder.Property(t => t.Descripcion).HasMaxLength(100).IsRequired();
        }
    }
}