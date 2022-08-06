using Core.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructura.Data.Config
{
    public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.Property( c => c.ClienteId).IsRequired();
            builder.Property( c => c.Nombre).IsRequired().HasMaxLength(30);
            builder.Property( c => c.Apellido).IsRequired().HasMaxLength(30);
            builder.Property( c => c.Direccion).IsRequired().HasMaxLength(100);
            builder.Property( c => c.Email).IsRequired().HasMaxLength(150);
            builder.Property( c => c.Telefono).IsRequired().HasMaxLength(30);
            builder.Property( c => c.Rfc).IsRequired().HasMaxLength(30);
            builder.Property( c => c.UsuarioId).IsRequired().HasMaxLength(50);

            //TODO Relaciones
            builder.HasOne(c => c.Usuario).WithMany()
            .HasForeignKey(c => c.UsuarioId);
        }
    }
}