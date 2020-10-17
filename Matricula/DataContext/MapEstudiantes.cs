using Matricula.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Matricula.DataContext
{
    public class MapEstudiantes : IEntityTypeConfiguration<Estudiante> { 
        
        public void Configure(EntityTypeBuilder<Estudiante> builder)
        {
            builder.ToTable("Estudiantes", "dbo");
            builder.HasKey(q => q.id);
            builder.Property(e => e.id).IsRequired().UseIdentityColumn();
            builder.Property(e => e.nombre).HasColumnType("varchar(50)").HasMaxLength(50).IsRequired();

            builder.HasOne(e => e.Curso)
                .WithMany(e => e.Estudiantes)
                .HasForeignKey(e => e.CursoId);
        }
  
    }
}
