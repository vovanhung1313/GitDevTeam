using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using WebBanGiay.Models;
using WebBanGiay.Repositoty;

namespace WebBanGiay.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DataContext _dataContext;

        public HomeController(ILogger<HomeController> logger, DataContext dataContext)
        {
            _logger = logger;
            _dataContext = dataContext;
        }

        public IActionResult Index()
        {
            var sanPham = _dataContext.SAN_PHAMs
                                     .Include(sp => sp.HINH_ANH)
                                     .Where(sp => sp.SO_LUONG > 0)  // Chỉ lấy sản phẩm còn hàng
                                     .OrderByDescending(sp => sp.NGAY_TAO)  // Sắp xếp theo ngày tạo mới nhất
                                     .Take(12)  // Lấy tối đa 12 sản phẩm
                                     .ToList();

            return View(sanPham);
        }

        public IActionResult TatCaSanPhamMoi()
        {
            var sanPham = _dataContext.SAN_PHAMs
                                     .Include(sp => sp.HINH_ANH)
                                     .Where(sp => sp.SO_LUONG > 0)  // Chỉ lấy sản phẩm còn hàng
                                     .OrderByDescending(sp => sp.NGAY_TAO)  // Sắp xếp theo ngày tạo mới nhất
                                     .ToList();  // Lấy toàn bộ sản phẩm

            return View(sanPham);
        }

        public IActionResult TatCaSanPhamCu()
        {
            var sanPham = _dataContext.SAN_PHAMs
                                     .Include(sp => sp.HINH_ANH)
                                     .Where(sp => sp.SO_LUONG > 0)  // Chỉ lấy sản phẩm còn hàng
                                     .ToList();  // Lấy toàn bộ sản phẩm

            return View(sanPham);
        }
        public IActionResult SanPhamBanChay()
        {
            var sanPhamBanChay = _dataContext.CHI_TIET_DON_HANGs
                                            .GroupBy(ct => ct.ID_SAN_PHAM)  // Nhóm theo ID sản phẩm
                                            .Select(g => new
                                            {
                                                ID_SAN_PHAM = g.Key,
                                                TongSoLuong = g.Sum(ct => ct.SO_LUONG)  // Tính tổng số lượng bán
                                            })
                                            .OrderByDescending(g => g.TongSoLuong)  // Sắp xếp giảm dần theo tổng số lượng
                                            .Take(12)  // Lấy 12 sản phẩm có số lượng bán cao nhất
                                            .Join(_dataContext.SAN_PHAMs,  // Kết hợp với bảng sản phẩm
                                                  top => top.ID_SAN_PHAM,
                                                  sp => sp.ID_SAN_PHAM,
                                                  (top, sp) => sp)  // Trả về đối tượng sản phẩm
                                            .Include(sp => sp.HINH_ANH)  // Bao gồm hình ảnh của sản phẩm
                                            .Where(sp => sp.SO_LUONG > 0)  // Chỉ lấy sản phẩm còn hàng
                                            .ToList();

            return View(sanPhamBanChay);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public async Task<IActionResult> ThemGioHang()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
