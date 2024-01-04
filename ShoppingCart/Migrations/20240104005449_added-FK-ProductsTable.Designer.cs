﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ShoppingCart.Data;

#nullable disable

namespace ShoppingCart.Migrations
{
    [DbContext(typeof(ShoppingCartContext))]
    [Migration("20240104005449_added-FK-ProductsTable")]
    partial class addedFKProductsTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.23")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ShoppingCart.Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryId"), 1L, 1);

                    b.Property<int>("DisplayOrder")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("CategoryId");

                    b.ToTable("Category");

                    b.HasData(
                        new
                        {
                            CategoryId = 1,
                            DisplayOrder = 1,
                            Name = "Comedy"
                        },
                        new
                        {
                            CategoryId = 2,
                            DisplayOrder = 2,
                            Name = "Action"
                        },
                        new
                        {
                            CategoryId = 3,
                            DisplayOrder = 3,
                            Name = "Fiction"
                        });
                });

            modelBuilder.Entity("ShoppingCart.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ISBN")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("ListPrice")
                        .HasColumnType("float");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Author = "Harper Lee",
                            CategoryId = 0,
                            Description = "believed to be one of the most influential authors to have ever existed, famously published only a single novel",
                            ISBN = "SWV0001",
                            ListPrice = 99.0,
                            Title = "To Kill a Mockingbird"
                        },
                        new
                        {
                            Id = 2,
                            Author = "Nick Carraway",
                            CategoryId = 0,
                            Description = "is distinguished as one of the greatest texts for introducing students to the art of reading literature critically ",
                            ISBN = "SWV00078",
                            ListPrice = 100.0,
                            Title = "The Great Gatsby"
                        },
                        new
                        {
                            Id = 3,
                            Author = "Gabriel García Márquez",
                            CategoryId = 0,
                            Description = "The novel tells the story of seven generations of the Buendía family and follows the establishment of their town",
                            ISBN = "SWV0002",
                            ListPrice = 101.0,
                            Title = "One Hundred Years of Solitude"
                        });
                });

            modelBuilder.Entity("ShoppingCart.Models.Product", b =>
                {
                    b.HasOne("ShoppingCart.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });
#pragma warning restore 612, 618
        }
    }
}
