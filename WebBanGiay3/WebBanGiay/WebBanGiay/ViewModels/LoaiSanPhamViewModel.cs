
using WebBanGiay.Models;

namespace WebBanGiay.ViewModels
{
    public class LoaiSanPhamViewModel
    {
        public IEnumerable<LoaiSanPhamModel> LoaiSanPhams { get; set; }
        public LoaiSanPhamModel LoaiSanPham { get; set; }
    }
}
