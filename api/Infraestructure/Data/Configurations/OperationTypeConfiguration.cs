using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructure.Data.Configurations
{
    public class OperationTypeConfiguration : IEntityTypeConfiguration<OperationType>
    {
        public void Configure(EntityTypeBuilder<OperationType> builder)
        {
            builder.HasKey(e => e.Id).HasName("PK__Operatio__3213E83FC1F51002");

            builder.ToTable("OperationType");

            builder.Property(e => e.Id).HasColumnName("id");
            builder.Property(e => e.Active).HasColumnName("active");
            builder.Property(e => e.Code)
                .HasMaxLength(20)
                .HasColumnName("code");
            builder.Property(e => e.CreatedAt).HasColumnName("createdAt");
            builder.Property(e => e.CreatedBy)
                .HasMaxLength(100)
                .HasColumnName("createdBy");
            builder.Property(e => e.Description)
                .HasMaxLength(100)
                .HasColumnName("description");
            builder.Property(e => e.UpdatedAt).HasColumnName("updatedAt");
            builder.Property(e => e.UpdatedBy)
                .HasMaxLength(100)
                .HasColumnName("updatedBy");
        }
    }
}
