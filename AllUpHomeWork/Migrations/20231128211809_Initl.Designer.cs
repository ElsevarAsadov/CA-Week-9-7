﻿// <auto-generated />
using AllUpHomeWork.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AllUpHomeWork.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20231128211809_Initl")]
    partial class Initl
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.25")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("AllUpHomeWork.Areas.Admin.Models.ColorModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("colors");
                });

            modelBuilder.Entity("AllUpHomeWork.Areas.Admin.Models.ProductModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<float>("SaleFraction")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.ToTable("products");
                });

            modelBuilder.Entity("AllUpHomeWork.Areas.Admin.Models.SizeModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Size")
                        .IsRequired()
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)");

                    b.HasKey("Id");

                    b.ToTable("sizes");
                });

            modelBuilder.Entity("ColorModelProductModel", b =>
                {
                    b.Property<int>("ColorsId")
                        .HasColumnType("int");

                    b.Property<int>("ProductsId")
                        .HasColumnType("int");

                    b.HasKey("ColorsId", "ProductsId");

                    b.HasIndex("ProductsId");

                    b.ToTable("ColorModelProductModel");
                });

            modelBuilder.Entity("ProductModelSizeModel", b =>
                {
                    b.Property<int>("ProductsId")
                        .HasColumnType("int");

                    b.Property<int>("SizesId")
                        .HasColumnType("int");

                    b.HasKey("ProductsId", "SizesId");

                    b.HasIndex("SizesId");

                    b.ToTable("ProductModelSizeModel");
                });

            modelBuilder.Entity("ColorModelProductModel", b =>
                {
                    b.HasOne("AllUpHomeWork.Areas.Admin.Models.ColorModel", null)
                        .WithMany()
                        .HasForeignKey("ColorsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AllUpHomeWork.Areas.Admin.Models.ProductModel", null)
                        .WithMany()
                        .HasForeignKey("ProductsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ProductModelSizeModel", b =>
                {
                    b.HasOne("AllUpHomeWork.Areas.Admin.Models.ProductModel", null)
                        .WithMany()
                        .HasForeignKey("ProductsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AllUpHomeWork.Areas.Admin.Models.SizeModel", null)
                        .WithMany()
                        .HasForeignKey("SizesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
