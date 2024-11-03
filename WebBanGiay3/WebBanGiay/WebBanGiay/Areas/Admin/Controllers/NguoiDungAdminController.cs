using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebBanGiay.Models;
using WebBanGiay.Repository;
using WebBanGiay.Repositoty;
using X.PagedList;

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

        [Route("Admin/NguoiDungAdmin")]
        public async Task<IActionResult> Index(int page = 1, int pageSize = 10)
        {
            var nguoiDungs = await _dataContext.NGUOI_DUNGs
                .Where(n => n.VAI_TRO == 0)
                .ToListAsync();

            var pagedNguoiDungs = nguoiDungs.ToPagedList(page, pageSize);

            return View(pagedNguoiDungs);
        }

        public IActionResult ThemNguoiDung()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ThemNguoiDung(NguoiDungModel nguoiDungModel)
        {
            if (ModelState.IsValid)
            {
                if (await _dataContext.NGUOI_DUNGs.AnyAsync(m => m.TAI_KHOAN == nguoiDungModel.TAI_KHOAN))
                {
                    TempData["ThatBai"] = "Tài khoản đã có người sử dụng.";
                    return View(nguoiDungModel);
                }
                if (await _dataContext.NGUOI_DUNGs.AnyAsync(m => m.SDT == nguoiDungModel.SDT))
                {
                    TempData["ThatBai"] = "Số điện thoại đã có người sử dụng.";
                    return View(nguoiDungModel);
                }
                if (await _dataContext.NGUOI_DUNGs.AnyAsync(m => m.EMAIL == nguoiDungModel.EMAIL))
                {
                    TempData["ThatBai"] = "Email đã có người sử dụng.";
                    return View(nguoiDungModel);
                }

                nguoiDungModel.HINH_ANH = "User_images.jpg";
                nguoiDungModel.GTTT = "User_images.jpg";
                nguoiDungModel.VAI_TRO = 0;
                nguoiDungModel.NGAY_TAO = DateTime.Now;
                nguoiDungModel.TRANG_THAI = 0;

                _dataContext.Add(nguoiDungModel);
                await _dataContext.SaveChangesAsync();

                TempData["ThanhCong"] = "Thêm khách hàng thành công!";
                return RedirectToAction(nameof(Index));
            }

            TempData["ThatBai"] = "Thêm khách hàng thất bại!";
            return View(nguoiDungModel);
        }




        [HttpGet("Admin/NguoiDungAdmin/SuaNguoiDung/{id}")]
        public async Task<IActionResult> SuaNguoiDung(int id)
        {
            var nguoiDungModel = await _dataContext.NGUOI_DUNGs.FindAsync(id);
            if (nguoiDungModel == null)
            {
                return NotFound();
            }

            return View(nguoiDungModel);
        }

        [HttpPost("Admin/NguoiDungAdmin/SuaNguoiDung")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SuaNguoiDung(NguoiDungModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // Kiểm tra email đã tồn tại và không trùng với người dùng hiện tại
            var emailExists = await _dataContext.NGUOI_DUNGs
                .AnyAsync(nd => nd.EMAIL == model.EMAIL && nd.ID_NGUOI_DUNG != model.ID_NGUOI_DUNG);

            if (emailExists)
            {
                ModelState.AddModelError("EMAIL", "Email đã tồn tại. Vui lòng nhập email khác.");
                return View(model);
            }

            // Kiểm tra số điện thoại đã tồn tại và không trùng với người dùng hiện tại
            var phoneExists = await _dataContext.NGUOI_DUNGs
                .AnyAsync(nd => nd.SDT == model.SDT && nd.ID_NGUOI_DUNG != model.ID_NGUOI_DUNG);

            if (phoneExists)
            {
                ModelState.AddModelError("SDT", "Số điện thoại đã tồn tại. Vui lòng nhập số điện thoại khác.");
                return View(model);
            }

            var nguoiDungModel = await _dataContext.NGUOI_DUNGs.FindAsync(model.ID_NGUOI_DUNG);
            if (nguoiDungModel == null)
            {
                return NotFound();
            }

            nguoiDungModel.HO_TEN = model.HO_TEN;
            nguoiDungModel.SDT = model.SDT;
            nguoiDungModel.EMAIL = model.EMAIL;
            nguoiDungModel.DIA_CHI = model.DIA_CHI;

            await _dataContext.SaveChangesAsync();

            TempData["ThanhCong"] = "Cập nhật thông tin người dùng thành công!";
            return RedirectToAction(nameof(Index));
        }





        public async Task<IActionResult> XoaNguoiDung(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nguoiDungModel = await _dataContext.NGUOI_DUNGs
                .FirstOrDefaultAsync(m => m.ID_NGUOI_DUNG == id);
            if (nguoiDungModel == null)
            {
                return NotFound();
            }

            return View(nguoiDungModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> XoaNguoiDung(int id)
        {
            var nguoiDungModel = await _dataContext.NGUOI_DUNGs.FindAsync(id);
            if (nguoiDungModel != null)
            {
                _dataContext.NGUOI_DUNGs.Remove(nguoiDungModel);
                await _dataContext.SaveChangesAsync();
                TempData["ThanhCong"] = "Người dùng đã được xóa thành công.";
            }
            else
            {
                TempData["ThatBai"] = "Người dùng không tồn tại.";
            }

            return RedirectToAction(nameof(Index));
        }

        public IActionResult DangXuat()
        {
            HttpContext.Session.Remove("User");
            TempData["ThanhCong"] = "Đăng xuất thành công";
            return RedirectToAction("DangNhap", "NguoiDung", new { area = "" });
        }
    }
}
