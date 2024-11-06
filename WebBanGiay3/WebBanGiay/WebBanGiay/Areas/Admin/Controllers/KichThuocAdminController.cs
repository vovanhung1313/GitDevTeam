using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebBanGiay.Models;
using WebBanGiay.Repositoty;
using WebBanGiay.ViewModels;

namespace WebBanGiay.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class KichThuocAdminController : Controller
    {
        private readonly DataContext _dataContext;

        public KichThuocAdminController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }


        public async Task<IActionResult> Index()
        {
            var KichThuocList = await _dataContext.KICH_THUOCs.ToListAsync();
            var viewModel = new KichThuocSanPhamViewModel
            {
                DanhSachKichThuoc = KichThuocList,
                KichThuoc = new KichThuocSanPhamModel()
            };
            return View(viewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ThemKichThuoc(KichThuocSanPhamModel kichThuoc)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _dataContext.KICH_THUOCs.AddAsync(kichThuoc);
                    await _dataContext.SaveChangesAsync();
                    TempData["ThanhCong"] = "Thêm kích thước thành công.";
                }
                catch
                {
                    TempData["ThatBai"] = "Lỗi khi thêm kích thước.";
                }
                return RedirectToAction(nameof(Index));
            }

            TempData["ThatBai"] = "Thêm kích thước thất bại. Vui lòng kiểm tra dữ liệu đầu vào.";
            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> SuaKichThuoc(int id)
        {
            var kichThuoc = await _dataContext.KICH_THUOCs.FindAsync(id);
            if (kichThuoc == null)
            {
                TempData["ThatBai"] = "Không tìm thấy kích thước.";
                return RedirectToAction(nameof(Index));
            }

            return View(kichThuoc);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SuaKichThuoc(int id, KichThuocSanPhamModel kichThuoc)
        {
            if (id != kichThuoc.ID_KICH_THUOC)
            {
                TempData["ThatBai"] = "ID kích thước không hợp lệ.";
                return RedirectToAction(nameof(Index));
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var existingKichThuoc = await _dataContext.KICH_THUOCs.FirstOrDefaultAsync(sp => sp.ID_KICH_THUOC == id);
                    if (existingKichThuoc == null)
                    {
                        TempData["ThatBai"] = "Không tìm thấy kích thước.";
                        return RedirectToAction(nameof(Index));
                    }

                    existingKichThuoc.TEN_KICH_THUOC = kichThuoc.TEN_KICH_THUOC;
                    await _dataContext.SaveChangesAsync();
                    TempData["ThanhCong"] = "Cập nhật kích thước thành công.";
                }
                catch
                {
                    TempData["ThatBai"] = "Lỗi khi cập nhật kích thước.";
                }

                return RedirectToAction(nameof(Index));
            }

            TempData["ThatBai"] = "Cập nhật kích thước thất bại. Vui lòng kiểm tra dữ liệu đầu vào.";
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> XoaKichThuoc(int id)
        {
            try
            {
                var kichThuoc = await _dataContext.KICH_THUOCs.FindAsync(id);
                if (kichThuoc == null)
                {
                    TempData["ThatBai"] = "Không tìm thấy kích thước cần xóa.";
                    return RedirectToAction(nameof(Index));
                }

                _dataContext.KICH_THUOCs.Remove(kichThuoc);
                await _dataContext.SaveChangesAsync();
                TempData["ThanhCong"] = "Xóa kích thước thành công.";
            }
            catch
            {
                TempData["ThatBai"] = "Lỗi khi xóa kích thước.";
            }

            return RedirectToAction(nameof(Index));
        }


        [HttpPost]
        public async Task<JsonResult> KiemTraTrungLap(int tenKichThuoc)
        {
            var isDuplicate = await _dataContext.KICH_THUOCs.AnyAsync(k => k.TEN_KICH_THUOC == tenKichThuoc);
            return Json(!isDuplicate);  
        }
    }
}
