using BeerC0d3.Core.Entities.Seguridad;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerC0d3.Infrastructure.Data.Configuration
{
    public class RolConfiguration : IEntityTypeConfiguration<Rol>
    {
        public void Configure(EntityTypeBuilder<Rol> builder)
        {
            builder.ToTable("Rol","Seguridad");
            builder.Property(p => p.Id)
                    .IsRequired();
                    
            builder.Property(p => p.Nombre)
                    .IsRequired()
                    .HasColumnType("varchar")
                    .HasMaxLength(200);
        }
    }
}
