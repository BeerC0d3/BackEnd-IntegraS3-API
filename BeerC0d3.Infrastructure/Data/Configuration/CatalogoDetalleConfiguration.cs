using BeerC0d3.Core.Entities.Sistema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerC0d3.Infrastructure.Data.Configuration
{
    public class CatalogoDetalleConfiguration: IEntityTypeConfiguration<CatalogoDetalle>
    {
        public void Configure(EntityTypeBuilder<CatalogoDetalle> builder)
        {
            builder.ToTable("CatalogoDetalle", "Sistema");
            builder.Property(c => c.Id)
               .ValueGeneratedOnAdd()
                   .IsRequired();

            builder.Property(c => c.Clave)
                    .IsRequired()
                    .HasColumnType("varchar")
                    .HasMaxLength(50);


            builder.Property(c => c.Descripcion)
                    .IsRequired()
                    .HasColumnType("varchar")
                    .HasMaxLength(200);

            builder.HasOne(c => c.Catalogo)
                   .WithMany(c => c.CatalogoDetalles)
                   .HasForeignKey(c => c.CatId);



        }
    }
}
