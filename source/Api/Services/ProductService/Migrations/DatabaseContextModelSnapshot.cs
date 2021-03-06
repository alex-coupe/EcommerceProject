﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProductService.Models;

namespace ProductService.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.3")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CategorySubCategory", b =>
                {
                    b.Property<int>("CategoriesId")
                        .HasColumnType("int");

                    b.Property<int>("SubCategoriesId")
                        .HasColumnType("int");

                    b.HasKey("CategoriesId", "SubCategoriesId");

                    b.HasIndex("SubCategoriesId");

                    b.ToTable("CategorySubCategory");
                });

            modelBuilder.Entity("ProductService.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Men"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Women"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Kids"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Accessories"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Sales & Discounts"
                        });
                });

            modelBuilder.Entity("ProductService.Models.Image", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AltText")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FilePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("ProductService.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("ProductImageId")
                        .HasColumnType("int");

                    b.Property<string>("Slug")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SubCategory")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SubCategoryId")
                        .HasColumnType("int");

                    b.Property<decimal>("UnitPrice")
                        .HasColumnType("decimal(18,3)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("ProductImageId");

                    b.HasIndex("SubCategoryId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("ProductService.Models.ProductVariant", b =>
                {
                    b.Property<int>("Sku")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Size")
                        .HasColumnType("int");

                    b.HasKey("Sku");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductVariants");
                });

            modelBuilder.Entity("ProductService.Models.SubCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("SubCategories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Jeans"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Blazers"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Coats & Jackets"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Suits"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Underwear & Socks"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Trainers & Shoes"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Hoodies & Sweatshirts"
                        },
                        new
                        {
                            Id = 8,
                            Name = "Dresses & Skirts"
                        },
                        new
                        {
                            Id = 9,
                            Name = "Playsuits & Jumpsuits"
                        },
                        new
                        {
                            Id = 10,
                            Name = "Nightwear"
                        },
                        new
                        {
                            Id = 11,
                            Name = "Boots"
                        },
                        new
                        {
                            Id = 12,
                            Name = "Flip-Flops & Sandals"
                        },
                        new
                        {
                            Id = 13,
                            Name = "Babywear"
                        },
                        new
                        {
                            Id = 14,
                            Name = "Tracksuits"
                        },
                        new
                        {
                            Id = 15,
                            Name = "Shorts"
                        },
                        new
                        {
                            Id = 16,
                            Name = "Bags"
                        },
                        new
                        {
                            Id = 17,
                            Name = "Hats, Scarves & Gloves"
                        },
                        new
                        {
                            Id = 18,
                            Name = "Belts"
                        },
                        new
                        {
                            Id = 19,
                            Name = "Jewellery & Watches"
                        },
                        new
                        {
                            Id = 20,
                            Name = "Sunglasses"
                        },
                        new
                        {
                            Id = 21,
                            Name = "Wallets"
                        });
                });

            modelBuilder.Entity("CategorySubCategory", b =>
                {
                    b.HasOne("ProductService.Models.Category", null)
                        .WithMany()
                        .HasForeignKey("CategoriesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProductService.Models.SubCategory", null)
                        .WithMany()
                        .HasForeignKey("SubCategoriesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ProductService.Models.Product", b =>
                {
                    b.HasOne("ProductService.Models.Category", null)
                        .WithMany("Products")
                        .HasForeignKey("CategoryId");

                    b.HasOne("ProductService.Models.Image", "ProductImage")
                        .WithMany()
                        .HasForeignKey("ProductImageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProductService.Models.SubCategory", null)
                        .WithMany("Products")
                        .HasForeignKey("SubCategoryId");

                    b.Navigation("ProductImage");
                });

            modelBuilder.Entity("ProductService.Models.ProductVariant", b =>
                {
                    b.HasOne("ProductService.Models.Product", null)
                        .WithMany("Sizes")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ProductService.Models.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("ProductService.Models.Product", b =>
                {
                    b.Navigation("Sizes");
                });

            modelBuilder.Entity("ProductService.Models.SubCategory", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
