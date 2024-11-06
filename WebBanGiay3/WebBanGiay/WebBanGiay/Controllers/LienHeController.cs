using Microsoft.AspNetCore.Mvc;
using WebBanGiay.Models;
using WebBanGiay.Services; // Đảm bảo bạn đã thêm service EmailService vào dự án

public class LienHeController : Controller
{
    private readonly EmailService _emailService;

    public LienHeController(EmailService emailService)
    {
        _emailService = emailService;
    }

    public IActionResult Index()
    {
        return View(new LienHeModel());
    }

    [HttpPost]
    public async Task<IActionResult> Index(LienHeModel model)
    {
        if (ModelState.IsValid)
        {
            string subject = $"Liên hệ từ {model.Name}";
            string body = $"Tên: {model.Name}<br>Email: {model.Email}<br>Số điện thoại: {model.Phone}<br>Nội dung: {model.Message}";

            try
            {
                await _emailService.SendEmailAsync("nguyenhuythien9a1@gmail.com", subject, body); 

                TempData["ThanhCong"] = "Tin nhắn của bạn đã được gửi thành công!";
            }
            catch (Exception ex)
            {
                TempData["ThatBai"] = "Có lỗi xảy ra khi gửi tin nhắn. Vui lòng thử lại.";

            }

            return RedirectToAction("Index"); 
        }

        return View(model);
    }
}
