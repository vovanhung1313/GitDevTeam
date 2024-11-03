﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebBanGiay.Repositoty;

#nullable disable

namespace WebBanGiay.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.21")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("WebBanGiay.Models.HinhAnhModel", b =>
                {
                    b.Property<int>("ID_HINH_ANH")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID_HINH_ANH"), 1L, 1);

                    b.Property<int>("ID_SAN_PHAM")
                        .HasColumnType("int");

                    b.Property<string>("TEN_HINH_ANH")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID_HINH_ANH");

                    b.HasIndex("ID_SAN_PHAM");

                    b.ToTable("HINH_ANHs");
                });

            modelBuilder.Entity("WebBanGiay.Models.KichThuocSanPhamModel", b =>
                {
                    b.Property<int>("ID_KICH_THUOC")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID_KICH_THUOC"), 1L, 1);

                    b.Property<int>("TEN_KICH_THUOC")
                        .HasMaxLength(1)
                        .HasColumnType("int");

                    b.HasKey("ID_KICH_THUOC");

                    b.ToTable("KICH_THUOCs");
                });

            modelBuilder.Entity("WebBanGiay.Models.LoaiSanPhamModel", b =>
                {
                    b.Property<int>("ID_LOAI")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID_LOAI"), 1L, 1);

                    b.Property<string>("TEN_LOAI")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID_LOAI");

                    b.ToTable("LOAI_SAN_PHAMs");
                });

            modelBuilder.Entity("WebBanGiay.Models.MauSanPhamModel", b =>
                {
                    b.Property<int>("ID_MAU")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID_MAU"), 1L, 1);

                    b.Property<int?>("SanPhamModelID_SAN_PHAM")
                        .HasColumnType("int");

                    b.Property<string>("TEN_MAU")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID_MAU");

                    b.HasIndex("SanPhamModelID_SAN_PHAM");

                    b.ToTable("MAU_SACs");
                });

            modelBuilder.Entity("WebBanGiay.Models.NguoiDungModel", b =>
                {
                    b.Property<int>("ID_NGUOI_DUNG")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID_NGUOI_DUNG"), 1L, 1);

                    b.Property<string>("DIA_CHI")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("EMAIL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GTTT")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HINH_ANH")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HO_TEN")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("MAT_KHAU")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<DateTime>("NGAY_TAO")
                        .HasColumnType("datetime2");

                    b.Property<string>("SDT")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("TAI_KHOAN")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("TRANG_THAI")
                        .HasColumnType("int");

                    b.Property<int>("VAI_TRO")
                        .HasColumnType("int");

                    b.HasKey("ID_NGUOI_DUNG");

                    b.ToTable("NGUOI_DUNGs");
                });

            modelBuilder.Entity("WebBanGiay.Models.SanPhamMauModel", b =>
                {
                    b.Property<int>("ID_MauSanPham")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID_MauSanPham"), 1L, 1);

                    b.Property<int>("ID_MAU")
                        .HasColumnType("int");

                    b.Property<int>("ID_SAN_PHAM")
                        .HasColumnType("int");

                    b.HasKey("ID_MauSanPham");

                    b.HasIndex("ID_MAU");

                    b.HasIndex("ID_SAN_PHAM");

                    b.ToTable("SAN_PHAM_MAUs");
                });

            modelBuilder.Entity("WebBanGiay.Models.SanPhamModel", b =>
                {
                    b.Property<int>("ID_SAN_PHAM")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID_SAN_PHAM"), 1L, 1);

                    b.Property<string>("CHAT_LIEU")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("GIA_BAN")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("GIA_NHAP")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("ID_KICH_THUOC")
                        .HasColumnType("int");

                    b.Property<int>("ID_LOAI")
                        .HasColumnType("int");

                    b.Property<int?>("ID_LOAI_SAN_PHAM")
                        .HasColumnType("int");

                    b.Property<string>("MO_TA")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("NGAY_TAO")
                        .HasColumnType("datetime2");

                    b.Property<int>("SO_LUONG")
                        .HasColumnType("int");

                    b.Property<string>("TEN_SAN_PHAM")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID_SAN_PHAM");

                    b.HasIndex("ID_KICH_THUOC");

                    b.HasIndex("ID_LOAI_SAN_PHAM");

                    b.ToTable("SAN_PHAMs");
                });

            modelBuilder.Entity("WebBanGiay.Models.HinhAnhModel", b =>
                {
                    b.HasOne("WebBanGiay.Models.SanPhamModel", "SAN_PHAM")
                        .WithMany("HINH_ANH")
                        .HasForeignKey("ID_SAN_PHAM")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SAN_PHAM");
                });

            modelBuilder.Entity("WebBanGiay.Models.MauSanPhamModel", b =>
                {
                    b.HasOne("WebBanGiay.Models.SanPhamModel", null)
                        .WithMany("MauSanPham")
                        .HasForeignKey("SanPhamModelID_SAN_PHAM");
                });

            modelBuilder.Entity("WebBanGiay.Models.SanPhamMauModel", b =>
                {
                    b.HasOne("WebBanGiay.Models.MauSanPhamModel", "Mau")
                        .WithMany()
                        .HasForeignKey("ID_MAU")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebBanGiay.Models.SanPhamModel", "SanPham")
                        .WithMany()
                        .HasForeignKey("ID_SAN_PHAM")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Mau");

                    b.Navigation("SanPham");
                });

            modelBuilder.Entity("WebBanGiay.Models.SanPhamModel", b =>
                {
                    b.HasOne("WebBanGiay.Models.KichThuocSanPhamModel", "TEN_KICH_THUOC")
                        .WithMany()
                        .HasForeignKey("ID_KICH_THUOC")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebBanGiay.Models.LoaiSanPhamModel", "TEN_LOAI")
                        .WithMany()
                        .HasForeignKey("ID_LOAI_SAN_PHAM");

                    b.Navigation("TEN_KICH_THUOC");

                    b.Navigation("TEN_LOAI");
                });

            modelBuilder.Entity("WebBanGiay.Models.SanPhamModel", b =>
                {
                    b.Navigation("HINH_ANH");

                    b.Navigation("MauSanPham");
                });
#pragma warning restore 612, 618
        }
    }
}
