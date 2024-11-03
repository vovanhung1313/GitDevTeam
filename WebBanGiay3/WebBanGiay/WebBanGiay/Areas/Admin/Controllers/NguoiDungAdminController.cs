using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebBanGiay.Models;
using WebBanGiay.Repository;
using WebBanGiay.Repositoty;

namespace WebBanGiay.Areas.Admin.Controllers
{

    [Area("Admin")]
    public class NguoiDungAdminController : Controller
    {
        private readonly DataContext _dataContext;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public NguoiDungAdminController(DataContext dataContext, IWebHostEnvironment webHostEnvironment)
        {
            _dataContext = dataContext;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ThemNguoiDung()
        {
            return View();
        }
        public IActionResult SuaNguoiDung()
        {
            return View();
        }


       
        public IActionResult DangXuat()
        {
            HttpContext.Session.Remove("User");
            TempData["ThanhCong"] = "Đăng xuất thành công";
            return RedirectToAction("DangNhap", "NguoiDung", new { area = "" });
        }
    }
}
