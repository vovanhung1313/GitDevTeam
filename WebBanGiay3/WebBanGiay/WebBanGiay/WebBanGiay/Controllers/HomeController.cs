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
                             .Where(sp => sp.SO_LUONG > 0)
                             .Take(9)
                             .ToList();

            var sanphamnoibat = _dataContext.SAN_PHAMs
                             .Include(sp => sp.HINH_ANH)
                             .Where(sp => sp.SO_LUONG > 0)
                             .Take(3)
                             .OrderByDescending(s => s.NGAY_TAO)
                             .ToList();

            ViewBag.NoiBat = sanphamnoibat;
            return View(sanPham);
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
