using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net.Mail;
using System.Net;
using WebBanGiay.Models;
using WebBanGiay.Repository;
using WebBanGiay.Repositoty;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace WebBanGiay.Controllers
{
    public class NguoiDungController : Controller
    {
        private readonly DataContext _dataContext;

        public NguoiDungController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public IActionResult DangNhap()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DangNhap(string TAI_KHOAN, string MAT_KHAU)
        {
            if (ModelState.IsValid)
            {

                var khachHang = await _dataContext.NGUOI_DUNGs
                    .FirstOrDefaultAsync(kh => (kh.TAI_KHOAN == TAI_KHOAN || kh.EMAIL == TAI_KHOAN || kh.SDT == TAI_KHOAN) && kh.MAT_KHAU == MAT_KHAU);

                if (khachHang != null)
                {

                    HttpContext.Session.SetJson("User", khachHang);
                    
                    TempData["ThanhCong"] = "Đăng nhập thành công";




                    if (khachHang.VAI_TRO == 1)
                    {

                        return RedirectToAction("Index", "HomeAdmin", new { area = "Admin" });
                    }
                    else if (khachHang.VAI_TRO == 2)
                    {
                        return RedirectToAction("Index", "HomeNhanVien", new { area = "NhanVien" });
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Tên tài khoản hoặc mật khẩu không đúng.");
                }
            }

            return View();
        }

        public IActionResult DangKy()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DangKy(NguoiDungModel nguoiDung)
        {
            if (ModelState.IsValid)
            {

                if (await _dataContext.NGUOI_DUNGs.AnyAsync(nd => nd.TAI_KHOAN == nguoiDung.TAI_KHOAN))
                {
                    ModelState.AddModelError("TAI_KHOAN", "Tài khoản này đã được sử dụng.");
                    return View(nguoiDung);
                }

                if (await _dataContext.NGUOI_DUNGs.AnyAsync(nd => nd.SDT == nguoiDung.SDT))
                {
                    ModelState.AddModelError("SDT", "Số điện thoại này đã được sử dụng.");
                    return View(nguoiDung);
                }

                if (await _dataContext.NGUOI_DUNGs.AnyAsync(nd => nd.EMAIL == nguoiDung.EMAIL))
                {
                    ModelState.AddModelError("EMAIL", "Email này đã được sử dụng.");
                    return View(nguoiDung);
                }


                nguoiDung.VAI_TRO = 0; 
                nguoiDung.HINH_ANH = "User_images.jpg";
                nguoiDung.GTTT = "User_images.jpg";
                nguoiDung.NGAY_TAO = DateTime.Now;
                nguoiDung.TRANG_THAI = 0; 

                _dataContext.Add(nguoiDung);
                await _dataContext.SaveChangesAsync();
                TempData["ThanhCong"] = "Đăng ký thành công";
               
                return RedirectToAction(nameof(DangNhap));
            }

            return View(nguoiDung);
        }

        public IActionResult DangXuat()
        {
            HttpContext.Session.Remove("User");
            TempData["ThanhCong"] = "Đăng xuất thành công";
            return RedirectToAction("DangNhap");
        }


        public IActionResult TrangCaNhan()
        {
            var user = HttpContext.Session.GetJson<NguoiDungModel>("User");
            if (user == null)
            {
                return RedirectToAction("DangNhap");
            }
            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> TrangCaNhan(NguoiDungModel modelNguoiDung, IFormFile? HinhAnhTaiLen)
        {
            var user = HttpContext.Session.GetJson<NguoiDungModel>("User");
            if (user == null)
            {
                return RedirectToAction("DangNhap");
            }

            var userInfo = await _dataContext.NGUOI_DUNGs
                .FirstOrDefaultAsync(u => u.ID_NGUOI_DUNG == user.ID_NGUOI_DUNG);

            if (userInfo == null)
            {
                ModelState.AddModelError(string.Empty, "Không tìm thấy người dùng.");
                return View(modelNguoiDung);
            }


            userInfo.HO_TEN = modelNguoiDung.HO_TEN;
            userInfo.SDT = modelNguoiDung.SDT;
            userInfo.EMAIL = modelNguoiDung.EMAIL;
            userInfo.GTTT = modelNguoiDung.GTTT;
            userInfo.DIA_CHI = modelNguoiDung.DIA_CHI;


            if (HinhAnhTaiLen != null && HinhAnhTaiLen.Length > 0)
            {
                var fileName = Path.GetFileName(HinhAnhTaiLen.FileName);
                var filePath = Path.Combine("wwwroot/media/KhachHang", fileName);

                if (!Directory.Exists(Path.GetDirectoryName(filePath)))
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(filePath));
                }

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await HinhAnhTaiLen.CopyToAsync(fileStream);
                }

                userInfo.HINH_ANH = fileName;
            }

            _dataContext.Update(userInfo);
            await _dataContext.SaveChangesAsync();
            HttpContext.Session.SetJson("User", userInfo);

            TempData["ThanhCong"] = "Đã cập nhật thông tin thành công.";
            return RedirectToAction("TrangCaNhan");
        }




        [HttpGet]
        public IActionResult QuenMatKhau()
        {
            return View(new QuenMatKhauModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> QuenMatKhau(QuenMatKhauModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _dataContext.NGUOI_DUNGs
                    .FirstOrDefaultAsync(u => u.EMAIL == model.Email);

                if (user == null)
                {
                    TempData["ThatBai"] = "Email không đúng.";
                }
                else
                {
                    string otp = GenerateOTP(6);

                    HttpContext.Session.SetString("UserEmail", user.EMAIL);
                    HttpContext.Session.SetString("OTP", otp);
                    HttpContext.Session.SetString("OTPExpiration", DateTime.Now.AddMinutes(10).ToString());
                    var smtpClient = new SmtpClient("smtp.gmail.com")
                    {

                        Port = 587,
                        Credentials = new NetworkCredential("nguyenhuythien9a1@gmail.com", "psezvpsaugwqgwcf"),
                        EnableSsl = true,
                    };

                    var mailMessage = new MailMessage
                    {
                        From = new MailAddress("nguyenhuythien9a1@gmail.com"),
                        Subject = "Mã OTP Đặt lại mật khẩu TeamDev !!",
                        Body = $"Mã OTP của bạn là: {otp}   \nHãy sử dụng mã này trong vòng 10 phút.",
                        IsBodyHtml = false,
                    };
                    mailMessage.To.Add(user.EMAIL);

                    try
                    {
                        await smtpClient.SendMailAsync(mailMessage);
                        TempData["ThanhCong"] = "Một mã OTP đã được gửi đến email của bạn.";
                    }
                    catch (SmtpException smtpEx)
                    {
                        TempData["ThatBai"] = "Có lỗi SMTP xảy ra khi gửi email: " + smtpEx.Message;
                    }
                    catch (Exception ex)
                    {
                        TempData["ThatBai"] = "Có lỗi xảy ra khi gửi email: " + ex.Message;
                    }
                }
            }

            return View(model);
        }

        private string GenerateOTP(int length)
        {
            const string chars = "0123456789";
            var random = new Random();
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ResetPassword(string code, string matKhauMoi, string xacNhanMatKhauMoi)
        {
            if (matKhauMoi != xacNhanMatKhauMoi)
            {
                TempData["ThatBai"] = "Mật khẩu xác nhận không khớp.";
                return RedirectToAction("QuenMatKhau"); 
            }

            if (matKhauMoi.Length < 5 || matKhauMoi.Length > 20 || xacNhanMatKhauMoi.Length < 5 || xacNhanMatKhauMoi.Length > 20)
            {
                TempData["ThatBai"] = "Mật khẩu mới và mật khẩu xác nhận phải có độ dài từ 5 đến 20 ký tự.";
                return RedirectToAction("QuenMatKhau");
            }

            var storedOtp = HttpContext.Session.GetString("OTP");
            var storedEmail = HttpContext.Session.GetString("UserEmail");
            var expiration = HttpContext.Session.GetString("OTPExpiration");

            if (storedOtp == null || storedEmail == null || expiration == null)
            {
                TempData["ThatBai"] = "Thông tin xác thực không hợp lệ.";
                return RedirectToAction("QuenMatKhau");
            }

            if (code != storedOtp || DateTime.Parse(expiration) <= DateTime.Now)
            {
                TempData["ThatBai"] = "Mã OTP không hợp lệ hoặc đã hết hạn.";
                return RedirectToAction("QuenMatKhau");
            }

            var user = await _dataContext.NGUOI_DUNGs
                .FirstOrDefaultAsync(u => u.EMAIL == storedEmail);

            if (user == null)
            {
                TempData["ThatBai"] = "Người dùng không tồn tại.";
                return RedirectToAction("QuenMatKhau");
            }

            user.MAT_KHAU = matKhauMoi;
            _dataContext.Update(user);
            await _dataContext.SaveChangesAsync();

            HttpContext.Session.Remove("OTP");
            HttpContext.Session.Remove("UserEmail");
            HttpContext.Session.Remove("OTPExpiration");

            TempData["ThanhCong"] = "Mật khẩu của bạn đã được đổi thành công.";
            return RedirectToAction("DangNhap");
        }



        [HttpGet]
        public IActionResult GoogleLogin(string returnUrl = null)
        {
            var redirectUrl = Url.Action("GoogleResponse", "NguoiDung", new { returnUrl });
            var properties = new AuthenticationProperties { RedirectUri = redirectUrl };
            return Challenge(properties, GoogleDefaults.AuthenticationScheme);
        }

        [HttpGet]
        public async Task<IActionResult> GoogleResponse(string returnUrl = null)
        {
            var info = await HttpContext.AuthenticateAsync(GoogleDefaults.AuthenticationScheme);
            if (info?.Principal != null)
            {
                var email = info.Principal.FindFirstValue(ClaimTypes.Email);
                var name = info.Principal.FindFirstValue(ClaimTypes.Name);


                if (string.IsNullOrEmpty(email))
                {
                    TempData["ThatBai"] = "Không thể lấy địa chỉ email từ tài khoản Google.";
                    return RedirectToAction("DangNhap");
                }

                var user = await _dataContext.NGUOI_DUNGs.FirstOrDefaultAsync(u => u.EMAIL == email);
                if (user == null)
                {
                    user = new NguoiDungModel
                    {
                        EMAIL = email, 
                        TAI_KHOAN = email,
                        HO_TEN = name,
                        VAI_TRO = 0, 
                        HINH_ANH = "User_images.jpg",
                        NGAY_TAO = DateTime.Now,
                        DIA_CHI = "100 Ha Huy Tap",
                        TRANG_THAI = 0, 
                        SDT = "0383777823",
                        GTTT = "User_images.jpg",
                        MAT_KHAU = "123456"
                    };

                    await _dataContext.NGUOI_DUNGs.AddAsync(user);
                    await _dataContext.SaveChangesAsync();
                }


                HttpContext.Session.SetJson("User", user);
                TempData["ThanhCong"] = "Đăng nhập thành công";

                if (user.VAI_TRO == 1)
                {
                    return RedirectToAction("Index", "HomeAdmin", new { area = "Admin" });
                }
                else if (user.VAI_TRO == 2)
                {
                    return RedirectToAction("Index", "HomeNhanVien", new { area = "NhanVien" });
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }

            TempData["ThatBai"] = "Đăng nhập không thành công.";
            return RedirectToAction("DangNhap");
        }


    }
}
