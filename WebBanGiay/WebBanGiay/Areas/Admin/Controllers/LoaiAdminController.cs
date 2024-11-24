using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using WebBanGiay.Models;
using WebBanGiay.Repositoty;
using WebBanGiay.ViewModels;


namespace WebBanGiay.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class LoaiAdminController : Controller
    {
        private readonly DataContext _dataContext;

        public LoaiAdminController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<IActionResult> Index()
        {
            var loaiSanPhams = await _dataContext.LOAI_SAN_PHAMs.ToListAsync();

            var viewModel = new LoaiSanPhamViewModel
            {
                LoaiSanPhams = loaiSanPhams,
                LoaiSanPham = new LoaiSanPhamModel()
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ThemLoai(LoaiSanPhamModel loaiSanPham)
        {
            if (ModelState.IsValid)
            {
                _dataContext.Add(loaiSanPham);
                await _dataContext.SaveChangesAsync();
                TempData["ThanhCong"] = "Thêm loại sản phẩm thành công";
                return RedirectToAction(nameof(Index));
            }

            TempData["ThatBai"] = "Thêm loại sản phẩm thất bại";
            return View("Index", loaiSanPham);
        }

        public async Task<IActionResult> SuaLoai(int id)
        {
            LoaiSanPhamModel loaiSanPham = await _dataContext.LOAI_SAN_PHAMs.FirstOrDefaultAsync(sp => sp.ID_LOAI == id);

            return View(loaiSanPham);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SuaLoai(int id, LoaiSanPhamModel loaiSanPham)
        {
            if (ModelState.IsValid)
            {
                var existingLoai = await _dataContext.LOAI_SAN_PHAMs.FirstOrDefaultAsync(sp => sp.ID_LOAI == id);
                if (existingLoai == null)
                {
                    return NotFound();
                }

                existingLoai.TEN_LOAI = loaiSanPham.TEN_LOAI;

                _dataContext.Update(existingLoai);
                await _dataContext.SaveChangesAsync();
                TempData["ThanhCong"] = "Chỉnh sửa loại sản phẩm thành công";

                return RedirectToAction(nameof(Index));
            }

            TempData["ThatBai"] = "Sửa loại sản phẩm thất bại";
            return RedirectToAction(nameof(Index));
        }




        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> XoaLoai(int id)
        {
            var loaiSanPham = await _dataContext.LOAI_SAN_PHAMs.FindAsync(id);
            if (loaiSanPham == null)
            {
                TempData["ThatBai"] = "Không tìm thấy loại sản phẩm để xóa";
                return RedirectToAction(nameof(Index));
            }

            var sanPhams = await _dataContext.SAN_PHAMs.Where(sp => sp.ID_LOAI == loaiSanPham.ID_LOAI).ToListAsync();
            if (sanPhams.Any())
            {
                TempData["ThatBai"] = "Không thể xóa loại sản phẩm này vì còn sản phẩm thuộc loại này";
                return RedirectToAction(nameof(Index));
            }

            _dataContext.LOAI_SAN_PHAMs.Remove(loaiSanPham);
            await _dataContext.SaveChangesAsync();
            TempData["ThanhCong"] = "Xóa loại sản phẩm thành công";

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> GetLoaiSanPham(int id)
        {
            var loaiSanPham = await _dataContext.LOAI_SAN_PHAMs
                .Where(sp => sp.ID_LOAI == id)
                .Select(sp => new
                {
                    id = sp.ID_LOAI,
                    tenLoaiSanPham = sp.TEN_LOAI
                })
                .FirstOrDefaultAsync();

            if (loaiSanPham == null)
            {
                return NotFound();
            }

            return Json(loaiSanPham);
        }


    }
}
