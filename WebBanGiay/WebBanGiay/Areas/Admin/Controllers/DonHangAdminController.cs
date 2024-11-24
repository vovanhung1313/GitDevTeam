using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebBanGiay.Repository;
using System.Linq;
using System.Threading.Tasks;
using WebBanGiay.Repositoty;
using WebBanGiay.Models;

namespace WebBanGiay.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DonHangAdminController : Controller
    {
        private readonly DataContext _dataContext;

        public DonHangAdminController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<IActionResult> DonHang()
        {
            var donHang = await _dataContext.DON_HANGs
                                            .Include(dh => dh.NGUOI_DUNG)
                                            .Include(cc => cc.CHI_TIET_DON_HANG)
                                            .ThenInclude(sp => sp.SAN_PHAM)
                                            .ToListAsync();

            ViewBag.ChoDuyet = donHang.Where(d => d.TRANG_THAI_DH == 0).ToList();
            ViewBag.DangGiao = donHang.Where(d => d.TRANG_THAI_DH == 1).ToList();
            ViewBag.HoanThanh = donHang.Where(d => d.TRANG_THAI_DH == 2).ToList();
            return View(donHang);
        }

        [HttpPost]
        public async Task<IActionResult> DuyetDon(int id)
        {
            var NhanVien = HttpContext.Session.GetJson<NguoiDungModel>("User");

            var donHang = await _dataContext.DON_HANGs.FindAsync(id);
            if (donHang != null)
            {
                donHang.ID_NHAN_VIEN = NhanVien.ID_NGUOI_DUNG;
                donHang.TRANG_THAI_DH = 1;
                _dataContext.DON_HANGs.Update(donHang);
                await _dataContext.SaveChangesAsync();
                TempData["ThanhCong"] = "Duyệt đơn hàng thành công";


            }

            return RedirectToAction("DonHang");

        }

        [HttpPost]
        public async Task<IActionResult> HoanThanh(int id)
        {
            var donHang = await _dataContext.DON_HANGs.FindAsync(id);
            if (donHang != null)
            {
                donHang.TRANG_THAI_DH = 2;
                donHang.TRANG_THAI_THANH_TOAN = "Đã thanh toán";
                donHang.NGAY_GIAO = DateTime.Now;
                _dataContext.DON_HANGs.Update(donHang);
                await _dataContext.SaveChangesAsync();
                TempData["ThanhCong"] = "Duyệt đơn hàng thành công";


            }

            return RedirectToAction("DonHang");

        }

        [HttpPost]
        public async Task<IActionResult> HuyDon(int id, string LyDoHuy)
        {
            var NhanVien = HttpContext.Session.GetJson<NguoiDungModel>("User");
            var donHang = await _dataContext.DON_HANGs.FindAsync(id);
            if (donHang != null)
            {
                donHang.ID_NHAN_VIEN = NhanVien.ID_NGUOI_DUNG;
                donHang.TRANG_THAI_THANH_TOAN = "Chưa thanh toán";
                donHang.LY_DO_HUY = LyDoHuy;
                donHang.TRANG_THAI_DH = 3;
                _dataContext.Update(donHang);
                await _dataContext.SaveChangesAsync();

                TempData["ThanhCong"] = "Hủy đơn hàng thành công";
            }
            return RedirectToAction("DonHang");
        }


        public async Task<IActionResult> ChiTiet(int id)
        {
            var donHang = await _dataContext.DON_HANGs
                                .Include(dh => dh.CHI_TIET_DON_HANG)
                                    .ThenInclude(ct => ct.SAN_PHAM)
                                .Include(dh => dh.NGUOI_DUNG)
                                .FirstOrDefaultAsync(dh => dh.ID_DON_HANG == id);

            if (donHang == null)
            {
                return NotFound();
            }

            var chiTietDonHang = donHang.CHI_TIET_DON_HANG.Select(ct => new
            {
                tenSanPham = ct.SAN_PHAM.TEN_SAN_PHAM,
                soLuong = ct.SO_LUONG,
                giaBan = ct.GIA_BAN,
                mauSP = ct.MauSanPham,
                thanhTien = ct.THANH_TIEN
            }).ToList();

            var nguoiDung = new
            {
                tenNguoiNhan = donHang.TEN_NGUOI_NHAN,
                diaChi = donHang.DIACHI,
                soDienThoai = donHang.NGUOI_DUNG.SDT,
                tenNguoiDat = donHang.NGUOI_DUNG.HO_TEN
            };

            var response = new
            {
                chiTietDonHang = chiTietDonHang,
                nguoiDung = nguoiDung,
                ngayDat = donHang.NGAY_DAT.ToString("dd/MM/yyyy"),
                trangThaiDonHang = donHang.TRANG_THAI_DH == 0 ? "Đang xử lý" : donHang.TRANG_THAI_DH == 1 ? "Đang giao" : "Hoàn thành",
                trangThaiThanhToan = donHang.TRANG_THAI_THANH_TOAN,
                hinhThucThanhToan = donHang.HinhThucThanhToan
            };

            return Json(response);
        }




    }
}
