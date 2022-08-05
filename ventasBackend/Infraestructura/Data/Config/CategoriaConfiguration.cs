using Core.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructura.Data.Config
{
    public class CategoriaConfiguration: IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            builder.Property( c => c.CategoriaId).IsRequired();
            builder.Property( c => c.NombreCategoria).IsRequired().HasMaxLength(150);
            builder.Property( c => c.FechaCaptura).IsRequired().HasMaxLength(50);
        }
    }
}