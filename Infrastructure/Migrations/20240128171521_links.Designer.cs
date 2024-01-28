﻿// <auto-generated />
using System;
using Infrastructure.Database.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20240128171521_links")]
    partial class links
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Domain.Database.Product", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Description")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("Description");

                    b.Property<string>("Name")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("Name");

                    b.Property<decimal>("Price")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("Price");

                    b.Property<long?>("ProductCategoryId")
                        .HasColumnType("bigint");

                    b.Property<int>("Stock")
                        .HasColumnType("int")
                        .HasColumnName("Stock");

                    b.Property<long>("StoreId")
                        .HasColumnType("bigint")
                        .HasColumnName("StoreId");

                    b.HasKey("Id")
                        .HasName("pk_Product_Id");

                    b.HasIndex("ProductCategoryId");

                    b.HasIndex("StoreId");

                    b.ToTable("Products", (string)null);
                });

            modelBuilder.Entity("Domain.Database.ProductCategory", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Description");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Name");

                    b.Property<long>("StoreId")
                        .HasColumnType("bigint");

                    b.HasKey("Id")
                        .HasName("pk_ProductCategory_Id");

                    b.HasIndex("StoreId");

                    b.ToTable("ProductCategories", (string)null);
                });

            modelBuilder.Entity("Domain.Database.ProductCategoryLink", b =>
                {
                    b.Property<long>("ProductId")
                        .HasColumnType("bigint")
                        .HasColumnName("ProductId");

                    b.Property<long>("CategoryId")
                        .HasColumnType("bigint")
                        .HasColumnName("CategoryId");

                    b.HasKey("ProductId", "CategoryId")
                        .HasName("pk_ProductCategoryLink_Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("ProductCategoryLinks", (string)null);
                });

            modelBuilder.Entity("Domain.Database.ProductImage", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("ImageUrl");

                    b.Property<long>("ProductId")
                        .HasColumnType("bigint")
                        .HasColumnName("ProductId");

                    b.HasKey("Id")
                        .HasName("pk_ProductImage_Id");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductImages", (string)null);
                });

            modelBuilder.Entity("Domain.Database.ProductMetaTag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ProductMetaTagId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<long>("StoreId")
                        .HasColumnType("bigint")
                        .HasColumnName("StoreId");

                    b.Property<string>("Tag")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Tag");

                    b.HasKey("Id")
                        .HasName("pk_ProductMetaTag_Id");

                    b.HasIndex("StoreId");

                    b.ToTable("ProductMetaTags", (string)null);
                });

            modelBuilder.Entity("Domain.Database.Store", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Address")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("StoreAddress");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("CreatedAt");

                    b.Property<string>("Description")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("StoreDescription");

                    b.Property<string>("Email")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("StoreEmail");

                    b.Property<string>("Name")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("StoreName");

                    b.Property<long>("OwnerId")
                        .HasColumnType("bigint")
                        .HasColumnName("StoreOwnerId");

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("StorePhoneNumber");

                    b.Property<string>("StoreStatusCode")
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id")
                        .HasName("pk_Store_Id");

                    b.HasIndex("OwnerId");

                    b.HasIndex("StoreStatusCode");

                    b.ToTable("Stores", (string)null);
                });

            modelBuilder.Entity("Domain.Database.StoreStatus", b =>
                {
                    b.Property<string>("StoreStatusCode")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("StoreStatusCode");

                    b.Property<string>("Description")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("StoreStatusDescription");

                    b.HasKey("StoreStatusCode")
                        .HasName("pk_StoreStatus_Code");

                    b.ToTable("StoreStatuses", (string)null);
                });

            modelBuilder.Entity("Domain.Database.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("CreatedAt");

                    b.Property<string>("Email")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("Email");

                    b.Property<string>("FirstName")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("FirstName");

                    b.Property<string>("LastName")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("LastName");

                    b.Property<string>("PasswordHash")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("PasswordHash");

                    b.Property<string>("Salt")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Salt");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("UpdatedAt");

                    b.HasKey("Id")
                        .HasName("pk_User_Id");

                    b.ToTable("Users", (string)null);
                });

            modelBuilder.Entity("ProductProductMetaTag", b =>
                {
                    b.Property<int>("ProductMetaTagsId")
                        .HasColumnType("int");

                    b.Property<long>("ProductsId")
                        .HasColumnType("bigint");

                    b.HasKey("ProductMetaTagsId", "ProductsId");

                    b.HasIndex("ProductsId");

                    b.ToTable("ProductProductMetaTag");
                });

            modelBuilder.Entity("Domain.Database.Product", b =>
                {
                    b.HasOne("Domain.Database.ProductCategory", null)
                        .WithMany("Products")
                        .HasForeignKey("ProductCategoryId");

                    b.HasOne("Domain.Database.Store", "Store")
                        .WithMany("Products")
                        .HasForeignKey("StoreId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired()
                        .HasConstraintName("fk_Store_Product");

                    b.Navigation("Store");
                });

            modelBuilder.Entity("Domain.Database.ProductCategory", b =>
                {
                    b.HasOne("Domain.Database.Store", "Store")
                        .WithMany()
                        .HasForeignKey("StoreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Store");
                });

            modelBuilder.Entity("Domain.Database.ProductCategoryLink", b =>
                {
                    b.HasOne("Domain.Database.ProductCategory", "Category")
                        .WithMany("ProductCategoryLinks")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Database.Product", "Product")
                        .WithMany("ProductCategoryLinks")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Domain.Database.ProductImage", b =>
                {
                    b.HasOne("Domain.Database.Product", "Product")
                        .WithMany("ProductImages")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired()
                        .HasConstraintName("fk_Product_ProductImage");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Domain.Database.ProductMetaTag", b =>
                {
                    b.HasOne("Domain.Database.Store", "Store")
                        .WithMany("ProductMetaTags")
                        .HasForeignKey("StoreId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired()
                        .HasConstraintName("fk_Store_ProductMetaTag");

                    b.Navigation("Store");
                });

            modelBuilder.Entity("Domain.Database.Store", b =>
                {
                    b.HasOne("Domain.Database.User", "Owner")
                        .WithMany("Stores")
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_StoreOwner_Store");

                    b.HasOne("Domain.Database.StoreStatus", "StoreStatus")
                        .WithMany("Stores")
                        .HasForeignKey("StoreStatusCode")
                        .HasConstraintName("fk_StoreStatus_Store");

                    b.Navigation("Owner");

                    b.Navigation("StoreStatus");
                });

            modelBuilder.Entity("ProductProductMetaTag", b =>
                {
                    b.HasOne("Domain.Database.ProductMetaTag", null)
                        .WithMany()
                        .HasForeignKey("ProductMetaTagsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Database.Product", null)
                        .WithMany()
                        .HasForeignKey("ProductsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Database.Product", b =>
                {
                    b.Navigation("ProductCategoryLinks");

                    b.Navigation("ProductImages");
                });

            modelBuilder.Entity("Domain.Database.ProductCategory", b =>
                {
                    b.Navigation("ProductCategoryLinks");

                    b.Navigation("Products");
                });

            modelBuilder.Entity("Domain.Database.Store", b =>
                {
                    b.Navigation("ProductMetaTags");

                    b.Navigation("Products");
                });

            modelBuilder.Entity("Domain.Database.StoreStatus", b =>
                {
                    b.Navigation("Stores");
                });

            modelBuilder.Entity("Domain.Database.User", b =>
                {
                    b.Navigation("Stores");
                });
#pragma warning restore 612, 618
        }
    }
}
