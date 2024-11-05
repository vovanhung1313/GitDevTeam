using Microsoft.AspNetCore.Mvc;

namespace WebBanGiay.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SanPhamAdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
