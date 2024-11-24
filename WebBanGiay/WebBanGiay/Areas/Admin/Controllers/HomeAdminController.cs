using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebBanGiay.Models;
using WebBanGiay.Repository;
using WebBanGiay.Repositoty;

namespace WebBanGiay.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin")]
    [Route("Admin/HomeAdmin")]
    public class HomeAdminController : Controller
    {
        private readonly DataContext _dataContext;

        public HomeAdminController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [Route("")]
        [Route("Index")]
        // Trang chính cho thống kê
        public IActionResult Index()
        {
            return View();
        }

        // Thống kê doanh thu và đơn hàng hôm nay
        public IActionResult GetTodayStatistics()
        {
            var today = DateTime.Today;
            var orderDetails = _dataContext.DON_HANGs
                .Where(o => o.TRANG_THAI_DH == 2 && o.NGAY_DAT.Date == today)
                .SelectMany(o => o.CHI_TIET_DON_HANG, (order, detail) => new
                {
                    order.NGAY_DAT,
                    detail.THANH_TIEN
                })
                .ToList();

            var totalOrdersToday = orderDetails.Select(o => o.NGAY_DAT).Distinct().Count();
            var totalRevenueToday = orderDetails.Sum(x => (decimal?)x.THANH_TIEN ?? 0);

            return Json(new
            {
                TotalOrdersToday = totalOrdersToday,
                TotalRevenueToday = totalRevenueToday
            });
        }

        // Thống kê doanh thu và đơn hàng theo tháng
        public IActionResult GetMonthlyStatistics(int year, int month)
        {
            var orderDetails = _dataContext.DON_HANGs
                .Where(o => o.TRANG_THAI_DH == 2 && o.NGAY_DAT.Year == year && o.NGAY_DAT.Month == month)
                .SelectMany(o => o.CHI_TIET_DON_HANG, (order, detail) => new
                {
                    order.NGAY_DAT,
                    detail.THANH_TIEN
                })
                .ToList();

            var statistics = orderDetails
                .GroupBy(o => new { o.NGAY_DAT.Year, o.NGAY_DAT.Month })
                .Select(g => new ThongKeModel
                {
                    Date = new DateTime(g.Key.Year, g.Key.Month, 1),
                    TotalOrders = g.Select(o => o.NGAY_DAT).Distinct().Count(),
                    TotalRevenue = g.Sum(x => (decimal?)x.THANH_TIEN ?? 0)
                })
                .ToList();

            return Json(statistics);
        }

        // Thống kê doanh thu và đơn hàng theo năm
        public IActionResult GetYearlyStatistics(int year)
        {
            var orderDetails = _dataContext.DON_HANGs
                .Where(o => o.TRANG_THAI_DH == 2 && o.NGAY_DAT.Year == year)
                .SelectMany(o => o.CHI_TIET_DON_HANG, (order, detail) => new
                {
                    order.NGAY_DAT,
                    detail.THANH_TIEN
                })
                .ToList();

            var statistics = orderDetails
                .GroupBy(o => o.NGAY_DAT.Year)
                .Select(g => new ThongKeModel
                {
                    Date = new DateTime(g.Key, 1, 1),
                    TotalOrders = g.Select(o => o.NGAY_DAT).Distinct().Count(),
                    TotalRevenue = g.Sum(x => (decimal?)x.THANH_TIEN ?? 0)
                })
                .ToList();

            return Json(statistics);
        }

        // Chi tiết đơn hàng
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
    }
}
