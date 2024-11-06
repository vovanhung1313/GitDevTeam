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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Dữ liệu mẫu cho bảng NGUOI_DUNGs
            modelBuilder.Entity<NguoiDungModel>().HasData(
                // 10 khách hàng (vai trò = 0)
                new NguoiDungModel { ID_NGUOI_DUNG = 1, HO_TEN = "Hồ Huy Linh", SDT = "0912345671", GTTT = "CMND", EMAIL = "khachhang1@example.com", TAI_KHOAN = "khachhang1", MAT_KHAU = "matkhau1", VAI_TRO = 0, HINH_ANH = "avt1.jpg", NGAY_TAO = DateTime.Now, DIA_CHI = "Địa chỉ 123 Hà Huy Tập, Tân An, TP Buôm Mê Thuột" },
                new NguoiDungModel { ID_NGUOI_DUNG = 2, HO_TEN = "Hồ Huy Long", SDT = "0912345672", GTTT = "CMND", EMAIL = "khachhang2@example.com", TAI_KHOAN = "khachhang2", MAT_KHAU = "matkhau2", VAI_TRO = 0, HINH_ANH = "avt1.jpg", NGAY_TAO = DateTime.Now, DIA_CHI = "Địa chỉ 123 Hà Huy Tập, Tân An, TP Buôm Mê Thuột" },
                new NguoiDungModel { ID_NGUOI_DUNG = 3, HO_TEN = "Hồ Huy Quân", SDT = "0912345673", GTTT = "CMND", EMAIL = "khachhang3@example.com", TAI_KHOAN = "khachhang3", MAT_KHAU = "matkhau3", VAI_TRO = 0, HINH_ANH = "avt1.jpg", NGAY_TAO = DateTime.Now, DIA_CHI = "Địa chỉ 123 Hà Huy Tập, Tân An, TP Buôm Mê Thuột" },
                new NguoiDungModel { ID_NGUOI_DUNG = 4, HO_TEN = "Võ Văn Hưng", SDT = "0912345674", GTTT = "CMND", EMAIL = "khachhang4@example.com", TAI_KHOAN = "khachhang4", MAT_KHAU = "matkhau4", VAI_TRO = 0, HINH_ANH = "avt1.jpg", NGAY_TAO = DateTime.Now, DIA_CHI = "Địa chỉ 123 Hà Huy Tập, Tân An, TP Buôm Mê Thuột" },
                new NguoiDungModel { ID_NGUOI_DUNG = 5, HO_TEN = "Phạm Bá Hậu", SDT = "0912345675", GTTT = "CMND", EMAIL = "khachhang5@example.com", TAI_KHOAN = "khachhang5", MAT_KHAU = "matkhau5", VAI_TRO = 0, HINH_ANH = "avt1.jpg", NGAY_TAO = DateTime.Now, DIA_CHI = "Địa chỉ 123 Hà Huy Tập, Tân An, TP Buôm Mê Thuột" },
                new NguoiDungModel { ID_NGUOI_DUNG = 6, HO_TEN = "Nguyễn Quang Quý", SDT = "0912345676", GTTT = "CMND", EMAIL = "khachhang6@example.com", TAI_KHOAN = "khachhang6", MAT_KHAU = "matkhau6", VAI_TRO = 0, HINH_ANH = "avt1.jpg", NGAY_TAO = DateTime.Now, DIA_CHI = "Địa chỉ 123 Hà Huy Tập, Tân An, TP Buôm Mê Thuột" },
                new NguoiDungModel { ID_NGUOI_DUNG = 7, HO_TEN = "Nguyễn Gia Nghi", SDT = "0912345677", GTTT = "CMND", EMAIL = "khachhang7@example.com", TAI_KHOAN = "khachhang7", MAT_KHAU = "matkhau7", VAI_TRO = 0, HINH_ANH = "avt1.jpg", NGAY_TAO = DateTime.Now, DIA_CHI = "Địa chỉ 123 Hà Huy Tập, Tân An, TP Buôm Mê Thuột" },
                new NguoiDungModel { ID_NGUOI_DUNG = 8, HO_TEN = "Nguyễn Phú Hưng", SDT = "0912345678", GTTT = "CMND", EMAIL = "khachhang8@example.com", TAI_KHOAN = "khachhang8", MAT_KHAU = "matkhau8", VAI_TRO = 0, HINH_ANH = "avt1.jpg", NGAY_TAO = DateTime.Now, DIA_CHI = "Địa chỉ 123 Hà Huy Tập, Tân An, TP Buôm Mê Thuột" },
                new NguoiDungModel { ID_NGUOI_DUNG = 9, HO_TEN = "Phạm Phượng", SDT = "0912345679", GTTT = "CMND", EMAIL = "khachhang9@example.com", TAI_KHOAN = "khachhang9", MAT_KHAU = "matkhau9", VAI_TRO = 0, HINH_ANH = "avt1.jpg", NGAY_TAO = DateTime.Now, DIA_CHI = "Địa chỉ 123 Hà Huy Tập, Tân An, TP Buôm Mê Thuột" },
                new NguoiDungModel { ID_NGUOI_DUNG = 10, HO_TEN = "Tạ Minh Tâm", SDT = "0912345680", GTTT = "CMND", EMAIL = "khachhang10@example.com", TAI_KHOAN = "khachhang10", MAT_KHAU = "matkhau10", VAI_TRO = 0, HINH_ANH = "avt1.jpg", NGAY_TAO = DateTime.Now, DIA_CHI = "Địa chỉ 123 Hà Huy Tập, Tân An, TP Buôm Mê Thuột" },

                // 3 admin (vai trò = 1)
                new NguoiDungModel { ID_NGUOI_DUNG = 11, HO_TEN = "Võ Văn Hưng", SDT = "0912345681", GTTT = "CMND", EMAIL = "admin1@example.com", TAI_KHOAN = "admin1", MAT_KHAU = "admin1", VAI_TRO = 1, HINH_ANH = "avt1.jpg", NGAY_TAO = DateTime.Now, DIA_CHI = "Địa chỉ 116 Đồng Khởi, Tân An, TP Buôm Mê Thuột" },
                new NguoiDungModel { ID_NGUOI_DUNG = 12, HO_TEN = "Bùi Phương Linh", SDT = "0912345682", GTTT = "CMND", EMAIL = "admin2@example.com", TAI_KHOAN = "admin2", MAT_KHAU = "matkhau12", VAI_TRO = 1, HINH_ANH = "avt1.jpg", NGAY_TAO = DateTime.Now, DIA_CHI = "Địa chỉ 116 Đồng Khởi, Tân An, TP Buôm Mê Thuột" },
                new NguoiDungModel { ID_NGUOI_DUNG = 13, HO_TEN = "Nguyễn Hoàng Trọng Khôi", SDT = "0912345683", GTTT = "CMND", EMAIL = "admin3@example.com", TAI_KHOAN = "admin3", MAT_KHAU = "matkhau13", VAI_TRO = 1, HINH_ANH = "avt1.jpg", NGAY_TAO = DateTime.Now, DIA_CHI = "Địa chỉ 116 Đồng Khởi, Tân An, TP Buôm Mê Thuột" },

                // 5 nhân viên (vai trò = 2)
                new NguoiDungModel { ID_NGUOI_DUNG = 14, HO_TEN = "Nguyễn Hoàng Anh", SDT = "0912345684", GTTT = "CMND", EMAIL = "nhanvien1@example.com", TAI_KHOAN = "nhanvien1", MAT_KHAU = "matkhau14", VAI_TRO = 2, HINH_ANH = "avt1.jpg", NGAY_TAO = DateTime.Now, DIA_CHI = "Địa chỉ Nguyễn Bỉnh Khiêm, Tân Hợi, TP Buôm Mê Thuột" },
                new NguoiDungModel { ID_NGUOI_DUNG = 15, HO_TEN = "Phạm Ngũ Lão", SDT = "0912345685", GTTT = "CMND", EMAIL = "nhanvien2@example.com", TAI_KHOAN = "nhanvien2", MAT_KHAU = "matkhau15", VAI_TRO = 2, HINH_ANH = "avt1.jpg", NGAY_TAO = DateTime.Now, DIA_CHI = "Địa chỉ Nguyễn Bỉnh Khiêm, Tân Hợi, TP Buôm Mê Thuột" },
                new NguoiDungModel { ID_NGUOI_DUNG = 16, HO_TEN = "Trần Quốc Toản", SDT = "0912345686", GTTT = "CMND", EMAIL = "nhanvien3@example.com", TAI_KHOAN = "nhanvien3", MAT_KHAU = "matkhau16", VAI_TRO = 2, HINH_ANH = "avt1.jpg", NGAY_TAO = DateTime.Now, DIA_CHI = "Địa chỉ Nguyễn Bỉnh Khiêm, Tân Hợi, TP Buôm Mê Thuột" },
                new NguoiDungModel { ID_NGUOI_DUNG = 17, HO_TEN = "Phạm Bá Thiên", SDT = "0912345687", GTTT = "CMND", EMAIL = "nhanvien4@example.com", TAI_KHOAN = "nhanvien4", MAT_KHAU = "matkhau17", VAI_TRO = 2, HINH_ANH = "avt1.jpg", NGAY_TAO = DateTime.Now, DIA_CHI = "Địa chỉ Nguyễn Bỉnh Khiêm, Tân Hợi, TP Buôm Mê Thuột" },
                new NguoiDungModel { ID_NGUOI_DUNG = 18, HO_TEN = "Trần Tiến Luật", SDT = "0912345688", GTTT = "CMND", EMAIL = "nhanvien5@example.com", TAI_KHOAN = "nhanvien5", MAT_KHAU = "matkhau18", VAI_TRO = 2, HINH_ANH = "avt1.jpg", NGAY_TAO = DateTime.Now, DIA_CHI = "Địa chỉ Nguyễn Bỉnh Khiêm, Tân Hợi, TP Buôm Mê Thuột" }
            );
        }

    }
}
