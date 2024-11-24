using Microsoft.EntityFrameworkCore;
using WebBanGiay.Models;

namespace WebBanGiay.Repositoty
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<NguoiDungModel> NGUOI_DUNGs { get; set; }

        public DbSet<SanPhamModel> SAN_PHAMs { get; set; }
        public DbSet<HinhAnhModel> HINH_ANHs { get; set; }
        public DbSet<MauSanPhamModel> MAU_SACs { get; set; }
        public DbSet<KichThuocSanPhamModel> KICH_THUOCs { get; set; }
        public DbSet<LoaiSanPhamModel> LOAI_SAN_PHAMs { get; set; }
        public DbSet<SanPhamMauModel> SAN_PHAM_MAUs { get; set; }
        public DbSet<MauSanPhamModel> MauSanPhamModels { get; set; }

        public DbSet<DonHangModel> DON_HANGs { get; set; }
        public DbSet<ChiTietDonHangModel> CHI_TIET_DON_HANGs { get; set; }

        public DbSet<GioHangModel> GIO_HANGs { get; set; }
        public DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Thêm dữ liệu mẫu cho NguoiDungModel
            modelBuilder.Entity<NguoiDungModel>().HasData(
                // 10 người dùng (mã vai trò = 0)
                new NguoiDungModel { ID_NGUOI_DUNG = 1, HO_TEN = "Trần Văn Lực", SDT = "0123456780", GTTT = "CMND001", EMAIL = "user1@gmail.com", TAI_KHOAN = "user1", MAT_KHAU = "password1", VAI_TRO = 0, HINH_ANH = "avt1.jpg", NGAY_TAO = DateTime.Now, TRANG_THAI = 0, DIA_CHI = "400 Hà Huy Tập, Tân An, TP Buôn Ma Thuột" },
                new NguoiDungModel { ID_NGUOI_DUNG = 2, HO_TEN = "Trần Thị Yến ngọc", SDT = "0123456781", GTTT = "CMND002", EMAIL = "user2@gmail.com", TAI_KHOAN = "user2", MAT_KHAU = "password2", VAI_TRO = 0, HINH_ANH = "avt1.jpg", NGAY_TAO = DateTime.Now, TRANG_THAI = 0, DIA_CHI = "400 Hà Huy Tập, Tân An, TP Buôn Ma Thuột" },
                new NguoiDungModel { ID_NGUOI_DUNG = 3, HO_TEN = "Nguyễn Ngọc Thạch", SDT = "0123456782", GTTT = "CMND003", EMAIL = "user3@gmail.com", TAI_KHOAN = "user3", MAT_KHAU = "password3", VAI_TRO = 0, HINH_ANH = "avt1.jpg", NGAY_TAO = DateTime.Now, TRANG_THAI = 0, DIA_CHI = "400 Hà Huy Tập, Tân An, TP Buôn Ma Thuột" },
                new NguoiDungModel { ID_NGUOI_DUNG = 4, HO_TEN = "Nguyễn Tiến Thành", SDT = "0123456783", GTTT = "CMND004", EMAIL = "user4@gmail.com", TAI_KHOAN = "user4", MAT_KHAU = "password4", VAI_TRO = 0, HINH_ANH = "avt1.jpg", NGAY_TAO = DateTime.Now, TRANG_THAI = 0, DIA_CHI = "400 Hà Huy Tập, Tân An, TP Buôn Ma Thuột" },
                new NguoiDungModel { ID_NGUOI_DUNG = 5, HO_TEN = "Nguyễn Thị Thu", SDT = "0123456784", GTTT = "CMND005", EMAIL = "user5@gmail.com", TAI_KHOAN = "user5", MAT_KHAU = "password5", VAI_TRO = 0, HINH_ANH = "avt1.jpg", NGAY_TAO = DateTime.Now, TRANG_THAI = 0, DIA_CHI = "400 Hà Huy Tập, Tân An, TP Buôn Ma Thuột" },
                new NguoiDungModel { ID_NGUOI_DUNG = 6, HO_TEN = "Lê Hoàng Trọng Khôi", SDT = "0123456785", GTTT = "CMND006", EMAIL = "user6@gmail.com", TAI_KHOAN = "user6", MAT_KHAU = "password6", VAI_TRO = 0, HINH_ANH = "avt1.jpg", NGAY_TAO = DateTime.Now, TRANG_THAI = 0, DIA_CHI = "400 Hà Huy Tập, Tân An, TP Buôn Ma Thuột" },
                new NguoiDungModel { ID_NGUOI_DUNG = 7, HO_TEN = "Võ Văn Đạt", SDT = "0123456786", GTTT = "CMND007", EMAIL = "user7@gmail.com", TAI_KHOAN = "user7", MAT_KHAU = "password7", VAI_TRO = 0, HINH_ANH = "avt1.jpg", NGAY_TAO = DateTime.Now, TRANG_THAI = 0, DIA_CHI = "400 Hà Huy Tập, Tân An, TP Buôn Ma Thuột" },
                new NguoiDungModel { ID_NGUOI_DUNG = 8, HO_TEN = "Trần Thị Bích Nga", SDT = "0123456787", GTTT = "CMND008", EMAIL = "user8@gmail.com", TAI_KHOAN = "user8", MAT_KHAU = "password8", VAI_TRO = 0, HINH_ANH = "avt1.jpg", NGAY_TAO = DateTime.Now, TRANG_THAI = 0, DIA_CHI = "400 Hà Huy Tập, Tân An, TP Buôn Ma Thuột" },
                new NguoiDungModel { ID_NGUOI_DUNG = 9, HO_TEN = "Nguyễn Trường Nhu", SDT = "0123456788", GTTT = "CMND009", EMAIL = "user9@gmail.com", TAI_KHOAN = "user9", MAT_KHAU = "password9", VAI_TRO = 0, HINH_ANH = "avt1.jpg", NGAY_TAO = DateTime.Now, TRANG_THAI = 0, DIA_CHI = "400 Hà Huy Tập, Tân An, TP Buôn Ma Thuột" },
                new NguoiDungModel { ID_NGUOI_DUNG = 10, HO_TEN = "Phạm Nguyên Phước", SDT = "0123456789", GTTT = "CMND010", EMAIL = "user10@gmail.com", TAI_KHOAN = "user10", MAT_KHAU = "password10", VAI_TRO = 0, HINH_ANH = "avt1.jpg", NGAY_TAO = DateTime.Now, TRANG_THAI = 0, DIA_CHI = "400 Hà Huy Tập, Tân An, TP Buôn Ma Thuột" },

                // 2 admin (mã vai trò = 1)
                new NguoiDungModel { ID_NGUOI_DUNG = 11, HO_TEN = "Võ Văn Hưng", SDT = "0987654321", GTTT = "CMND011", EMAIL = "admin1@gmail.com", TAI_KHOAN = "admin1", MAT_KHAU = "admin1", VAI_TRO = 1, HINH_ANH = "Admin_images.jpg", NGAY_TAO = DateTime.Now, TRANG_THAI = 0, DIA_CHI = "400 Hà Huy Tập, Tân An, TP Buôn Ma Thuột" },
                new NguoiDungModel { ID_NGUOI_DUNG = 12, HO_TEN = "Phạm Bá Hưng", SDT = "0987654322", GTTT = "CMND012", EMAIL = "admin2@gmail.com", TAI_KHOAN = "admin2", MAT_KHAU = "admin2", VAI_TRO = 1, HINH_ANH = "Admin_images.jpg", NGAY_TAO = DateTime.Now, TRANG_THAI = 0, DIA_CHI = "400 Hà Huy Tập, Tân An, TP Buôn Ma Thuột" },

                // 5 nhân viên (mã vai trò = 2)
                new NguoiDungModel { ID_NGUOI_DUNG = 13, HO_TEN = "Trần Tiến Quân", SDT = "0977554321", GTTT = "CMND013", EMAIL = "employee1@gmail.com", TAI_KHOAN = "NhanVien1", MAT_KHAU = "NhanVien1", VAI_TRO = 2, HINH_ANH = "Employee_images.jpg", NGAY_TAO = DateTime.Now, TRANG_THAI = 0, DIA_CHI = "400 Hà Huy Tập, Tân An, TP Buôn Ma Thuột" },
                new NguoiDungModel { ID_NGUOI_DUNG = 14, HO_TEN = "Ngô Kiến Huy", SDT = "0977644322", GTTT = "CMND014", EMAIL = "employee2@gmail.com", TAI_KHOAN = "employee2", MAT_KHAU = "employeepass2", VAI_TRO = 2, HINH_ANH = "Employee_images.jpg", NGAY_TAO = DateTime.Now, TRANG_THAI = 0, DIA_CHI = "400 Hà Huy Tập, Tân An, TP Buôn Ma Thuột" },
                new NguoiDungModel { ID_NGUOI_DUNG = 15, HO_TEN = "Nguyễn Trọng Tính", SDT = "0977654323", GTTT = "CMND015", EMAIL = "employee3@gmail.com", TAI_KHOAN = "employee3", MAT_KHAU = "employeepass3", VAI_TRO = 2, HINH_ANH = "Employee_images.jpg", NGAY_TAO = DateTime.Now, TRANG_THAI = 1, DIA_CHI = "400 Hà Huy Tập, Tân An, TP Buôn Ma Thuột" },
                new NguoiDungModel { ID_NGUOI_DUNG = 16, HO_TEN = "Trần Anh Đức", SDT = "0977654324", GTTT = "CMND016", EMAIL = "employee4@gmail.com", TAI_KHOAN = "employee4", MAT_KHAU = "employeepass4", VAI_TRO = 2, HINH_ANH = "Employee_images.jpg", NGAY_TAO = DateTime.Now, TRANG_THAI = 0, DIA_CHI = "400 Hà Huy Tập, Tân An, TP Buôn Ma Thuột" },
                new NguoiDungModel { ID_NGUOI_DUNG = 17, HO_TEN = "Trần Văn Đức Hồng", SDT = "0977654325", GTTT = "CMND017", EMAIL = "employee5@gmail.com", TAI_KHOAN = "employee5", MAT_KHAU = "employeepass5", VAI_TRO = 2, HINH_ANH = "Employee_images.jpg", NGAY_TAO = DateTime.Now, TRANG_THAI = 0, DIA_CHI = "400 Hà Huy Tập, Tân An, TP Buôn Ma Thuột" }
            );

            modelBuilder.Entity<LoaiSanPhamModel>().HasData(
                new LoaiSanPhamModel { ID_LOAI = 1, TEN_LOAI = "Giày thể thao" },
                new LoaiSanPhamModel { ID_LOAI = 2, TEN_LOAI = "Giày chạy bộ" },
                new LoaiSanPhamModel { ID_LOAI = 3, TEN_LOAI = "Giày bóng rổ" },
                new LoaiSanPhamModel { ID_LOAI = 4, TEN_LOAI = "Giày lifestyle" }
            );

            modelBuilder.Entity<KichThuocSanPhamModel>().HasData(
                new KichThuocSanPhamModel { ID_KICH_THUOC = 1, TEN_KICH_THUOC = 40 },
                new KichThuocSanPhamModel { ID_KICH_THUOC = 2, TEN_KICH_THUOC = 41 },
                new KichThuocSanPhamModel { ID_KICH_THUOC = 3, TEN_KICH_THUOC = 42 },
                new KichThuocSanPhamModel { ID_KICH_THUOC = 4, TEN_KICH_THUOC = 43 },
                new KichThuocSanPhamModel { ID_KICH_THUOC = 5, TEN_KICH_THUOC = 44 }
            );

            modelBuilder.Entity<MauSanPhamModel>().HasData(
                new MauSanPhamModel { ID_MAU = 1, TEN_MAU = "Đỏ" },
                new MauSanPhamModel { ID_MAU = 2, TEN_MAU = "Xanh dương" },
                new MauSanPhamModel { ID_MAU = 3, TEN_MAU = "Đen" },
                new MauSanPhamModel { ID_MAU = 4, TEN_MAU = "Trắng" },
                new MauSanPhamModel { ID_MAU = 5, TEN_MAU = "Xám" }
            );

            modelBuilder.Entity<SanPhamModel>().HasData(
                new SanPhamModel
                {
                    ID_SAN_PHAM = 1,
                    TEN_SAN_PHAM = "Giày Nike Air Zoom Pegasus 40",
                    ID_LOAI = 1, // Giày thể thao
                    ID_KICH_THUOC = 3, // Kích thước 42
                    SO_LUONG = 50,
                    GIA_NHAP = 1500000, // Giá nhập 1.500.000 VNĐ
                    GIA_BAN = 2500000, // Giá bán 2.500.000 VNĐ
                    CHAT_LIEU = "Vải dệt, Cao su",
                    MO_TA = "Giày thể thao Nike Air Zoom Pegasus 40 với công nghệ Zoom Air giúp bạn chạy nhẹ nhàng và thoải mái.",
                    NGAY_TAO = DateTime.Now
                },
                new SanPhamModel
                {
                    ID_SAN_PHAM = 2,
                    TEN_SAN_PHAM = "Giày Nike Zoom Fly 4",
                    ID_LOAI = 2, // Giày chạy bộ
                    ID_KICH_THUOC = 4, // Kích thước 43
                    SO_LUONG = 30,
                    GIA_NHAP = 1800000, // Giá nhập 1.800.000 VNĐ
                    GIA_BAN = 3000000, // Giá bán 3.000.000 VNĐ
                    CHAT_LIEU = "Vải dệt, Cao su, Phylon",
                    MO_TA = "Giày chạy bộ Nike Zoom Fly 4 với đế giày Zoom giúp tạo độ đàn hồi tuyệt vời.",
                    NGAY_TAO = DateTime.Now
                },
                new SanPhamModel
                {
                    ID_SAN_PHAM = 3,
                    TEN_SAN_PHAM = "Giày Nike Air Jordan 1 Retro",
                    ID_LOAI = 3, // Giày bóng rổ
                    ID_KICH_THUOC = 5, // Kích thước 44
                    SO_LUONG = 20,
                    GIA_NHAP = 2500000, // Giá nhập 2.500.000 VNĐ
                    GIA_BAN = 4500000, // Giá bán 4.500.000 VNĐ
                    CHAT_LIEU = "Da, Cao su",
                    MO_TA = "Giày bóng rổ Nike Air Jordan 1 Retro với thiết kế cổ điển, chất liệu da cao cấp, tạo cảm giác thoải mái khi chơi thể thao.",
                    NGAY_TAO = DateTime.Now
                },
                new SanPhamModel
                {
                    ID_SAN_PHAM = 4,
                    TEN_SAN_PHAM = "Giày Nike Air Max 270",
                    ID_LOAI = 1, // Giày thể thao
                    ID_KICH_THUOC = 2, // Kích thước 41
                    SO_LUONG = 40,
                    GIA_NHAP = 1700000, // Giá nhập 1.700.000 VNĐ
                    GIA_BAN = 2900000, // Giá bán 2.900.000 VNĐ
                    CHAT_LIEU = "Vải dệt, Cao su, Phylon",
                    MO_TA = "Giày thể thao Nike Air Max 270 với đế Air Max lớn tạo độ nảy và sự êm ái khi di chuyển.",
                    NGAY_TAO = DateTime.Now
                },
                new SanPhamModel
                {
                    ID_SAN_PHAM = 5,
                    TEN_SAN_PHAM = "Giày Nike Air Force 1 '07",
                    ID_LOAI = 4, // Giày lifestyle
                    ID_KICH_THUOC = 3, // Kích thước 42
                    SO_LUONG = 25,
                    GIA_NHAP = 2000000, // Giá nhập 2.000.000 VNĐ
                    GIA_BAN = 3500000, // Giá bán 3.500.000 VNĐ
                    CHAT_LIEU = "Da, Cao su",
                    MO_TA = "Giày Nike Air Force 1 '07 mang phong cách cổ điển, dễ dàng kết hợp với nhiều trang phục.",
                    NGAY_TAO = DateTime.Now
                }
            );


        }

    }

}
