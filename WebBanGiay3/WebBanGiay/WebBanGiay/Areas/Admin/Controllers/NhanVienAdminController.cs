using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebBanGiay.Areas.Admin.Controllers
{

    [Area("Admin")]
    public class NhanVienAdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ThemNhanVien()
        {
            return View();
        }
        public IActionResult SuaNhanVien()
        {
            return View();
        }
    }
}
