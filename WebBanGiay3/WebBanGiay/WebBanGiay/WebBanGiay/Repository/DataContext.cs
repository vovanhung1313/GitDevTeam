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
    }
}
