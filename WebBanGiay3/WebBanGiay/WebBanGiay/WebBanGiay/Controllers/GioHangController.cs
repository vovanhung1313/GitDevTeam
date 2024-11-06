using Microsoft.AspNetCore.Mvc;

namespace WebBanGiay.Controllers
{
    public class GioHangController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
