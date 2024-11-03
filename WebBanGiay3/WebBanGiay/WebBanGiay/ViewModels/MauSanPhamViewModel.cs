using WebBanGiay.Models;


namespace WebBanGiay.ViewModels
{
    public class MauSanPhamViewModel
    {
        public IEnumerable<MauSanPhamModel> DanhSachMau { get; set; }
        public MauSanPhamModel mau { get; set; }
    }
}
