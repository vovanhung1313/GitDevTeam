using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebBanGiay.Models;
using WebBanGiay.Services; // Giả định rằng bạn đã tạo dịch vụ EmailService trong thư mục Services

namespace WebBanGiay.Controllers
{
    public class GioiThieuController : Controller
    {
        private readonly EmailService _emailService;

        public GioiThieuController(EmailService emailService)
        {
            _emailService = emailService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RegisterNewsletter(GioiThieuModel model)
        {
            if (ModelState.IsValid)
            {


                string subject = "Đăng ký nhận bản tin thành công";
                string body = "Chào bạn! Bạn đã đăng ký thành công để nhận các ưu đãi mới nhất từ chúng tôi.";


                await _emailService.SendEmailAsync(model.Email, subject, body);

                TempData["ThanhCong"] = "Đăng ký nhận bản tin thành công!";
                return RedirectToAction("Index");
            }

            TempData["ThatBai"] = "Vui lòng nhập email hợp lệ!";
            return RedirectToAction("Index");
        }
    }
}
