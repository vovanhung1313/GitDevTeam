using Microsoft.AspNetCore.Mvc;
using WebBanGiay.Models;
using WebBanGiay.Repository; // Chỉnh sửa từ Repositoty thành Repository
using X.PagedList;
using System.Linq;
using WebBanGiay.Repositoty;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;

namespace WebBanGiay.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class NhanVienAdminController : Controller
    {
        private readonly DataContext _db;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public NhanVienAdminController(DataContext db, IWebHostEnvironment webHostEnvironment)
        {
            _db = db;
            _webHostEnvironment = webHostEnvironment;
        }

        // Phương thức hiển thị danh sách nhân viên
        public IActionResult Index(string searchString, int? page)
        {
            int pageSize = 10;
            int pageNumber = page ?? 1;

            var nhanVienQuery = _db.NGUOI_DUNGs.Where(nv => nv.VAI_TRO == 2);

            // Tìm kiếm nhân viên theo thông tin
            if (!string.IsNullOrEmpty(searchString))
            {
                searchString = searchString.ToLower();
                nhanVienQuery = nhanVienQuery.Where(nv =>
                    nv.TAI_KHOAN.ToLower().Contains(searchString) ||
                    nv.HO_TEN.ToLower().Contains(searchString) ||
                    nv.SDT.Contains(searchString) ||
                    nv.DIA_CHI.ToLower().Contains(searchString) ||
                    nv.EMAIL.ToLower().Contains(searchString)
                );
            }

            var nhanVienPaged = nhanVienQuery.OrderBy(nv => nv.ID_NGUOI_DUNG).ToPagedList(pageNumber, pageSize);

            return View(nhanVienPaged);
        }

        // Phương thức hiển thị trang thêm nhân viên
        public IActionResult ThemNhanVien()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ThemNhanVien(NguoiDungModel model)
        {
            if (ModelState.IsValid)
            {
                if (await _db.NGUOI_DUNGs.AnyAsync(m => m.TAI_KHOAN == model.TAI_KHOAN))
                {
                    TempData["ThatBai"] = "Tài khoản đã có người sử dụng.";
                    return View(model);
                }
                if (await _db.NGUOI_DUNGs.AnyAsync(m => m.SDT == model.SDT))
                {
                    TempData["ThatBai"] = "Số điện thoại đã có người sử dụng.";
                    return View(model);
                }
                if (await _db.NGUOI_DUNGs.AnyAsync(m => m.EMAIL == model.EMAIL))
                {
                    TempData["ThatBai"] = "Email đã có người sử dụng.";
                    return View(model);
                }

                // Đặt vai trò cho nhân viên
                model.HINH_ANH = "User_images.jpg"; // Chắc chắn rằng bạn muốn sử dụng giá trị mặc định này
                model.VAI_TRO = 2;
                model.NGAY_TAO = DateTime.Now;
                model.TRANG_THAI = 0;

                _db.NGUOI_DUNGs.Add(model);
                await _db.SaveChangesAsync(); // Lưu thay đổi một cách bất đồng bộ
                TempData["ThanhCong"] = "Thêm nhân viên thành công!";
                return RedirectToAction("Index");
            }
            return View(model);
        }


        // GET: NhanVienAdmin/SuaNguoiDung/5
        public IActionResult SuaNhanVien(int id)
        {
            var nguoiDung = _db.NGUOI_DUNGs.Find(id); // Lấy thông tin nhân viên theo ID
            if (nguoiDung == null)
            {
                return NotFound();
            }
            return View(nguoiDung);
        }

        // POST: NhanVienAdmin/SuaNguoiDung
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SuaNhanVien(NguoiDungModel model)
        {
            if (ModelState.IsValid)
            {
                // Kiểm tra nếu có tài khoản, số điện thoại hoặc email khác đã tồn tại
                if (await _db.NGUOI_DUNGs.AnyAsync(m => m.TAI_KHOAN == model.TAI_KHOAN && m.ID_NGUOI_DUNG != model.ID_NGUOI_DUNG))
                {
                    TempData["ThatBai"] = "Tài khoản đã có người sử dụng.";
                    return View(model);
                }
                if (await _db.NGUOI_DUNGs.AnyAsync(m => m.SDT == model.SDT && m.ID_NGUOI_DUNG != model.ID_NGUOI_DUNG))
                {
                    TempData["ThatBai"] = "Số điện thoại đã có người sử dụng.";
                    return View(model);
                }
                if (await _db.NGUOI_DUNGs.AnyAsync(m => m.EMAIL == model.EMAIL && m.ID_NGUOI_DUNG != model.ID_NGUOI_DUNG))
                {
                    TempData["ThatBai"] = "Email đã có người sử dụng.";
                    return View(model);
                }

                // Cập nhật thông tin nhân viên
                _db.NGUOI_DUNGs.Update(model);
                await _db.SaveChangesAsync(); // Lưu thay đổi một cách bất đồng bộ
                TempData["ThanhCong"] = "Cập nhật thông tin nhân viên thành công!";
                return RedirectToAction(nameof(Index)); // Quay lại danh sách nhân viên
            }
            return View(model);
        }

        // Phương thức xóa nhân viên
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult XoaNhanVien(int id)
        {
            var nhanVien = _db.NGUOI_DUNGs.FirstOrDefault(nv => nv.ID_NGUOI_DUNG == id && nv.VAI_TRO == 2);
            if (nhanVien != null)
            {
                _db.NGUOI_DUNGs.Remove(nhanVien);
                _db.SaveChanges();
                TempData["ThanhCong"] = "Xóa nhân viên thành công!";
                return RedirectToAction("Index");
            }
            TempData["ThatBai"] = "Nhân viên không tồn tại.";
            return RedirectToAction("Index");
        }
    }
}
