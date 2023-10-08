using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructure.Data.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(e => e.Id).HasName("PK__User__3213E83FEA0F25C2");
            builder.ToTable("User");

            builder.Property(e => e.Id).HasColumnName("id");
            builder.Property(e => e.Active).HasColumnName("active");
            builder.Property(e => e.CreatedAt).HasColumnName("createdAt");
            builder.Property(e => e.CreatedBy)
                .HasMaxLength(100)
                .HasColumnName("createdBy");
            builder.Property(e => e.IdentityNumber)
                .HasMaxLength(10)
                .HasColumnName("identityNumber");
            builder.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            builder.Property(e => e.Surname)
                .HasMaxLength(255)
                .HasColumnName("surname");
            builder.Property(e => e.UpdatedAt).HasColumnName("updatedAt");
            builder.Property(e => e.UpdatedBy)
                .HasMaxLength(100)
                .HasColumnName("updatedBy");
        }
    }
}
