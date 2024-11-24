using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebBanGiay.Models;
using WebBanGiay.Repository;
using System.Linq;
using System.Threading.Tasks;
using System.Globalization;
using Microsoft.AspNetCore.Antiforgery;
using WebBanGiay.Repositoty;

namespace WebBanGiay.Controllers
{
    public class GioHangController : Controller
    {
        private readonly DataContext _dataContext;
        private readonly IAntiforgery _antiforgery;

        public GioHangController(DataContext dataContext, IAntiforgery antiforgery)
        {
            _dataContext = dataContext;
            _antiforgery = antiforgery;
        }

        public async Task<IActionResult> Index()
        {
            var khachHang = HttpContext.Session.GetJson<NguoiDungModel>("User");

            var tokens = _antiforgery.GetAndStoreTokens(HttpContext);
            ViewBag.AntiforgeryToken = tokens.RequestToken;

            if (khachHang == null)
            {
                return RedirectToAction("DangNhap", "NguoiDung");
            }

            var gioHang = await _dataContext.GIO_HANGs
                                            .Include(gh => gh.SAN_PHAM)
                                            .ThenInclude(sp => sp.HINH_ANH)
                                            .Where(gh => gh.ID_NGUOI_DUNG == khachHang.ID_NGUOI_DUNG)
                                            .ToListAsync();

            decimal tongTien = gioHang.Sum(gh => gh.THANH_TIEN);

            ViewBag.TongTien = tongTien;
            ViewBag.tenKH = khachHang.HO_TEN;

            return View(gioHang);
        }

        [HttpGet]
        public async Task<IActionResult> LaySoLuongSanPham(int idSanPham, int idMau)
        {
            var sanPham = await _dataContext.SAN_PHAMs
                                            .Where(sp => sp.ID_SAN_PHAM == idSanPham)
                                            .FirstOrDefaultAsync();

            if (sanPham == null)
            {
                return Json(new { success = false, soLuong = 0 });
            }

            return Json(new { success = true, soLuong = sanPham.SO_LUONG });
        }

        [HttpPost]
        public async Task<IActionResult> ThemGioHang(int ID_SAN_PHAM, int SoLuong, string Mau)
        {
            var khachHang = HttpContext.Session.GetJson<NguoiDungModel>("User");
            if (khachHang == null)
            {
                return RedirectToAction("DangNhap", "NguoiDung");
            }

            var sanPham = await _dataContext.SAN_PHAMs
                                            .Where(sp => sp.ID_SAN_PHAM == ID_SAN_PHAM)
                                            .FirstOrDefaultAsync();

            if (sanPham == null)
            {
                TempData["ThatBai"] = "Vui lòng chọn một sản phẩm hợp lệ";
                return NotFound();
            }

            var gioHangItem = await _dataContext.GIO_HANGs
                                                .Where(gh => gh.ID_SAN_PHAM == ID_SAN_PHAM && gh.MAU_SP == Mau && gh.ID_NGUOI_DUNG == khachHang.ID_NGUOI_DUNG)
                                                .FirstOrDefaultAsync();

            if (gioHangItem != null)
            {
                gioHangItem.SO_LUONG_GH += SoLuong;
                gioHangItem.THANH_TIEN += sanPham.GIA_BAN * SoLuong;
            }
            else
            {
                var gioHang = new GioHangModel
                {
                    ID_NGUOI_DUNG = khachHang.ID_NGUOI_DUNG,
                    ID_SAN_PHAM = sanPham.ID_SAN_PHAM,
                    SO_LUONG_GH = SoLuong,
                    GIA_BAN = sanPham.GIA_BAN,
                    THANH_TIEN = sanPham.GIA_BAN * SoLuong,
                    MAU_SP = Mau
                };

                _dataContext.GIO_HANGs.Add(gioHang);
            }

            sanPham.SO_LUONG -= SoLuong;
            await _dataContext.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> XoaKhoiGioHang(int maGH)
        {
            var khachHang = HttpContext.Session.GetJson<NguoiDungModel>("User");
            if (khachHang == null)
            {
                return Unauthorized();
            }

            var gioHang = await _dataContext.GIO_HANGs.FirstOrDefaultAsync(gh => gh.ID_GIO_HANG == maGH && gh.ID_NGUOI_DUNG == khachHang.ID_NGUOI_DUNG);
            if (gioHang == null)
            {
                return NotFound();
            }

            var sanPham = await _dataContext.SAN_PHAMs.FindAsync(gioHang.ID_SAN_PHAM);
            if (sanPham == null)
            {
                return NotFound();
            }

            sanPham.SO_LUONG += gioHang.SO_LUONG_GH;

            _dataContext.Update(sanPham);

            _dataContext.GIO_HANGs.Remove(gioHang);
            await _dataContext.SaveChangesAsync();

            TempData["ThanhCong"] = "Xóa khỏi giỏ hàng thành công";
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> CapNhatSoLuong(int idGioHang, int soLuong)
        {
            var khachHang = HttpContext.Session.GetJson<NguoiDungModel>("User");
            if (khachHang == null)
            {
                return Json(new { success = false });
            }

            var gioHang = await _dataContext.GIO_HANGs.FirstOrDefaultAsync(gh => gh.ID_GIO_HANG == idGioHang && gh.ID_NGUOI_DUNG == khachHang.ID_NGUOI_DUNG);
            if (gioHang == null)
            {
                return Json(new { success = false });
            }

            var sanPham = await _dataContext.SAN_PHAMs.FindAsync(gioHang.ID_SAN_PHAM);
            if (sanPham == null)
            {
                return Json(new { success = false });
            }

            var oldQuantity = gioHang.SO_LUONG_GH;
            if (soLuong > sanPham.SO_LUONG + oldQuantity)
            {
                return Json(new { success = false, message = "Số lượng sản phẩm không đủ" });
            }

            gioHang.SO_LUONG_GH = soLuong;
            gioHang.THANH_TIEN = gioHang.GIA_BAN * soLuong;

            sanPham.SO_LUONG += oldQuantity - soLuong;

            _dataContext.Update(gioHang);
            _dataContext.Update(sanPham);
            await _dataContext.SaveChangesAsync();

            var tongTien = await _dataContext.GIO_HANGs
                                             .Where(gh => gh.ID_NGUOI_DUNG == khachHang.ID_NGUOI_DUNG)
                                             .SumAsync(gh => gh.THANH_TIEN);

            return Json(new
            {
                success = true,
                thanhTien = gioHang.THANH_TIEN.ToString("N0", CultureInfo.InvariantCulture).Replace(",", "."),
                tongTien = tongTien.ToString("N0", CultureInfo.InvariantCulture).Replace(",", ".")
            });
        }
    }
}
