﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebBanGiay.Repositoty;

#nullable disable

namespace WebBanGiay.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20241122070101_hung1232212344")]
    partial class hung1232212344
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.21")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Comment", b =>
                {
                    b.Property<int>("ID_COMMENT")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID_COMMENT"), 1L, 1);

                    b.Property<int>("ID_NGUOI_DUNG")
                        .HasColumnType("int");

                    b.Property<int>("ID_SAN_PHAM")
                        .HasColumnType("int");

                    b.Property<DateTime>("NgayTao")
                        .HasColumnType("datetime2");

                    b.Property<string>("NoiDungComment")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int>("SaoDanhGia")
                        .HasColumnType("int");

                    b.HasKey("ID_COMMENT");

                    b.HasIndex("ID_NGUOI_DUNG");

                    b.HasIndex("ID_SAN_PHAM");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("WebBanGiay.Models.ChiTietDonHangModel", b =>
                {
                    b.Property<int>("ID_CHI_TIET_DON_HANG")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID_CHI_TIET_DON_HANG"), 1L, 1);

                    b.Property<decimal>("GIA_BAN")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("ID_DON_HANG")
                        .HasColumnType("int");

                    b.Property<int>("ID_SAN_PHAM")
                        .HasColumnType("int");

                    b.Property<string>("MauSanPham")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SO_LUONG")
                        .HasColumnType("int");

                    b.Property<decimal>("THANH_TIEN")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ID_CHI_TIET_DON_HANG");

                    b.HasIndex("ID_DON_HANG");

                    b.HasIndex("ID_SAN_PHAM");

                    b.ToTable("CHI_TIET_DON_HANGs");
                });

            modelBuilder.Entity("WebBanGiay.Models.DonHangModel", b =>
                {
                    b.Property<int>("ID_DON_HANG")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID_DON_HANG"), 1L, 1);

                    b.Property<string>("DIACHI")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HinhThucThanhToan")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ID_NGUOI_DUNG")
                        .HasColumnType("int");

                    b.Property<int?>("ID_NHAN_VIEN")
                        .HasColumnType("int");

                    b.Property<string>("LY_DO_HUY")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("NGAY_DAT")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("NGAY_GIAO")
                        .HasColumnType("datetime2");

                    b.Property<string>("TEN_NGUOI_NHAN")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<int>("TRANG_THAI_DH")
                        .HasColumnType("int");

                    b.Property<string>("TRANG_THAI_THANH_TOAN")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID_DON_HANG");

                    b.HasIndex("ID_NGUOI_DUNG");

                    b.HasIndex("ID_NHAN_VIEN");

                    b.ToTable("DON_HANGs");
                });

            modelBuilder.Entity("WebBanGiay.Models.GioHangModel", b =>
                {
                    b.Property<int>("ID_GIO_HANG")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID_GIO_HANG"), 1L, 1);

                    b.Property<decimal>("GIA_BAN")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("ID_NGUOI_DUNG")
                        .HasColumnType("int");

                    b.Property<int>("ID_SAN_PHAM")
                        .HasColumnType("int");

                    b.Property<string>("MAU_SP")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SO_LUONG_GH")
                        .HasColumnType("int");

                    b.Property<decimal>("THANH_TIEN")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("TRANG_THAI")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID_GIO_HANG");

                    b.HasIndex("ID_NGUOI_DUNG");

                    b.HasIndex("ID_SAN_PHAM");

                    b.ToTable("GIO_HANGs");
                });

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
                        .HasColumnType("int");

                    b.HasKey("ID_KICH_THUOC");

                    b.ToTable("KICH_THUOCs");

                    b.HasData(
                        new
                        {
                            ID_KICH_THUOC = 1,
                            TEN_KICH_THUOC = 40
                        },
                        new
                        {
                            ID_KICH_THUOC = 2,
                            TEN_KICH_THUOC = 41
                        },
                        new
                        {
                            ID_KICH_THUOC = 3,
                            TEN_KICH_THUOC = 42
                        },
                        new
                        {
                            ID_KICH_THUOC = 4,
                            TEN_KICH_THUOC = 43
                        },
                        new
                        {
                            ID_KICH_THUOC = 5,
                            TEN_KICH_THUOC = 44
                        });
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

                    b.HasData(
                        new
                        {
                            ID_LOAI = 1,
                            TEN_LOAI = "Giày thể thao"
                        },
                        new
                        {
                            ID_LOAI = 2,
                            TEN_LOAI = "Giày chạy bộ"
                        },
                        new
                        {
                            ID_LOAI = 3,
                            TEN_LOAI = "Giày bóng rổ"
                        },
                        new
                        {
                            ID_LOAI = 4,
                            TEN_LOAI = "Giày lifestyle"
                        });
                });

            modelBuilder.Entity("WebBanGiay.Models.MauSanPhamModel", b =>
                {
                    b.Property<int>("ID_MAU")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID_MAU"), 1L, 1);

                    b.Property<string>("TEN_MAU")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID_MAU");

                    b.ToTable("MauSanPhamModel");

                    b.HasData(
                        new
                        {
                            ID_MAU = 1,
                            TEN_MAU = "Đỏ"
                        },
                        new
                        {
                            ID_MAU = 2,
                            TEN_MAU = "Xanh dương"
                        },
                        new
                        {
                            ID_MAU = 3,
                            TEN_MAU = "Đen"
                        },
                        new
                        {
                            ID_MAU = 4,
                            TEN_MAU = "Trắng"
                        },
                        new
                        {
                            ID_MAU = 5,
                            TEN_MAU = "Xám"
                        });
                });

            modelBuilder.Entity("WebBanGiay.Models.NguoiDungModel", b =>
                {
                    b.Property<int>("ID_NGUOI_DUNG")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID_NGUOI_DUNG"), 1L, 1);

                    b.Property<string>("AccessToken")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DIA_CHI")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("EMAIL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GTTT")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GoogleId")
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
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<DateTime>("NGAY_TAO")
                        .HasColumnType("datetime2");

                    b.Property<string>("SDT")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("TAI_KHOAN")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<int>("TRANG_THAI")
                        .HasColumnType("int");

                    b.Property<int>("VAI_TRO")
                        .HasColumnType("int");

                    b.HasKey("ID_NGUOI_DUNG");

                    b.ToTable("NGUOI_DUNGs");

                    b.HasData(
                        new
                        {
                            ID_NGUOI_DUNG = 1,
                            DIA_CHI = "400 Hà Huy Tập, Tân An, TP Buôn Ma Thuột",
                            EMAIL = "user1@gmail.com",
                            GTTT = "CMND001",
                            HINH_ANH = "avt1.jpg",
                            HO_TEN = "Trần Văn Lực",
                            MAT_KHAU = "password1",
                            NGAY_TAO = new DateTime(2024, 11, 22, 14, 1, 1, 424, DateTimeKind.Local).AddTicks(2908),
                            SDT = "0123456780",
                            TAI_KHOAN = "user1",
                            TRANG_THAI = 0,
                            VAI_TRO = 0
                        },
                        new
                        {
                            ID_NGUOI_DUNG = 2,
                            DIA_CHI = "400 Hà Huy Tập, Tân An, TP Buôn Ma Thuột",
                            EMAIL = "user2@gmail.com",
                            GTTT = "CMND002",
                            HINH_ANH = "avt1.jpg",
                            HO_TEN = "Trần Thị Yến ngọc",
                            MAT_KHAU = "password2",
                            NGAY_TAO = new DateTime(2024, 11, 22, 14, 1, 1, 424, DateTimeKind.Local).AddTicks(2911),
                            SDT = "0123456781",
                            TAI_KHOAN = "user2",
                            TRANG_THAI = 0,
                            VAI_TRO = 0
                        },
                        new
                        {
                            ID_NGUOI_DUNG = 3,
                            DIA_CHI = "400 Hà Huy Tập, Tân An, TP Buôn Ma Thuột",
                            EMAIL = "user3@gmail.com",
                            GTTT = "CMND003",
                            HINH_ANH = "avt1.jpg",
                            HO_TEN = "Nguyễn Ngọc Thạch",
                            MAT_KHAU = "password3",
                            NGAY_TAO = new DateTime(2024, 11, 22, 14, 1, 1, 424, DateTimeKind.Local).AddTicks(2912),
                            SDT = "0123456782",
                            TAI_KHOAN = "user3",
                            TRANG_THAI = 0,
                            VAI_TRO = 0
                        },
                        new
                        {
                            ID_NGUOI_DUNG = 4,
                            DIA_CHI = "400 Hà Huy Tập, Tân An, TP Buôn Ma Thuột",
                            EMAIL = "user4@gmail.com",
                            GTTT = "CMND004",
                            HINH_ANH = "avt1.jpg",
                            HO_TEN = "Nguyễn Tiến Thành",
                            MAT_KHAU = "password4",
                            NGAY_TAO = new DateTime(2024, 11, 22, 14, 1, 1, 424, DateTimeKind.Local).AddTicks(2914),
                            SDT = "0123456783",
                            TAI_KHOAN = "user4",
                            TRANG_THAI = 0,
                            VAI_TRO = 0
                        },
                        new
                        {
                            ID_NGUOI_DUNG = 5,
                            DIA_CHI = "400 Hà Huy Tập, Tân An, TP Buôn Ma Thuột",
                            EMAIL = "user5@gmail.com",
                            GTTT = "CMND005",
                            HINH_ANH = "avt1.jpg",
                            HO_TEN = "Nguyễn Thị Thu",
                            MAT_KHAU = "password5",
                            NGAY_TAO = new DateTime(2024, 11, 22, 14, 1, 1, 424, DateTimeKind.Local).AddTicks(2915),
                            SDT = "0123456784",
                            TAI_KHOAN = "user5",
                            TRANG_THAI = 0,
                            VAI_TRO = 0
                        },
                        new
                        {
                            ID_NGUOI_DUNG = 6,
                            DIA_CHI = "400 Hà Huy Tập, Tân An, TP Buôn Ma Thuột",
                            EMAIL = "user6@gmail.com",
                            GTTT = "CMND006",
                            HINH_ANH = "avt1.jpg",
                            HO_TEN = "Lê Hoàng Trọng Khôi",
                            MAT_KHAU = "password6",
                            NGAY_TAO = new DateTime(2024, 11, 22, 14, 1, 1, 424, DateTimeKind.Local).AddTicks(2917),
                            SDT = "0123456785",
                            TAI_KHOAN = "user6",
                            TRANG_THAI = 0,
                            VAI_TRO = 0
                        },
                        new
                        {
                            ID_NGUOI_DUNG = 7,
                            DIA_CHI = "400 Hà Huy Tập, Tân An, TP Buôn Ma Thuột",
                            EMAIL = "user7@gmail.com",
                            GTTT = "CMND007",
                            HINH_ANH = "avt1.jpg",
                            HO_TEN = "Võ Văn Đạt",
                            MAT_KHAU = "password7",
                            NGAY_TAO = new DateTime(2024, 11, 22, 14, 1, 1, 424, DateTimeKind.Local).AddTicks(2919),
                            SDT = "0123456786",
                            TAI_KHOAN = "user7",
                            TRANG_THAI = 0,
                            VAI_TRO = 0
                        },
                        new
                        {
                            ID_NGUOI_DUNG = 8,
                            DIA_CHI = "400 Hà Huy Tập, Tân An, TP Buôn Ma Thuột",
                            EMAIL = "user8@gmail.com",
                            GTTT = "CMND008",
                            HINH_ANH = "avt1.jpg",
                            HO_TEN = "Trần Thị Bích Nga",
                            MAT_KHAU = "password8",
                            NGAY_TAO = new DateTime(2024, 11, 22, 14, 1, 1, 424, DateTimeKind.Local).AddTicks(2921),
                            SDT = "0123456787",
                            TAI_KHOAN = "user8",
                            TRANG_THAI = 0,
                            VAI_TRO = 0
                        },
                        new
                        {
                            ID_NGUOI_DUNG = 9,
                            DIA_CHI = "400 Hà Huy Tập, Tân An, TP Buôn Ma Thuột",
                            EMAIL = "user9@gmail.com",
                            GTTT = "CMND009",
                            HINH_ANH = "avt1.jpg",
                            HO_TEN = "Nguyễn Trường Nhu",
                            MAT_KHAU = "password9",
                            NGAY_TAO = new DateTime(2024, 11, 22, 14, 1, 1, 424, DateTimeKind.Local).AddTicks(2923),
                            SDT = "0123456788",
                            TAI_KHOAN = "user9",
                            TRANG_THAI = 0,
                            VAI_TRO = 0
                        },
                        new
                        {
                            ID_NGUOI_DUNG = 10,
                            DIA_CHI = "400 Hà Huy Tập, Tân An, TP Buôn Ma Thuột",
                            EMAIL = "user10@gmail.com",
                            GTTT = "CMND010",
                            HINH_ANH = "avt1.jpg",
                            HO_TEN = "Phạm Nguyên Phước",
                            MAT_KHAU = "password10",
                            NGAY_TAO = new DateTime(2024, 11, 22, 14, 1, 1, 424, DateTimeKind.Local).AddTicks(2928),
                            SDT = "0123456789",
                            TAI_KHOAN = "user10",
                            TRANG_THAI = 0,
                            VAI_TRO = 0
                        },
                        new
                        {
                            ID_NGUOI_DUNG = 11,
                            DIA_CHI = "400 Hà Huy Tập, Tân An, TP Buôn Ma Thuột",
                            EMAIL = "admin1@gmail.com",
                            GTTT = "CMND011",
                            HINH_ANH = "Admin_images.jpg",
                            HO_TEN = "Võ Văn Hưng",
                            MAT_KHAU = "admin1",
                            NGAY_TAO = new DateTime(2024, 11, 22, 14, 1, 1, 424, DateTimeKind.Local).AddTicks(2929),
                            SDT = "0987654321",
                            TAI_KHOAN = "admin1",
                            TRANG_THAI = 0,
                            VAI_TRO = 1
                        },
                        new
                        {
                            ID_NGUOI_DUNG = 12,
                            DIA_CHI = "400 Hà Huy Tập, Tân An, TP Buôn Ma Thuột",
                            EMAIL = "admin2@gmail.com",
                            GTTT = "CMND012",
                            HINH_ANH = "Admin_images.jpg",
                            HO_TEN = "Phạm Bá Hưng",
                            MAT_KHAU = "admin2",
                            NGAY_TAO = new DateTime(2024, 11, 22, 14, 1, 1, 424, DateTimeKind.Local).AddTicks(2932),
                            SDT = "0987654322",
                            TAI_KHOAN = "admin2",
                            TRANG_THAI = 0,
                            VAI_TRO = 1
                        },
                        new
                        {
                            ID_NGUOI_DUNG = 13,
                            DIA_CHI = "400 Hà Huy Tập, Tân An, TP Buôn Ma Thuột",
                            EMAIL = "employee1@gmail.com",
                            GTTT = "CMND013",
                            HINH_ANH = "Employee_images.jpg",
                            HO_TEN = "Trần Tiến Quân",
                            MAT_KHAU = "NhanVien1",
                            NGAY_TAO = new DateTime(2024, 11, 22, 14, 1, 1, 424, DateTimeKind.Local).AddTicks(2934),
                            SDT = "0977554321",
                            TAI_KHOAN = "NhanVien1",
                            TRANG_THAI = 0,
                            VAI_TRO = 2
                        },
                        new
                        {
                            ID_NGUOI_DUNG = 14,
                            DIA_CHI = "400 Hà Huy Tập, Tân An, TP Buôn Ma Thuột",
                            EMAIL = "employee2@gmail.com",
                            GTTT = "CMND014",
                            HINH_ANH = "Employee_images.jpg",
                            HO_TEN = "Ngô Kiến Huy",
                            MAT_KHAU = "employeepass2",
                            NGAY_TAO = new DateTime(2024, 11, 22, 14, 1, 1, 424, DateTimeKind.Local).AddTicks(2935),
                            SDT = "0977644322",
                            TAI_KHOAN = "employee2",
                            TRANG_THAI = 0,
                            VAI_TRO = 2
                        },
                        new
                        {
                            ID_NGUOI_DUNG = 15,
                            DIA_CHI = "400 Hà Huy Tập, Tân An, TP Buôn Ma Thuột",
                            EMAIL = "employee3@gmail.com",
                            GTTT = "CMND015",
                            HINH_ANH = "Employee_images.jpg",
                            HO_TEN = "Nguyễn Trọng Tính",
                            MAT_KHAU = "employeepass3",
                            NGAY_TAO = new DateTime(2024, 11, 22, 14, 1, 1, 424, DateTimeKind.Local).AddTicks(2939),
                            SDT = "0977654323",
                            TAI_KHOAN = "employee3",
                            TRANG_THAI = 1,
                            VAI_TRO = 2
                        },
                        new
                        {
                            ID_NGUOI_DUNG = 16,
                            DIA_CHI = "400 Hà Huy Tập, Tân An, TP Buôn Ma Thuột",
                            EMAIL = "employee4@gmail.com",
                            GTTT = "CMND016",
                            HINH_ANH = "Employee_images.jpg",
                            HO_TEN = "Trần Anh Đức",
                            MAT_KHAU = "employeepass4",
                            NGAY_TAO = new DateTime(2024, 11, 22, 14, 1, 1, 424, DateTimeKind.Local).AddTicks(2942),
                            SDT = "0977654324",
                            TAI_KHOAN = "employee4",
                            TRANG_THAI = 0,
                            VAI_TRO = 2
                        },
                        new
                        {
                            ID_NGUOI_DUNG = 17,
                            DIA_CHI = "400 Hà Huy Tập, Tân An, TP Buôn Ma Thuột",
                            EMAIL = "employee5@gmail.com",
                            GTTT = "CMND017",
                            HINH_ANH = "Employee_images.jpg",
                            HO_TEN = "Trần Văn Đức Hồng",
                            MAT_KHAU = "employeepass5",
                            NGAY_TAO = new DateTime(2024, 11, 22, 14, 1, 1, 424, DateTimeKind.Local).AddTicks(2945),
                            SDT = "0977654325",
                            TAI_KHOAN = "employee5",
                            TRANG_THAI = 0,
                            VAI_TRO = 2
                        });
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

                    b.Property<int>("GIA_BAN")
                        .HasColumnType("int");

                    b.Property<int>("GIA_NHAP")
                        .HasColumnType("int");

                    b.Property<int>("ID_KICH_THUOC")
                        .HasColumnType("int");

                    b.Property<int>("ID_LOAI")
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

                    b.HasIndex("ID_LOAI");

                    b.ToTable("SAN_PHAMs");

                    b.HasData(
                        new
                        {
                            ID_SAN_PHAM = 1,
                            CHAT_LIEU = "Vải dệt, Cao su",
                            GIA_BAN = 2500000,
                            GIA_NHAP = 1500000,
                            ID_KICH_THUOC = 3,
                            ID_LOAI = 1,
                            MO_TA = "Giày thể thao Nike Air Zoom Pegasus 40 với công nghệ Zoom Air giúp bạn chạy nhẹ nhàng và thoải mái.",
                            NGAY_TAO = new DateTime(2024, 11, 22, 14, 1, 1, 424, DateTimeKind.Local).AddTicks(3153),
                            SO_LUONG = 50,
                            TEN_SAN_PHAM = "Giày Nike Air Zoom Pegasus 40"
                        },
                        new
                        {
                            ID_SAN_PHAM = 2,
                            CHAT_LIEU = "Vải dệt, Cao su, Phylon",
                            GIA_BAN = 3000000,
                            GIA_NHAP = 1800000,
                            ID_KICH_THUOC = 4,
                            ID_LOAI = 2,
                            MO_TA = "Giày chạy bộ Nike Zoom Fly 4 với đế giày Zoom giúp tạo độ đàn hồi tuyệt vời.",
                            NGAY_TAO = new DateTime(2024, 11, 22, 14, 1, 1, 424, DateTimeKind.Local).AddTicks(3155),
                            SO_LUONG = 30,
                            TEN_SAN_PHAM = "Giày Nike Zoom Fly 4"
                        },
                        new
                        {
                            ID_SAN_PHAM = 3,
                            CHAT_LIEU = "Da, Cao su",
                            GIA_BAN = 4500000,
                            GIA_NHAP = 2500000,
                            ID_KICH_THUOC = 5,
                            ID_LOAI = 3,
                            MO_TA = "Giày bóng rổ Nike Air Jordan 1 Retro với thiết kế cổ điển, chất liệu da cao cấp, tạo cảm giác thoải mái khi chơi thể thao.",
                            NGAY_TAO = new DateTime(2024, 11, 22, 14, 1, 1, 424, DateTimeKind.Local).AddTicks(3156),
                            SO_LUONG = 20,
                            TEN_SAN_PHAM = "Giày Nike Air Jordan 1 Retro"
                        },
                        new
                        {
                            ID_SAN_PHAM = 4,
                            CHAT_LIEU = "Vải dệt, Cao su, Phylon",
                            GIA_BAN = 2900000,
                            GIA_NHAP = 1700000,
                            ID_KICH_THUOC = 2,
                            ID_LOAI = 1,
                            MO_TA = "Giày thể thao Nike Air Max 270 với đế Air Max lớn tạo độ nảy và sự êm ái khi di chuyển.",
                            NGAY_TAO = new DateTime(2024, 11, 22, 14, 1, 1, 424, DateTimeKind.Local).AddTicks(3158),
                            SO_LUONG = 40,
                            TEN_SAN_PHAM = "Giày Nike Air Max 270"
                        },
                        new
                        {
                            ID_SAN_PHAM = 5,
                            CHAT_LIEU = "Da, Cao su",
                            GIA_BAN = 3500000,
                            GIA_NHAP = 2000000,
                            ID_KICH_THUOC = 3,
                            ID_LOAI = 4,
                            MO_TA = "Giày Nike Air Force 1 '07 mang phong cách cổ điển, dễ dàng kết hợp với nhiều trang phục.",
                            NGAY_TAO = new DateTime(2024, 11, 22, 14, 1, 1, 424, DateTimeKind.Local).AddTicks(3159),
                            SO_LUONG = 25,
                            TEN_SAN_PHAM = "Giày Nike Air Force 1 '07"
                        });
                });

            modelBuilder.Entity("Comment", b =>
                {
                    b.HasOne("WebBanGiay.Models.NguoiDungModel", "NguoiDung")
                        .WithMany()
                        .HasForeignKey("ID_NGUOI_DUNG")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebBanGiay.Models.SanPhamModel", "SanPham")
                        .WithMany("Comments")
                        .HasForeignKey("ID_SAN_PHAM")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("NguoiDung");

                    b.Navigation("SanPham");
                });

            modelBuilder.Entity("WebBanGiay.Models.ChiTietDonHangModel", b =>
                {
                    b.HasOne("WebBanGiay.Models.DonHangModel", "DON_HANG")
                        .WithMany("CHI_TIET_DON_HANG")
                        .HasForeignKey("ID_DON_HANG")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebBanGiay.Models.SanPhamModel", "SAN_PHAM")
                        .WithMany()
                        .HasForeignKey("ID_SAN_PHAM")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DON_HANG");

                    b.Navigation("SAN_PHAM");
                });

            modelBuilder.Entity("WebBanGiay.Models.DonHangModel", b =>
                {
                    b.HasOne("WebBanGiay.Models.NguoiDungModel", "NGUOI_DUNG")
                        .WithMany()
                        .HasForeignKey("ID_NGUOI_DUNG")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebBanGiay.Models.NguoiDungModel", "NHAN_VIEN")
                        .WithMany()
                        .HasForeignKey("ID_NHAN_VIEN");

                    b.Navigation("NGUOI_DUNG");

                    b.Navigation("NHAN_VIEN");
                });

            modelBuilder.Entity("WebBanGiay.Models.GioHangModel", b =>
                {
                    b.HasOne("WebBanGiay.Models.NguoiDungModel", "NGUOI_DUNG")
                        .WithMany()
                        .HasForeignKey("ID_NGUOI_DUNG")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebBanGiay.Models.SanPhamModel", "SAN_PHAM")
                        .WithMany()
                        .HasForeignKey("ID_SAN_PHAM")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("NGUOI_DUNG");

                    b.Navigation("SAN_PHAM");
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

            modelBuilder.Entity("WebBanGiay.Models.SanPhamMauModel", b =>
                {
                    b.HasOne("WebBanGiay.Models.MauSanPhamModel", "Mau")
                        .WithMany()
                        .HasForeignKey("ID_MAU")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebBanGiay.Models.SanPhamModel", "SanPham")
                        .WithMany("SanPhamMau")
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
                        .HasForeignKey("ID_LOAI")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TEN_KICH_THUOC");

                    b.Navigation("TEN_LOAI");
                });

            modelBuilder.Entity("WebBanGiay.Models.DonHangModel", b =>
                {
                    b.Navigation("CHI_TIET_DON_HANG");
                });

            modelBuilder.Entity("WebBanGiay.Models.SanPhamModel", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("HINH_ANH");

                    b.Navigation("SanPhamMau");
                });
#pragma warning restore 612, 618
        }
    }
}
