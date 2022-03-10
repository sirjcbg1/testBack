using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configuration
{
    public class IngresoConfig : IEntityTypeConfiguration<Ingreso>
    {
        public void Configure(EntityTypeBuilder<Ingreso> builder) 
        {
            builder.ToTable("Ingreso");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Name)
                   .HasMaxLength(20)
                   .IsRequired();
            builder.Property(p => p.LastName)
                   .HasMaxLength(20)
                   .IsRequired();
            builder.Property(p => p.Identification)
                   .HasMaxLength(10)
                   .IsRequired();
            builder.Property(p => p.House)
                   .HasMaxLength(30)
                   .IsRequired();
            builder.Property(p => p.FechaNacimiento)
                   .IsRequired();
            builder.Property(p => p.Edad);
            builder.Property(p => p.CreatedBy)
                  .HasMaxLength(30);
            builder.Property(p => p.LastModifiedBy)
                  .HasMaxLength(30);
        }
    }
}
