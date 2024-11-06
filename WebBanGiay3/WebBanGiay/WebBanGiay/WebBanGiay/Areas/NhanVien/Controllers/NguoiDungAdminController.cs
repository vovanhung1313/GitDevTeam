using Microsoft.AspNetCore.Mvc;

namespace WebBanGiay.Areas.NhanVien.Controllers
{
    public class NguoiDungAdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
