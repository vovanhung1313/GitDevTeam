using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebBanGiay.Repositoty;

namespace WebBanGiay.Areas.Admin.Controllers
{

    [Area("Admin")]
    [Route("Admin")]
    [Route("Admin/HomeAdmin")]
    public class HomeAdminController : Controller
    {
        [Route("")]
        [Route("Index")]
        public IActionResult Index()
        {
            return View();
        }
    }

}
