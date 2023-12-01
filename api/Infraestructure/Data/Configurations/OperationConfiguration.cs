using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructure.Data.Configurations
{
    public class OperationConfiguration : IEntityTypeConfiguration<Operation>
    {
        public void Configure(EntityTypeBuilder<Operation> builder)
        {
            builder.HasKey(e => e.Id).HasName("PK__Operatio__3213E83FD0A8EE1D");

            builder.ToTable("Operation");

            builder.Property(e => e.Id).HasColumnName("id");
            builder.Property(e => e.Amount)
                .HasColumnType("decimal(38, 5)")
                .HasColumnName("amount");
            builder.Property(e => e.CardId).HasColumnName("cardId");
            builder.Property(e => e.DateTime).HasColumnName("dateTime");
            builder.Property(e => e.OperationTypeId).HasColumnName("operationTypeId");

            builder.HasOne(d => d.Card).WithMany(p => p.Operations)
                .HasForeignKey(d => d.CardId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_operation_cardId");

            builder.HasOne(d => d.OperationType).WithMany(p => p.Operations)
                .HasForeignKey(d => d.OperationTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_operation_operationTypeId");
        }
    }
}
