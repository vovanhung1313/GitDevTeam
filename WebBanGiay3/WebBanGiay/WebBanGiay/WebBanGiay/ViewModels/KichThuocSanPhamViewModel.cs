using WebBanGiay.Models;

namespace WebBanGiay.ViewModels
{
    public class KichThuocSanPhamViewModel
    {
        public IEnumerable<KichThuocSanPhamModel> DanhSachKichThuoc { get; set; }
        public KichThuocSanPhamModel KichThuoc { get; set; }
    }
}
