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

                    b.ToTable("MauSanPhamModel");
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
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

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
                            DIA_CHI = "Địa chỉ 1",
                            EMAIL = "khachhang1@example.com",
                            GTTT = "CMND",
                            HINH_ANH = "avt1.jpg",
                            HO_TEN = "Hồ Huy Linh",
                            MAT_KHAU = "matkhau1",
                            NGAY_TAO = new DateTime(2024, 11, 6, 0, 44, 21, 901, DateTimeKind.Local).AddTicks(3931),
                            SDT = "0912345671",
                            TAI_KHOAN = "khachhang1",
                            TRANG_THAI = 0,
                            VAI_TRO = 0
                        },
                        new
                        {
                            ID_NGUOI_DUNG = 2,
                            DIA_CHI = "Địa chỉ 2",
                            EMAIL = "khachhang2@example.com",
                            GTTT = "CMND",
                            HINH_ANH = "avt1.jpg",
                            HO_TEN = "Hồ Huy Long",
                            MAT_KHAU = "matkhau2",
                            NGAY_TAO = new DateTime(2024, 11, 6, 0, 44, 21, 901, DateTimeKind.Local).AddTicks(3934),
                            SDT = "0912345672",
                            TAI_KHOAN = "khachhang2",
                            TRANG_THAI = 0,
                            VAI_TRO = 0
                        },
                        new
                        {
                            ID_NGUOI_DUNG = 3,
                            DIA_CHI = "Địa chỉ 3",
                            EMAIL = "khachhang3@example.com",
                            GTTT = "CMND",
                            HINH_ANH = "avt1.jpg",
                            HO_TEN = "Hồ Huy Quân",
                            MAT_KHAU = "matkhau3",
                            NGAY_TAO = new DateTime(2024, 11, 6, 0, 44, 21, 901, DateTimeKind.Local).AddTicks(3936),
                            SDT = "0912345673",
                            TAI_KHOAN = "khachhang3",
                            TRANG_THAI = 0,
                            VAI_TRO = 0
                        },
                        new
                        {
                            ID_NGUOI_DUNG = 4,
                            DIA_CHI = "Địa chỉ 4",
                            EMAIL = "khachhang4@example.com",
                            GTTT = "CMND",
                            HINH_ANH = "avt1.jpg",
                            HO_TEN = "Võ Văn Hưng",
                            MAT_KHAU = "matkhau4",
                            NGAY_TAO = new DateTime(2024, 11, 6, 0, 44, 21, 901, DateTimeKind.Local).AddTicks(3937),
                            SDT = "0912345674",
                            TAI_KHOAN = "khachhang4",
                            TRANG_THAI = 0,
                            VAI_TRO = 0
                        },
                        new
                        {
                            ID_NGUOI_DUNG = 5,
                            DIA_CHI = "Địa chỉ 5",
                            EMAIL = "khachhang5@example.com",
                            GTTT = "CMND",
                            HINH_ANH = "avt1.jpg",
                            HO_TEN = "Phạm Bá Hậu",
                            MAT_KHAU = "matkhau5",
                            NGAY_TAO = new DateTime(2024, 11, 6, 0, 44, 21, 901, DateTimeKind.Local).AddTicks(3938),
                            SDT = "0912345675",
                            TAI_KHOAN = "khachhang5",
                            TRANG_THAI = 0,
                            VAI_TRO = 0
                        },
                        new
                        {
                            ID_NGUOI_DUNG = 6,
                            DIA_CHI = "Địa chỉ 6",
                            EMAIL = "khachhang6@example.com",
                            GTTT = "CMND",
                            HINH_ANH = "avt1.jpg",
                            HO_TEN = "Nguyễn Quang Quý",
                            MAT_KHAU = "matkhau6",
                            NGAY_TAO = new DateTime(2024, 11, 6, 0, 44, 21, 901, DateTimeKind.Local).AddTicks(3940),
                            SDT = "0912345676",
                            TAI_KHOAN = "khachhang6",
                            TRANG_THAI = 0,
                            VAI_TRO = 0
                        },
                        new
                        {
                            ID_NGUOI_DUNG = 7,
                            DIA_CHI = "Địa chỉ 7",
                            EMAIL = "khachhang7@example.com",
                            GTTT = "CMND",
                            HINH_ANH = "avt1.jpg",
                            HO_TEN = "Nguyễn Gia Nghi",
                            MAT_KHAU = "matkhau7",
                            NGAY_TAO = new DateTime(2024, 11, 6, 0, 44, 21, 901, DateTimeKind.Local).AddTicks(3943),
                            SDT = "0912345677",
                            TAI_KHOAN = "khachhang7",
                            TRANG_THAI = 0,
                            VAI_TRO = 0
                        },
                        new
                        {
                            ID_NGUOI_DUNG = 8,
                            DIA_CHI = "Địa chỉ 8",
                            EMAIL = "khachhang8@example.com",
                            GTTT = "CMND",
                            HINH_ANH = "avt1.jpg",
                            HO_TEN = "Nguyễn Phú Hưng",
                            MAT_KHAU = "matkhau8",
                            NGAY_TAO = new DateTime(2024, 11, 6, 0, 44, 21, 901, DateTimeKind.Local).AddTicks(3946),
                            SDT = "0912345678",
                            TAI_KHOAN = "khachhang8",
                            TRANG_THAI = 0,
                            VAI_TRO = 0
                        },
                        new
                        {
                            ID_NGUOI_DUNG = 9,
                            DIA_CHI = "Địa chỉ 9",
                            EMAIL = "khachhang9@example.com",
                            GTTT = "CMND",
                            HINH_ANH = "avt1.jpg",
                            HO_TEN = "Phạm Phượng",
                            MAT_KHAU = "matkhau9",
                            NGAY_TAO = new DateTime(2024, 11, 6, 0, 44, 21, 901, DateTimeKind.Local).AddTicks(3947),
                            SDT = "0912345679",
                            TAI_KHOAN = "khachhang9",
                            TRANG_THAI = 0,
                            VAI_TRO = 0
                        },
                        new
                        {
                            ID_NGUOI_DUNG = 10,
                            DIA_CHI = "Địa chỉ 10",
                            EMAIL = "khachhang10@example.com",
                            GTTT = "CMND",
                            HINH_ANH = "avt1.jpg",
                            HO_TEN = "Tạ Minh Tâm",
                            MAT_KHAU = "matkhau10",
                            NGAY_TAO = new DateTime(2024, 11, 6, 0, 44, 21, 901, DateTimeKind.Local).AddTicks(3948),
                            SDT = "0912345680",
                            TAI_KHOAN = "khachhang10",
                            TRANG_THAI = 0,
                            VAI_TRO = 0
                        },
                        new
                        {
                            ID_NGUOI_DUNG = 11,
                            DIA_CHI = "Địa chỉ Admin 1",
                            EMAIL = "admin1@example.com",
                            GTTT = "CMND",
                            HINH_ANH = "avt1.jpg",
                            HO_TEN = "Võ Văn Hưng",
                            MAT_KHAU = "matkhau11",
                            NGAY_TAO = new DateTime(2024, 11, 6, 0, 44, 21, 901, DateTimeKind.Local).AddTicks(4008),
                            SDT = "0912345681",
                            TAI_KHOAN = "admin1",
                            TRANG_THAI = 0,
                            VAI_TRO = 1
                        },
                        new
                        {
                            ID_NGUOI_DUNG = 12,
                            DIA_CHI = "Địa chỉ Admin 2",
                            EMAIL = "admin2@example.com",
                            GTTT = "CMND",
                            HINH_ANH = "avt1.jpg",
                            HO_TEN = "Bùi Phương Linh",
                            MAT_KHAU = "matkhau12",
                            NGAY_TAO = new DateTime(2024, 11, 6, 0, 44, 21, 901, DateTimeKind.Local).AddTicks(4010),
                            SDT = "0912345682",
                            TAI_KHOAN = "admin2",
                            TRANG_THAI = 0,
                            VAI_TRO = 1
                        },
                        new
                        {
                            ID_NGUOI_DUNG = 13,
                            DIA_CHI = "Địa chỉ Admin 3",
                            EMAIL = "admin3@example.com",
                            GTTT = "CMND",
                            HINH_ANH = "avt1.jpg",
                            HO_TEN = "Nguyễn Hoàng Trọng Khôi",
                            MAT_KHAU = "matkhau13",
                            NGAY_TAO = new DateTime(2024, 11, 6, 0, 44, 21, 901, DateTimeKind.Local).AddTicks(4011),
                            SDT = "0912345683",
                            TAI_KHOAN = "admin3",
                            TRANG_THAI = 0,
                            VAI_TRO = 1
                        },
                        new
                        {
                            ID_NGUOI_DUNG = 14,
                            DIA_CHI = "Địa chỉ Nhân Viên 1",
                            EMAIL = "nhanvien1@example.com",
                            GTTT = "CMND",
                            HINH_ANH = "avt1.jpg",
                            HO_TEN = "Nguyễn Hoàng Anh",
                            MAT_KHAU = "matkhau14",
                            NGAY_TAO = new DateTime(2024, 11, 6, 0, 44, 21, 901, DateTimeKind.Local).AddTicks(4013),
                            SDT = "0912345684",
                            TAI_KHOAN = "nhanvien1",
                            TRANG_THAI = 0,
                            VAI_TRO = 2
                        },
                        new
                        {
                            ID_NGUOI_DUNG = 15,
                            DIA_CHI = "Địa chỉ Nhân Viên 2",
                            EMAIL = "nhanvien2@example.com",
                            GTTT = "CMND",
                            HINH_ANH = "avt1.jpg",
                            HO_TEN = "Phạm Ngũ Lão",
                            MAT_KHAU = "matkhau15",
                            NGAY_TAO = new DateTime(2024, 11, 6, 0, 44, 21, 901, DateTimeKind.Local).AddTicks(4014),
                            SDT = "0912345685",
                            TAI_KHOAN = "nhanvien2",
                            TRANG_THAI = 0,
                            VAI_TRO = 2
                        },
                        new
                        {
                            ID_NGUOI_DUNG = 16,
                            DIA_CHI = "Địa chỉ Nhân Viên 3",
                            EMAIL = "nhanvien3@example.com",
                            GTTT = "CMND",
                            HINH_ANH = "avt1.jpg",
                            HO_TEN = "Trần Quốc Toản",
                            MAT_KHAU = "matkhau16",
                            NGAY_TAO = new DateTime(2024, 11, 6, 0, 44, 21, 901, DateTimeKind.Local).AddTicks(4017),
                            SDT = "0912345686",
                            TAI_KHOAN = "nhanvien3",
                            TRANG_THAI = 0,
                            VAI_TRO = 2
                        },
                        new
                        {
                            ID_NGUOI_DUNG = 17,
                            DIA_CHI = "Địa chỉ Nhân Viên 4",
                            EMAIL = "nhanvien4@example.com",
                            GTTT = "CMND",
                            HINH_ANH = "avt1.jpg",
                            HO_TEN = "Phạm Bá Thiên",
                            MAT_KHAU = "matkhau17",
                            NGAY_TAO = new DateTime(2024, 11, 6, 0, 44, 21, 901, DateTimeKind.Local).AddTicks(4019),
                            SDT = "0912345687",
                            TAI_KHOAN = "nhanvien4",
                            TRANG_THAI = 0,
                            VAI_TRO = 2
                        },
                        new
                        {
                            ID_NGUOI_DUNG = 18,
                            DIA_CHI = "Địa chỉ Nhân Viên 5",
                            EMAIL = "nhanvien5@example.com",
                            GTTT = "CMND",
                            HINH_ANH = "avt1.jpg",
                            HO_TEN = "Trần Tiến Luật",
                            MAT_KHAU = "matkhau18",
                            NGAY_TAO = new DateTime(2024, 11, 6, 0, 44, 21, 901, DateTimeKind.Local).AddTicks(4020),
                            SDT = "0912345688",
                            TAI_KHOAN = "nhanvien5",
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
