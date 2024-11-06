using Microsoft.AspNetCore.Mvc;

namespace WebBanGiay.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DonHangAdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
