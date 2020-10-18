﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using SolarCoffee.data;

namespace SolarCoffee.data.Migrations
{
    [DbContext(typeof(SolarDbContext))]
    [Migration("20201018052453_productInventory")]
    partial class productInventory
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("character varying(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("character varying(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("integer");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasColumnType("character varying(256)")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("character varying(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("character varying(256)")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("boolean");

                    b.Property<string>("UserName")
                        .HasColumnType("character varying(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("text");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .HasColumnType("text");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("SolarCoffee.data.models.Customer", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("createdOn")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("firstName")
                        .HasColumnType("text");

                    b.Property<string>("lastName")
                        .HasColumnType("text");

                    b.Property<int?>("primaryAddressid")
                        .HasColumnType("integer");

                    b.Property<DateTime>("updatedOn")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("id");

                    b.HasIndex("primaryAddressid");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("SolarCoffee.data.models.CustomerAddress", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("addressLine1")
                        .HasColumnType("character varying(100)")
                        .HasMaxLength(100);

                    b.Property<string>("addressLine2")
                        .HasColumnType("character varying(100)")
                        .HasMaxLength(100);

                    b.Property<string>("city")
                        .HasColumnType("character varying(100)")
                        .HasMaxLength(100);

                    b.Property<string>("country")
                        .HasColumnType("character varying(32)")
                        .HasMaxLength(32);

                    b.Property<DateTime>("createdOn")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("postalCode")
                        .HasColumnType("character varying(10)")
                        .HasMaxLength(10);

                    b.Property<string>("state")
                        .HasColumnType("character varying(2)")
                        .HasMaxLength(2);

                    b.Property<DateTime>("updatedOn")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("id");

                    b.ToTable("CustomerAddresses");
                });

            modelBuilder.Entity("SolarCoffee.data.models.Product", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("createdOn")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("description")
                        .HasColumnType("character varying(128)")
                        .HasMaxLength(128);

                    b.Property<bool>("isArchived")
                        .HasColumnType("boolean");

                    b.Property<bool>("isTaxable")
                        .HasColumnType("boolean");

                    b.Property<string>("name")
                        .HasColumnType("character varying(64)")
                        .HasMaxLength(64);

                    b.Property<decimal>("price")
                        .HasColumnType("numeric");

                    b.Property<DateTime>("updatedOn")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("SolarCoffee.data.models.ProductInventory", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int?>("Productid")
                        .HasColumnType("integer");

                    b.Property<DateTime>("createdOn")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("idealQuantity")
                        .HasColumnType("integer");

                    b.Property<int>("quantityOnHand")
                        .HasColumnType("integer");

                    b.Property<DateTime>("updatedOn")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("id");

                    b.HasIndex("Productid");

                    b.ToTable("ProductInventories");
                });

            modelBuilder.Entity("SolarCoffee.data.models.ProductInventorySnapshot", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int?>("Productid")
                        .HasColumnType("integer");

                    b.Property<DateTime>("SnapshotTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("quantityOnHand")
                        .HasColumnType("integer");

                    b.HasKey("id");

                    b.HasIndex("Productid");

                    b.ToTable("ProductInventorySnapshots");
                });

            modelBuilder.Entity("SolarCoffee.data.models.SalesOrder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int?>("Customerid")
                        .HasColumnType("integer");

                    b.Property<DateTime>("createdOn")
                        .HasColumnType("timestamp without time zone");

                    b.Property<bool>("isPaid")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("updatedOn")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.HasIndex("Customerid");

                    b.ToTable("SalesOrders");
                });

            modelBuilder.Entity("SolarCoffee.data.models.SalesOrderItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int?>("Productid")
                        .HasColumnType("integer");

                    b.Property<int?>("SalesOrderId")
                        .HasColumnType("integer");

                    b.Property<int>("quantity")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("Productid");

                    b.HasIndex("SalesOrderId");

                    b.ToTable("SalesOrderItems");
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
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
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

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SolarCoffee.data.models.Customer", b =>
                {
                    b.HasOne("SolarCoffee.data.models.CustomerAddress", "primaryAddress")
                        .WithMany()
                        .HasForeignKey("primaryAddressid");
                });

            modelBuilder.Entity("SolarCoffee.data.models.ProductInventory", b =>
                {
                    b.HasOne("SolarCoffee.data.models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("Productid");
                });

            modelBuilder.Entity("SolarCoffee.data.models.ProductInventorySnapshot", b =>
                {
                    b.HasOne("SolarCoffee.data.models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("Productid");
                });

            modelBuilder.Entity("SolarCoffee.data.models.SalesOrder", b =>
                {
                    b.HasOne("SolarCoffee.data.models.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("Customerid");
                });

            modelBuilder.Entity("SolarCoffee.data.models.SalesOrderItem", b =>
                {
                    b.HasOne("SolarCoffee.data.models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("Productid");

                    b.HasOne("SolarCoffee.data.models.SalesOrder", null)
                        .WithMany("SalesOrderItems")
                        .HasForeignKey("SalesOrderId");
                });
#pragma warning restore 612, 618
        }
    }
}
