﻿// <auto-generated />
using System;
using LolaFlora.Web.DBContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace LolaFlora.Web.Migrations
{
    [DbContext(typeof(PgsqlDbContext))]
    partial class PgsqlDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("LolaFlora.Data.Entities.Cart", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime?>("CreatedDateTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<long?>("CreatedUser")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("DeletedDateTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<long?>("DeletedUser")
                        .HasColumnType("bigint");

                    b.Property<long>("ProductId")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("UpdatedDateTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<long?>("UpdatedUser")
                        .HasColumnType("bigint");

                    b.Property<long?>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("Cart");
                });

            modelBuilder.Entity("LolaFlora.Data.Entities.Category", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime?>("CreatedDateTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<long?>("CreatedUser")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("DeletedDateTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<long?>("DeletedUser")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<DateTime?>("UpdatedDateTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<long?>("UpdatedUser")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("LolaFlora.Data.Entities.Product", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<long?>("CartId")
                        .HasColumnType("bigint");

                    b.Property<long>("CategoryId")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("CreatedDateTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<long?>("CreatedUser")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("DeletedDateTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<long?>("DeletedUser")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Price")
                        .HasColumnType("text");

                    b.Property<long>("Quantity")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("UpdatedDateTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<long?>("UpdatedUser")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("CartId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("LolaFlora.Data.Entities.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime?>("CreatedDateTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<long?>("CreatedUser")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("DeletedDateTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<long?>("DeletedUser")
                        .HasColumnType("bigint");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .HasColumnType("text");

                    b.Property<DateTime?>("UpdatedDateTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<long?>("UpdatedUser")
                        .HasColumnType("bigint");

                    b.Property<string>("Username")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("LolaFlora.Data.Entities.Product", b =>
                {
                    b.HasOne("LolaFlora.Data.Entities.Cart", null)
                        .WithMany("Products")
                        .HasForeignKey("CartId");
                });
#pragma warning restore 612, 618
        }
    }
}
