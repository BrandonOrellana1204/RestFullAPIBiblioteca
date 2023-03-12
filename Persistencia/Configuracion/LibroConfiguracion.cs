using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Dominio.Entidades;

namespace Persistencia.Configuracion
{
    public class LibroConfiguracion : IEntityTypeConfiguration<Libro>
    {
        public void Configure(EntityTypeBuilder<Libro> builder)
        {
            builder.ToTable("Libros");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.TituloLibro)
                .HasMaxLength(200)
                .IsRequired();
            builder.Property(p => p.CantidadPaginas)
                .IsRequired();
            builder.Property(p => p.Editorial)
                .IsRequired();
            builder.Property(p => p.cantidad)
                 .IsRequired();
            builder.Property(p => p.Creadopor);
            // .IsRequired();
            builder.Property(p => p.UltimaModificacionPor);
              // .IsRequired();
        }
    }
}
