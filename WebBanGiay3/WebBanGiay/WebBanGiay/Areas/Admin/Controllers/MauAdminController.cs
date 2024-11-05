using Microsoft.AspNetCore.Mvc;
using WebBanGiay.Models;  // Namespace chứa lớp MauSanPhamModel
using WebBanGiay.Repository;  // Namespace chứa DbContext
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebBanGiay.ViewModels;
using WebBanGiay.Repositoty;

namespace WebBanGiay.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MauAdminController : Controller
    {
        private readonly DataContext _dataContext;

        public MauAdminController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        // GET: Admin/MauAdmin
        public IActionResult Index()
        {
            // Lấy danh sách màu từ cơ sở dữ liệu
            var danhSachMau = _dataContext.MauSanPhamModels.ToList();  // Đảm bảo rằng MauSanPhamModels là DbSet trong DataContext
            var viewModel = new MauSanPhamViewModel
            {
                DanhSachMau = danhSachMau
            };
            return View(viewModel);
        }

        // GET: Admin/MauAdmin/ThemMau
        public IActionResult ThemMau()
        {
            return View();
        }

        // POST: Admin/MauAdmin/ThemMau
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ThemMau(MauSanPhamModel mau)
        {
            if (ModelState.IsValid)
            {
                // Thêm màu mới vào cơ sở dữ liệu
                _dataContext.Add(mau);
                await _dataContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));  // Điều hướng về danh sách màu sau khi thêm thành công
            }
            return View(mau);  // Nếu không hợp lệ, hiển thị lại form thêm màu
        }

        // GET: Admin/MauAdmin/SuaMau/{id}
        public IActionResult SuaMau(int id)
        {
            // Lấy màu sản phẩm từ cơ sở dữ liệu
            var mau = _dataContext.MauSanPhamModels.FirstOrDefault(m => m.ID_MAU == id);
            if (mau == null)
            {
                return NotFound();  // Nếu không tìm thấy màu, trả về lỗi 404
            }
            return View(mau);
        }

        // POST: Admin/MauAdmin/SuaMau/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SuaMau(int id, MauSanPhamModel mau)
        {
            if (id != mau.ID_MAU)
            {
                return NotFound();  // Nếu ID không khớp, trả về lỗi
            }

            if (ModelState.IsValid)
            {
                try
                {
                    // Cập nhật thông tin màu trong cơ sở dữ liệu
                    _dataContext.Update(mau);
                    await _dataContext.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_dataContext.MauSanPhamModels.Any(e => e.ID_MAU == mau.ID_MAU))
                    {
                        return NotFound();  // Nếu không tìm thấy màu trong cơ sở dữ liệu
                    }
                    else
                    {
                        throw;  // Nếu có lỗi khác, ném lại ngoại lệ
                    }
                }
                return RedirectToAction(nameof(Index));  // Điều hướng về danh sách màu sau khi cập nhật
            }
            return View(mau);  // Nếu không hợp lệ, hiển thị lại form sửa màu
        }

        // POST: Admin/MauAdmin/XoaMau
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> XoaMau(int id)
        {
            var mau = await _dataContext.MauSanPhamModels.FindAsync(id);
            if (mau == null)
            {
                return NotFound();  // Nếu không tìm thấy màu trong cơ sở dữ liệu
            }

            _dataContext.MauSanPhamModels.Remove(mau);  // Xóa màu
            await _dataContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));  // Điều hướng về danh sách màu sau khi xóa
        }
    }
}
