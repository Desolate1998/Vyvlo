using Domain.Database;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database.Context;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions options) : base(options)
    {

    }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("Users");

            entity.Property(p => p.UserID)
                  .HasColumnName("UserID");

            entity.Property(p => p.Email)
                  .HasMaxLength(255)
                  .HasColumnName("Email");

            entity.Property(p => p.PasswordHash)
                  .HasMaxLength(255)
                  .HasColumnName("PasswordHash");

            entity.Property(p => p.FirstName)
                  .HasMaxLength(255)
                  .HasColumnName("FirstName");

            entity.Property(p => p.LastName)
                  .HasMaxLength(255)
                  .HasColumnName("LastName");

            entity.Property(p => p.CreatedAt)
                  .HasColumnName("CreatedAt");

            entity.Property(p => p.UpdatedAt)
                  .HasColumnName("UpdatedAt");

            entity.Property(p => p.Salt)
                  .HasColumnName("Salt");
        });

    }

}