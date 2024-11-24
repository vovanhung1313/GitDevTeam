using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using WebBanGiay.Models;
using WebBanGiay.Repositoty;

namespace WebBanGiay.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ThongKeAdminController : Controller
    {
        private readonly DataContext _dataContext;

        public ThongKeAdminController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        // Trang chính cho thống kê
        public IActionResult ThongKe()
        {
            return View();
        }

        // Thống kê theo ngày
        public IActionResult GetDailyStatistics(DateTime date)
        {
            var orderDetails = _dataContext.DON_HANGs
                .Where(o => o.TRANG_THAI_DH == 2 && o.NGAY_DAT.Date == date.Date)
                .SelectMany(o => o.CHI_TIET_DON_HANG, (order, detail) => new
                {
                    order.NGAY_DAT,
                    detail.THANH_TIEN
                })
                .ToList();

            var statistics = orderDetails
                .GroupBy(o => o.NGAY_DAT.Date)
                .Select(g => new ThongKeModel
                {
                    Date = g.Key,
                    TotalOrders = g.Select(o => o.NGAY_DAT).Distinct().Count(),
                    TotalRevenue = g.Sum(x => (decimal?)x.THANH_TIEN ?? 0)
                })
                .ToList();

            return Json(statistics);
        }

        // Thống kê theo tháng
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

        // Thống kê theo năm
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
    }
}
