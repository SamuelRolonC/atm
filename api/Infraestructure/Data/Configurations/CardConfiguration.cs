using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructure.Data.Configurations
{
    public class CardConfiguration : IEntityTypeConfiguration<Card>
    {
        public void Configure(EntityTypeBuilder<Card> builder)
        {
            builder.HasKey(e => e.Id).HasName("PK__Card__3213E83F8DF548E0");
            builder.ToTable("Card");

            builder.HasIndex(e => e.Number, "UQ__Card__FD291E4133171924").IsUnique();

            builder.Property(e => e.Id).HasColumnName("id");
            builder.Property(e => e.Active).HasColumnName("active");
            builder.Property(e => e.Balance)
                .HasColumnType("decimal(38, 5)")
                .HasColumnName("balance");
            builder.Property(e => e.CreatedAt).HasColumnName("createdAt");
            builder.Property(e => e.CreatedBy)
                .HasMaxLength(100)
                .HasColumnName("createdBy");
            builder.Property(e => e.DueDate)
                .HasColumnType("date")
                .HasColumnName("dueDate");
            builder.Property(e => e.FailAttempts).HasColumnName("failAttempts");
            builder.Property(e => e.IsBlocked).HasColumnName("isBlocked");
            builder.Property(e => e.Number)
                .HasMaxLength(16)
                .HasColumnName("number");
            builder.Property(e => e.Pin)
                .HasMaxLength(4)
                .HasColumnName("pin");
            builder.Property(e => e.UpdatedAt).HasColumnName("updatedAt");
            builder.Property(e => e.UpdatedBy)
                .HasMaxLength(100)
                .HasColumnName("updatedBy");
            builder.Property(e => e.UserId).HasColumnName("userId");

            builder.HasOne(d => d.User).WithMany(p => p.Cards)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_card_userId");
        }
    }
}
