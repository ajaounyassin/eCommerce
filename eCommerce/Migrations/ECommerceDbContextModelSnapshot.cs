﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Model;

namespace eCommerce.Migrations
{
    [DbContext(typeof(ECommerceDbContext))]
    partial class ECommerceDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Model.Model.Address", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("City")
                        .IsRequired();

                    b.Property<string>("Country");

                    b.Property<int?>("Number")
                        .IsRequired();

                    b.Property<string>("PostCode")
                        .IsRequired();

                    b.Property<string>("Street")
                        .IsRequired();

                    b.Property<Guid?>("UserForeignKey");

                    b.HasKey("Id");

                    b.HasIndex("UserForeignKey")
                        .IsUnique();

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("Model.Model.Article", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<string>("Category");

                    b.Property<DateTime>("DeliveryTime");

                    b.Property<string>("Description");

                    b.Property<string>("Picture");

                    b.Property<decimal>("PriceET");

                    b.Property<int>("Quantity");

                    b.Property<Guid?>("ShoppingCartId");

                    b.Property<decimal>("Tax");

                    b.Property<bool>("Top");

                    b.Property<Guid?>("VendorId");

                    b.Property<string>("Wording");

                    b.HasKey("Id");

                    b.HasIndex("ShoppingCartId");

                    b.HasIndex("VendorId");

                    b.ToTable("Articles");
                });

            modelBuilder.Entity("Model.Model.Comment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("ArticleId");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<DateTime>("SeenAt");

                    b.Property<DateTime>("UpdatedAt");

                    b.Property<Guid?>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("ArticleId");

                    b.HasIndex("UserId");

                    b.ToTable("Comment");
                });

            modelBuilder.Entity("Model.Model.Movement", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("ArticleId");

                    b.Property<DateTime>("Date");

                    b.Property<int>("Quantity");

                    b.HasKey("Id");

                    b.HasIndex("ArticleId");

                    b.ToTable("Movements");
                });

            modelBuilder.Entity("Model.Model.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("BasketId");

                    b.Property<Guid?>("ClientId");

                    b.Property<DateTime>("EstimatedDeliveryDate");

                    b.Property<DateTime>("OrderDate");

                    b.Property<bool>("Payment");

                    b.Property<Guid?>("StatusId");

                    b.HasKey("Id");

                    b.HasIndex("BasketId");

                    b.HasIndex("ClientId");

                    b.HasIndex("StatusId");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("Model.Model.ShoppingCart", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("BuyerId");

                    b.Property<int>("Quantity");

                    b.Property<decimal>("TotalPrice");

                    b.HasKey("Id");

                    b.HasIndex("BuyerId");

                    b.ToTable("ShoppingCarts");
                });

            modelBuilder.Entity("Model.Model.Status", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Status");
                });

            modelBuilder.Entity("Model.Model.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("BirthDate");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<string>("Mail");

                    b.Property<string>("Password");

                    b.Property<int>("Profil");

                    b.Property<int>("Sex");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Model.Model.Address", b =>
                {
                    b.HasOne("Model.Model.User", "User")
                        .WithOne("Address")
                        .HasForeignKey("Model.Model.Address", "UserForeignKey");
                });

            modelBuilder.Entity("Model.Model.Article", b =>
                {
                    b.HasOne("Model.Model.ShoppingCart")
                        .WithMany("Articles")
                        .HasForeignKey("ShoppingCartId");

                    b.HasOne("Model.Model.User", "Vendor")
                        .WithMany("ArticleSale")
                        .HasForeignKey("VendorId");
                });

            modelBuilder.Entity("Model.Model.Comment", b =>
                {
                    b.HasOne("Model.Model.Article", "Article")
                        .WithMany()
                        .HasForeignKey("ArticleId");

                    b.HasOne("Model.Model.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Model.Model.Movement", b =>
                {
                    b.HasOne("Model.Model.Article", "Article")
                        .WithMany()
                        .HasForeignKey("ArticleId");
                });

            modelBuilder.Entity("Model.Model.Order", b =>
                {
                    b.HasOne("Model.Model.ShoppingCart", "Basket")
                        .WithMany()
                        .HasForeignKey("BasketId");

                    b.HasOne("Model.Model.User", "Client")
                        .WithMany()
                        .HasForeignKey("ClientId");

                    b.HasOne("Model.Model.Status", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId");
                });

            modelBuilder.Entity("Model.Model.ShoppingCart", b =>
                {
                    b.HasOne("Model.Model.User", "Buyer")
                        .WithMany()
                        .HasForeignKey("BuyerId");
                });
#pragma warning restore 612, 618
        }
    }
}
