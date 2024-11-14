using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebBanGiay.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebBanGiay.Models;
using WebBanGiay.Repositoty;
using X.PagedList;

namespace WebBanGiay.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class NhanVienAdminController : Controller
    {
        private readonly DataContext _dataContext;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public NhanVienAdminController(DataContext dataContext, IWebHostEnvironment webHostEnvironment)
        {
            _dataContext = dataContext;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: Admin/NhanVienAdmin
        public async Task<IActionResult> Index(int page = 1, int pageSize = 10)
        {
            var nhanViens = await _dataContext.NGUOI_DUNGs
                .Where(n => n.VAI_TRO == 2)
                .ToListAsync();

            var pagedNguoiDungs = nhanViens.ToPagedList(page, pageSize);
            return View(pagedNguoiDungs);
        }

        // GET: Admin/NhanVienAdmin/ThemNhanVien
        public IActionResult ThemNhanVien()
        {
            return View();
        }

        // POST: Admin/NhanVienAdmin/ThemNhanVien
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ThemNhanVien(NguoiDungModel nhanVienModel)
        {
            if (ModelState.IsValid)
            {
                nhanVienModel.NGAY_TAO = DateTime.Now;
                nhanVienModel.TRANG_THAI = 1; // Active status

                await _dataContext.NGUOI_DUNGs.AddAsync(nhanVienModel);
                await _dataContext.SaveChangesAsync();

                TempData["ThanhCong"] = "Thêm nhân viên thành công!";
                return RedirectToAction(nameof(Index));
            }

            TempData["ThatBai"] = "Thêm nhân viên thất bại! Vui lòng kiểm tra lại thông tin.";
            return View(nhanVienModel);
        }

        // GET: Admin/NhanVienAdmin/SuaNhanVien/5
        public async Task<IActionResult> SuaNhanVien(int id)
        {
            var nhanVienModel = await _dataContext.NGUOI_DUNGs.AsNoTracking().FirstOrDefaultAsync(n => n.ID_NGUOI_DUNG == id);
            if (nhanVienModel == null)
            {
                TempData["ThatBai"] = "Không tìm thấy nhân viên.";
                return RedirectToAction(nameof(Index));
            }
            return View(nhanVienModel);
        }

        // POST: Admin/NhanVienAdmin/SuaNhanVien/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SuaNhanVien(int id, NguoiDungModel model)
        {
            if (ModelState.IsValid)
            {
                var nhanVien = await _dataContext.NGUOI_DUNGs.FindAsync(id);
                if (nhanVien == null)
                {
                    TempData["ThatBai"] = "Không tìm thấy nhân viên.";
                    return RedirectToAction(nameof(Index));
                }

                // Update properties
                nhanVien.HO_TEN = model.HO_TEN;
                nhanVien.EMAIL = model.EMAIL;
                nhanVien.SDT = model.SDT;
                nhanVien.VAI_TRO = model.VAI_TRO;
                nhanVien.TRANG_THAI = model.TRANG_THAI;

                await _dataContext.SaveChangesAsync();

                TempData["ThanhCong"] = "Cập nhật nhân viên thành công!";
                return RedirectToAction(nameof(Index));
            }

            TempData["ThatBai"] = "Cập nhật nhân viên thất bại! Vui lòng kiểm tra lại thông tin.";
            return View(model);
        }

        // GET: Admin/NhanVienAdmin/XoaNhanVien/5
        public async Task<IActionResult> XoaNhanVien(int id)
        {
            var nhanVienModel = await _dataContext.NGUOI_DUNGs.AsNoTracking().FirstOrDefaultAsync(n => n.ID_NGUOI_DUNG == id);
            if (nhanVienModel == null)
            {
                TempData["ThatBai"] = "Nhân viên không tồn tại.";
                return RedirectToAction(nameof(Index));
            }
            return View(nhanVienModel);
        }

        // POST: Admin/NhanVienAdmin/XoaNhanVien/5
        [HttpPost, ActionName("XoaNhanVien")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> XoaNhanVienConfirmed(int id)
        {
            var nhanVienModel = await _dataContext.NGUOI_DUNGs.FindAsync(id);
            if (nhanVienModel != null)
            {
                _dataContext.NGUOI_DUNGs.Remove(nhanVienModel);
                await _dataContext.SaveChangesAsync();
                TempData["ThanhCong"] = "Xóa nhân viên thành công!";
            }
            else
            {
                TempData["ThatBai"] = "Nhân viên không tồn tại.";
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
