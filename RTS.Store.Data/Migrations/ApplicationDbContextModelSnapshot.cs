﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RTS.Store.Web.Data;

#nullable disable

namespace RTS.Store.Web.Data.Migrations
{
    [DbContext(typeof(StoreDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.19")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("RTS.Store.Data.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)")
                        .HasDefaultValue("Бай");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)")
                        .HasDefaultValue("Иван");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "ddcb42c8-a394-45cd-82ae-b1e71d5c693e",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "df0df705-a18d-49b5-8138-dc455f5efebb",
                            Email = "rosenSeller@abv.bg",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "ROSENSELLER@ABV.BG",
                            NormalizedUserName = "ROSENSELLER@ABV.BG",
                            PasswordHash = "AQAAAAEAACcQAAAAEBguR4wikd39lPPgjmKzfjEMBl1jbyBM3CQJMip3Uywv/5WY8MSucTgr26LOMag0Rg==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "540c07e2-8148-46da-a844-45089488663e",
                            TwoFactorEnabled = false,
                            UserName = "rosenSeller@abv.bg"
                        },
                        new
                        {
                            Id = "3c11c7aa-d85a-462a-931e-adcc203d21f4",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "7205025f-2646-40a9-a11a-851ee9ff00c2",
                            Email = "yavorSeller@abv.bg",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "YAVORSELLER@ABV.BG",
                            NormalizedUserName = "YAVORSELLER@ABV.BG",
                            PasswordHash = "AQAAAAEAACcQAAAAEC/OBYyaBnBNvWziIuKDnE/HhZAB/DOGC6j8ZQmAv/PkcypjMYYIFv/03Gt+M81wPg==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "1fbae9e0-944e-4e1f-90b7-1301ef60d5e5",
                            TwoFactorEnabled = false,
                            UserName = "yavorSeller@abv.bg"
                        });
                });

            modelBuilder.Entity("RTS.Store.Data.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Car"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Food"
                        },
                        new
                        {
                            Id = 3,
                            Name = "For home"
                        });
                });

            modelBuilder.Entity("RTS.Store.Data.Models.Payment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("CCV")
                        .HasColumnType("int");

                    b.Property<string>("CardName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EpiryDate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("NumberOfCard")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("RTS.Store.Data.Models.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("BuyerId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedOn")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasMaxLength(2048)
                        .HasColumnType("nvarchar(2048)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<decimal?>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("QuantityInStock")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid>("SellerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ShopingCardId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("BuyerId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("SellerId");

                    b.HasIndex("ShopingCardId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = new Guid("570c58a9-7d93-4b1b-a1e9-a778f94d9d06"),
                            CategoryId = 1,
                            CreatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "BMW 530d e39, 193к.с Година: 2002 , Цвят:Синя , Екстри:Подгрев на /редните/ седалки , Мултиволан, Темпомат, ",
                            ImageUrl = "https://encrypted-tbn0.gstatic.com/images?//=tbn:ANd9GcTqi0u80NkjoORAddgNXSmZM-2qx_vlwnaJbg&usqp=CAU",
                            IsActive = true,
                            Name = "BMW 530D",
                            Price = 10000.00m,
                            QuantityInStock = 1m,
                            SellerId = new Guid("d111a3be-2961-4d6f-8a00-9fae1ecf9cd7")
                        },
                        new
                        {
                            Id = new Guid("5211c8cd-bc4c-41c6-aa72-bca634315dc9"),
                            CategoryId = 2,
                            CreatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Прасето е от породата Landrace и е 150 кг.Цена за килограм е 10 лв..",
                            ImageUrl = "https://encrypted-tbn0.gstatic.com/images?//=tbn:ANd9GcTQIRWQanNZMfTV3IsSgZpNuq6VulEr0cP1iQ&usqp=CAU",
                            IsActive = true,
                            Name = "Прасе",
                            Price = 1500.00m,
                            QuantityInStock = 5m,
                            SellerId = new Guid("7b427f6a-a62a-44c5-948f-6d78f524cebe")
                        },
                        new
                        {
                            Id = new Guid("47355a7a-89a1-47b9-b5c5-35329a297a48"),
                            CategoryId = 3,
                            CreatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Дивана е дълъг 245 см., лежанката е 175 см.",
                            ImageUrl = "https://ivveks.com/wp-content/uploads/2021/09/bri-1-scaled.jpg",
                            IsActive = true,
                            Name = "Диван",
                            Price = 2000.00m,
                            QuantityInStock = 1m,
                            SellerId = new Guid("7b427f6a-a62a-44c5-948f-6d78f524cebe")
                        });
                });

            modelBuilder.Entity("RTS.Store.Data.Models.Seller", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Sellers");

                    b.HasData(
                        new
                        {
                            Id = new Guid("7b427f6a-a62a-44c5-948f-6d78f524cebe"),
                            PhoneNumber = "0899495555",
                            UserId = "3c11c7aa-d85a-462a-931e-adcc203d21f4"
                        },
                        new
                        {
                            Id = new Guid("d111a3be-2961-4d6f-8a00-9fae1ecf9cd7"),
                            PhoneNumber = "0897556677",
                            UserId = "ddcb42c8-a394-45cd-82ae-b1e71d5c693e"
                        });
                });

            modelBuilder.Entity("RTS.Store.Data.Models.ShopingCard", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal?>("OrderTotal")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid?>("PaymentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ShipingAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("PaymentId");

                    b.HasIndex("UserId");

                    b.ToTable("ShopingCards");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("RTS.Store.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("RTS.Store.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RTS.Store.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("RTS.Store.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RTS.Store.Data.Models.Product", b =>
                {
                    b.HasOne("RTS.Store.Data.Models.ApplicationUser", "Buyer")
                        .WithMany("BuyProduct")
                        .HasForeignKey("BuyerId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("RTS.Store.Data.Models.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("RTS.Store.Data.Models.Seller", "Seller")
                        .WithMany("SellerProduct")
                        .HasForeignKey("SellerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("RTS.Store.Data.Models.ShopingCard", "ShopingCard")
                        .WithMany("Products")
                        .HasForeignKey("ShopingCardId");

                    b.Navigation("Buyer");

                    b.Navigation("Category");

                    b.Navigation("Seller");

                    b.Navigation("ShopingCard");
                });

            modelBuilder.Entity("RTS.Store.Data.Models.Seller", b =>
                {
                    b.HasOne("RTS.Store.Data.Models.ApplicationUser", "User")
                        .WithMany("Sellers")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("RTS.Store.Data.Models.ShopingCard", b =>
                {
                    b.HasOne("RTS.Store.Data.Models.Payment", "Payment")
                        .WithMany("ShopingCards")
                        .HasForeignKey("PaymentId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("RTS.Store.Data.Models.ApplicationUser", "User")
                        .WithMany("ShopingCards")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Payment");

                    b.Navigation("User");
                });

            modelBuilder.Entity("RTS.Store.Data.Models.ApplicationUser", b =>
                {
                    b.Navigation("BuyProduct");

                    b.Navigation("Sellers");

                    b.Navigation("ShopingCards");
                });

            modelBuilder.Entity("RTS.Store.Data.Models.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("RTS.Store.Data.Models.Payment", b =>
                {
                    b.Navigation("ShopingCards");
                });

            modelBuilder.Entity("RTS.Store.Data.Models.Seller", b =>
                {
                    b.Navigation("SellerProduct");
                });

            modelBuilder.Entity("RTS.Store.Data.Models.ShopingCard", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
