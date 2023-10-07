using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Data;

public partial class AtmContext : DbContext
{
    public AtmContext()
    {
    }

    public AtmContext(DbContextOptions<AtmContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Card> Cards { get; set; }

    public virtual DbSet<Operation> Operations { get; set; }

    public virtual DbSet<OperationType> OperationTypes { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Card>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Card__3213E83F8DF548E0");

            entity.ToTable("Card");

            entity.HasIndex(e => e.Number, "UQ__Card__FD291E4133171924").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Active).HasColumnName("active");
            entity.Property(e => e.Balance)
                .HasColumnType("decimal(38, 5)")
                .HasColumnName("balance");
            entity.Property(e => e.CreatedAt).HasColumnName("createdAt");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(100)
                .HasColumnName("createdBy");
            entity.Property(e => e.DueDate)
                .HasColumnType("date")
                .HasColumnName("dueDate");
            entity.Property(e => e.FailAttempts).HasColumnName("failAttempts");
            entity.Property(e => e.IsBlocked).HasColumnName("isBlocked");
            entity.Property(e => e.Number)
                .HasMaxLength(16)
                .HasColumnName("number");
            entity.Property(e => e.Pin)
                .HasMaxLength(4)
                .HasColumnName("pin");
            entity.Property(e => e.UpdatedAt).HasColumnName("updatedAt");
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(100)
                .HasColumnName("updatedBy");
            entity.Property(e => e.UserId).HasColumnName("userId");

            entity.HasOne(d => d.User).WithMany(p => p.Cards)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_card_userId");
        });

        modelBuilder.Entity<Operation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Operatio__3213E83FD0A8EE1D");

            entity.ToTable("Operation");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Amount)
                .HasColumnType("decimal(38, 5)")
                .HasColumnName("amount");
            entity.Property(e => e.CardId).HasColumnName("cardId");
            entity.Property(e => e.DateTime).HasColumnName("dateTime");
            entity.Property(e => e.OperationTypeId).HasColumnName("operationTypeId");

            entity.HasOne(d => d.Card).WithMany(p => p.Operations)
                .HasForeignKey(d => d.CardId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_operation_cardId");

            entity.HasOne(d => d.OperationType).WithMany(p => p.Operations)
                .HasForeignKey(d => d.OperationTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_operation_operationTypeId");
        });

        modelBuilder.Entity<OperationType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Operatio__3213E83FC1F51002");

            entity.ToTable("OperationType");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Active).HasColumnName("active");
            entity.Property(e => e.Code)
                .HasMaxLength(20)
                .HasColumnName("code");
            entity.Property(e => e.CreatedAt).HasColumnName("createdAt");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(100)
                .HasColumnName("createdBy");
            entity.Property(e => e.Description)
                .HasMaxLength(100)
                .HasColumnName("description");
            entity.Property(e => e.UpdatedAt).HasColumnName("updatedAt");
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(100)
                .HasColumnName("updatedBy");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__User__3213E83FEA0F25C2");

            entity.ToTable("User");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Active).HasColumnName("active");
            entity.Property(e => e.CreatedAt).HasColumnName("createdAt");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(100)
                .HasColumnName("createdBy");
            entity.Property(e => e.IdentityNumber)
                .HasMaxLength(10)
                .HasColumnName("identityNumber");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.Surname)
                .HasMaxLength(255)
                .HasColumnName("surname");
            entity.Property(e => e.UpdatedAt).HasColumnName("updatedAt");
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(100)
                .HasColumnName("updatedBy");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
