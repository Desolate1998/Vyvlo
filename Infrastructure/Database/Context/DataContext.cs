using Domain.Common.ProductCategories;
using Domain.Database;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database.Context;

public class DataContext(DbContextOptions options) : DbContext(options)
{
    public virtual DbSet<User> Users { get; init; }
    public virtual DbSet<Store> Stores { get; init; }
    public virtual DbSet<StoreStatus> StoreStatuses { get; init; }
    public virtual DbSet<Product> Products { get; init; }
    public virtual DbSet<ProductMetaTag> ProductMetaTags { get; init; }
    public virtual DbSet<ProductCategory> ProductCategories { get; init; }
    public virtual DbSet<ProductCategoryLink> ProductCategoryLinks { get; init; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("Users");

            entity.HasKey(p => p.Id)
                  .HasName("pk_User_Id");

            entity.Property(p => p.Id)
                  .HasColumnName("Id");

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

            entity.HasMany(p => p.Stores)
                  .WithOne(p => p.Owner)
                  .HasConstraintName("fk_Store_StoreOwner");

        });

        modelBuilder.Entity<Store>(entity =>
        {
            entity.ToTable("Stores");

            entity.HasKey(p => p.Id)
                  .HasName("pk_Store_Id");

            entity.Property(p => p.Id)
                  .HasColumnName("Id");

            entity.Property(p => p.OwnerId)
                  .HasColumnName("StoreOwnerId");

            entity.Property(p => p.Name)
                  .HasMaxLength(255)
                  .HasColumnName("StoreName");

            entity.Property(p => p.Address)
                  .HasMaxLength(255)
                  .HasColumnName("StoreAddress");

            entity.Property(p => p.PhoneNumber)
                  .HasMaxLength(255)
                  .HasColumnName("StorePhoneNumber");

            entity.Property(p => p.Email)
                  .HasMaxLength(255)
                  .HasColumnName("StoreEmail");

            entity.Property(p => p.Description)
                  .HasMaxLength(255)
                  .HasColumnName("StoreDescription");

            entity.Property(p => p.CreatedAt)
                  .HasColumnName("CreatedAt");

            entity.HasOne(p => p.Owner).WithMany(p => p.Stores)
                  .HasForeignKey(p => p.OwnerId)
                  .HasConstraintName("fk_StoreOwner_Store");

            entity.HasOne(p => p.StoreStatus)
                  .WithMany(p => p.Stores)
                  .HasForeignKey(p => p.StoreStatusCode)
                  .HasConstraintName("fk_Store_StoreStatus");
        });

        modelBuilder.Entity<StoreStatus>(entity =>
        {
            entity.ToTable("StoreStatuses");

            entity.HasKey(p => p.StoreStatusCode)
                  .HasName("pk_StoreStatus_Code");

            entity.Property(p => p.StoreStatusCode)
                  .HasMaxLength(255)
                  .HasColumnName("StoreStatusCode");

            entity.Property(p => p.Description)
                  .HasMaxLength(255)
                  .HasColumnName("StoreStatusDescription");

            entity.HasMany(p => p.Stores)
                  .WithOne(p => p.StoreStatus)
                  .HasConstraintName("fk_StoreStatus_Store");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.ToTable("Products");

            entity.HasKey(p => p.Id)
                  .HasName("pk_Product_Id");

            entity.Property(p => p.Id)
                  .HasColumnName("Id");

            entity.Property(p => p.StoreId)
                  .HasColumnName("StoreId");

            entity.Property(p => p.Name)
                  .HasMaxLength(255)
                  .HasColumnName("Name");

            entity.Property(p => p.Description)
                  .HasMaxLength(255)
                  .HasColumnName("Description");

            entity.Property(p => p.Price)
                  .HasColumnName("Price")
                  .HasPrecision(18, 2);


            entity.Property(p => p.Stock)
                  .HasColumnName("Stock");

            entity.HasOne(p => p.Store)
                  .WithMany(p => p.Products)
                  .HasForeignKey(p => p.StoreId)
                  .HasConstraintName("fk_Store_Product")
                  .OnDelete(DeleteBehavior.NoAction);

            entity.HasMany(p => p.ProductCategoryLinks)
                .WithOne(pc => pc.Product)
                .HasForeignKey(pc => pc.ProductId);

            entity.HasMany(p => p.ProductMetaTags)
                  .WithMany(p => p.Products);

        });

        modelBuilder.Entity<ProductMetaTag>(entity =>
        {
            entity.ToTable("ProductMetaTags");

            entity.HasKey(p => p.Id)
                  .HasName("pk_ProductMetaTag_Id");

            entity.Property(p => p.Id)
                  .HasColumnName("ProductMetaTagId");

            entity.Property(p => p.StoreId)
                  .HasColumnName("StoreId");

            entity.HasOne(p => p.Store)
                  .WithMany(p => p.ProductMetaTags)
                  .HasForeignKey(p => p.StoreId)
                  .HasConstraintName("fk_Store_ProductMetaTag")
                  .OnDelete(DeleteBehavior.NoAction);

            entity.Property(p => p.Tag)
                  .HasColumnName("Tag");
        });

        modelBuilder.Entity<ProductCategory>(entity =>
        {
            entity.ToTable("ProductCategories");

            entity.HasKey(p => p.Id)
                  .HasName("pk_ProductCategory_Id");

            entity.Property(p => p.Id)
                  .HasColumnName("Id");

            entity.Property(p => p.Name)
                  .HasColumnName("Name");

            entity.Property(p => p.Description)
                  .HasColumnName("Description");

            entity.HasMany(pc => pc.ProductCategoryLinks)
                .WithOne(link => link.Category)
                .HasForeignKey(link => link.CategoryId);

        });

        modelBuilder.Entity<ProductCategoryLink>(entity =>
        {
            entity.ToTable("ProductCategoryLinks");

            entity.HasKey(p => new { p.ProductId, p.CategoryId })
                  .HasName("pk_ProductCategoryLink_Id");


            entity.Property(p => p.ProductId)
                  .HasColumnName("ProductId");

            entity.Property(p => p.CategoryId)
                  .HasColumnName("CategoryId");

            entity.HasOne(pc => pc.Product)
                .WithMany(p => p.ProductCategoryLinks)
                .HasForeignKey(pc => pc.ProductId);

            entity.HasOne(pc => pc.Category)
                .WithMany(c => c.ProductCategoryLinks)
                .HasForeignKey(pc => pc.CategoryId);
        });

        modelBuilder.Entity<ProductImage>(entity =>
        {
            entity.ToTable("ProductImages");

            entity.HasKey(p => p.Id)
                  .HasName("pk_ProductImage_Id");

            entity.Property(p => p.Id)
                  .HasColumnName("Id");

            entity.Property(p => p.ProductId)
                  .HasColumnName("ProductId");

            entity.Property(p => p.ImageUrl)
                  .HasColumnName("ImageUrl");

            entity.HasOne(p => p.Product)
                  .WithMany(p => p.ProductImages)
                  .HasForeignKey(p => p.ProductId)
                  .HasConstraintName("fk_Product_ProductImage")
                  .OnDelete(DeleteBehavior.NoAction);
        });
    }
}