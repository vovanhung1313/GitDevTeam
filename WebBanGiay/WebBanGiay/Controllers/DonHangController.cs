using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebBanGiay.Models;
using System.Linq;
using System.Threading.Tasks;
using WebBanGiay.Repositoty;
using WebBanGiay.Repository;
using WebBanGiay.Services;
using WebBanGiay.ViewModels;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace WebBanGiay.Controllers
{
    public class DonHangController : Controller
    {
        private readonly DataContext _dataContext;
        private readonly IVnPayService _vnPayService;
        private readonly EmailService _emailService;

        public DonHangController(DataContext dataContext, IVnPayService vnPayService, EmailService emailService)
        {
            _dataContext = dataContext;
            _vnPayService = vnPayService;
            _emailService = emailService;
        }
        private int GetCurrentUserId()
        {
            var user = HttpContext.Session.GetJson<NguoiDungModel>("User");
            return user?.ID_NGUOI_DUNG ?? 0; // Return 0 if user is null
        }
        public async Task<IActionResult> DatHang()
        {
            var khachHang = HttpContext.Session.GetJson<NguoiDungModel>("User");
            if (khachHang == null)
            {
                return RedirectToAction("DangNhap", "KhachHang");
            }

            var gioHang = await _dataContext.GIO_HANGs
                                            .Include(gh => gh.SAN_PHAM)
                                            .ThenInclude(sp => sp.HINH_ANH)
                                            .Where(gh => gh.ID_NGUOI_DUNG == khachHang.ID_NGUOI_DUNG)
                                            .ToListAsync();

            if (gioHang == null || gioHang.Count == 0)
            {
                TempData["ThatBai"] = "Giỏ hàng đang trống hãy thêm sản phẩm vào giỏ hàng trước";
                return RedirectToAction("Index", "GioHang");
            }

            ViewBag.GioHang = gioHang;
            ViewBag.TongTien = gioHang.Sum(gh => gh.THANH_TIEN);

            return View(khachHang);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DatHang(string diaChiGiaoHang, string HoVaTen, string SoDienThoai, string hinhThucThanhToan)
        {
            var khachHang = HttpContext.Session.GetJson<NguoiDungModel>("User");
            if (khachHang == null)
            {
                return RedirectToAction("DangNhap", "KhachHang");
            }

            if (hinhThucThanhToan == null)
            {
                TempData["ThatBai"] = "Vui lòng chọn 1 hình thức thanh toán";
            }
            if (hinhThucThanhToan == "COD")
            {


                var gioHang = await _dataContext.GIO_HANGs
                                                .Include(gh => gh.SAN_PHAM)

                                                .Where(gh => gh.ID_NGUOI_DUNG == khachHang.ID_NGUOI_DUNG)
                                                .ToListAsync();



                if (gioHang == null || gioHang.Count == 0)
                {
                    TempData["ThaiBai"] = "Giỏ hàng trống.";
                    return RedirectToAction("GioHang", "GioHang");
                }

                var donHang = new DonHangModel
                {
                    ID_NGUOI_DUNG = khachHang.ID_NGUOI_DUNG,
                    DIACHI = diaChiGiaoHang,
                    TEN_NGUOI_NHAN = HoVaTen,
                    HinhThucThanhToan = hinhThucThanhToan,
                    NGAY_DAT = DateTime.Now

                };



                _dataContext.DON_HANGs.Add(donHang);
                await _dataContext.SaveChangesAsync();

                foreach (var item in gioHang)
                {
                    var chiTietDonHang = new ChiTietDonHangModel
                    {
                        ID_DON_HANG = donHang.ID_DON_HANG,
                        ID_SAN_PHAM = item.ID_SAN_PHAM,

                        SO_LUONG = item.SO_LUONG_GH,
                        GIA_BAN = item.SAN_PHAM.GIA_BAN,
                        MauSanPham = item.MAU_SP,
                        THANH_TIEN = item.THANH_TIEN
                    };

                    _dataContext.CHI_TIET_DON_HANGs.Add(chiTietDonHang);
                }

                await _dataContext.SaveChangesAsync();

                _dataContext.GIO_HANGs.RemoveRange(gioHang);
                await _dataContext.SaveChangesAsync();
             

                int id = donHang.ID_DON_HANG;

                var HoaDon = _dataContext.DON_HANGs
                    .Include(dh => dh.CHI_TIET_DON_HANG)
                        .ThenInclude(ct => ct.SAN_PHAM)
                    .Include(dh => dh.NGUOI_DUNG)
                    .FirstOrDefault(dh => dh.ID_DON_HANG == id);
                if (HoaDon == null)
                {
                    return NotFound();
                }
                var invoiceHtml = $@"
                <h2>Hóa đơn</h2>
                <hr/>
                <p>Đơn hàng: {HoaDon.ID_DON_HANG}</p>
                <p>Tên khách hàng: {HoaDon.NGUOI_DUNG.HO_TEN}</p>
                <p>Ngày đặt hàng: {HoaDon.NGAY_DAT.ToString("dd/MM/yyyy")}</p>
                <p>Trạng thái đơn hàng: {(HoaDon.TRANG_THAI_DH == 0 ? "Đang xử lý" : "")}</p>
                <p>Trạng thái thanh toán: {(HoaDon.TRANG_THAI_THANH_TOAN)}</p>
                <p>Hình thức thanh toán: {(HoaDon.HinhThucThanhToan)}</p>
                <p><strong>Chi tiết đơn hàng:</strong></p>
                <ul>";

                foreach (var chiTiet in HoaDon.CHI_TIET_DON_HANG)
                {
                    invoiceHtml += $@"
                    <li>
                        Sản phẩm: {chiTiet.SAN_PHAM.TEN_SAN_PHAM} - Số lượng: {chiTiet.SO_LUONG} - Thành tiền: {chiTiet.THANH_TIEN.ToString("N0")} đ
                    </li>";
                }

                invoiceHtml += "</ul>";

                try
                {
                    _emailService.SendEmailAsync(HoaDon.NGUOI_DUNG.EMAIL, "TeamDev !!", invoiceHtml);
                    TempData["ThanhCong"] = "Gửi hóa đơn qua email thành công.";
                }
                catch (Exception ex)
                {
                    return BadRequest("Gửi hóa đơn qua email không thành công.");
                }
                TempData["ThanhCong"] = "Đặt hàng thành công.";
            }

            if (hinhThucThanhToan == "VNPay")
            {
                var gioHang = await _dataContext.GIO_HANGs
                                            .Include(gh => gh.SAN_PHAM)
                                            .Where(gh => gh.ID_NGUOI_DUNG == khachHang.ID_NGUOI_DUNG)
                                            .ToListAsync();

                if (gioHang == null || gioHang.Count == 0)
                {
                    TempData["ThatBai"] = "Giỏ hàng trống.";
                    return RedirectToAction("GioHang", "GioHang");
                }
                

                decimal TongTien = gioHang.Sum(th => th.THANH_TIEN);
                var donHang = new DonHangModel
                {
                    ID_NGUOI_DUNG = khachHang.ID_NGUOI_DUNG,
                    DIACHI = diaChiGiaoHang,
                    TEN_NGUOI_NHAN = HoVaTen,
                    TRANG_THAI_DH = 9,
                    HinhThucThanhToan = "VNPay",
                    NGAY_DAT = DateTime.Now
                };

                _dataContext.DON_HANGs.Add(donHang);
                _dataContext.SaveChanges();

              
                var vnPayModel = new VnPaymentRequestModel
                {
                    Amount = Convert.ToDouble(TongTien),
                    CreatedDate = DateTime.Now,
                    Description = $"{khachHang.SDT}",
                 
                    OrderId = donHang.ID_DON_HANG,
                    HoTen = HoVaTen,
                    ProductId = donHang.ID_DON_HANG
                };

                TempData["VNPayInfo"] = JsonConvert.SerializeObject(new { diaChiGiaoHang, HoVaTen, SoDienThoai, khachHang, gioHang, vnPayModel });

                return Redirect(_vnPayService.CreatePaymentUrl(HttpContext, vnPayModel));
            }



            return RedirectToAction("Index", "Home");
        }

        public IActionResult PaymentCallBack()
        {
            var response = _vnPayService.PaymentExecute(Request.Query);
            if (response == null || response.VnPayResponseCode != "00")
            {
                if (TempData["VNPayInfo"] != null)
                {
                    var vnPayInfoJson = TempData["VNPayInfo"].ToString();
                    var vnPayInfo = JsonConvert.DeserializeObject<dynamic>(vnPayInfoJson);

                    int? donHangId = (int?)vnPayInfo.donHangId;

                    if (donHangId.HasValue)
                    {
                        var donHang = _dataContext.DON_HANGs.Find(donHangId.Value);
                        if (donHang != null)
                        {
                            _dataContext.DON_HANGs.Remove(donHang);
                            _dataContext.SaveChanges();
                        }
                        else
                        {
                            TempData["ThatBai"] = "Đơn hàng không tồn tại.";
                        }
                    }
                }
                TempData["ThatBai"] = $"Hủy thanh toán VN Pay ";  //{response.VnPayResponseCode}
                return RedirectToAction("DatHang", "DonHang");
            }
            else
            {
                var vnPayInfo = JsonConvert.DeserializeObject<dynamic>(TempData["VNPayInfo"].ToString());
                var diaChiGiaoHang = (string)vnPayInfo.diaChiGiaoHang;
                var HoVaTen = (string)vnPayInfo.HoVaTen;
                var SoDienThoai = (string)vnPayInfo.SoDienThoai;
                var khachHang = (NguoiDungModel)vnPayInfo.khachHang.ToObject(typeof(NguoiDungModel));
                var gioHang = ((JArray)vnPayInfo.gioHang).ToObject<List<GioHangModel>>();

                var donHang = new DonHangModel
                {
                    ID_NGUOI_DUNG = khachHang.ID_NGUOI_DUNG,
                    DIACHI = diaChiGiaoHang,
                    TEN_NGUOI_NHAN = HoVaTen,
                    HinhThucThanhToan = "VNPay",
                    NGAY_DAT = DateTime.Now
                };

                _dataContext.DON_HANGs.Add(donHang);
                _dataContext.SaveChanges();

                foreach (var item in gioHang)
                {
                    var chiTietDonHang = new ChiTietDonHangModel
                    {
                        ID_DON_HANG = donHang.ID_DON_HANG,
                        ID_SAN_PHAM = item.ID_SAN_PHAM,
                        SO_LUONG = item.SO_LUONG_GH,
                        GIA_BAN = item.SAN_PHAM.GIA_BAN,
                        MauSanPham = item.MAU_SP,
                        THANH_TIEN = item.THANH_TIEN
                    };

                    _dataContext.CHI_TIET_DON_HANGs.Add(chiTietDonHang);
                }

                donHang.TRANG_THAI_THANH_TOAN = "Đã thanh toán";
                _dataContext.SaveChanges();

                _dataContext.GIO_HANGs.RemoveRange(gioHang);
                _dataContext.SaveChanges();

                int id = donHang.ID_DON_HANG;

                var HoaDon = _dataContext.DON_HANGs
                    .Include(dh => dh.CHI_TIET_DON_HANG)
                        .ThenInclude(ct => ct.SAN_PHAM)
                    .Include(dh => dh.NGUOI_DUNG)
                    .FirstOrDefault(dh => dh.ID_DON_HANG == id);
                if (HoaDon == null)
                {
                    return NotFound();
                }
                var invoiceHtml = $@"
                <h2>Hóa đơn</h2>
                <hr/>
                <p>Đơn hàng: {HoaDon.ID_DON_HANG}</p>
                <p>Tên khách hàng: {HoaDon.NGUOI_DUNG.HO_TEN}</p>
                <p>Ngày đặt hàng: {HoaDon.NGAY_DAT.ToString("dd/MM/yyyy")}</p>
                <p>Trạng thái đơn hàng: {(HoaDon.TRANG_THAI_DH == 0 ? "Đang xử lý" : "")}</p>
                <p>Trạng thái thanh toán: {(HoaDon.TRANG_THAI_THANH_TOAN)}</p>
                <p>Hình thức thanh toán: {(HoaDon.HinhThucThanhToan)}</p>
                <p><strong>Chi tiết đơn hàng:</strong></p>
                <ul>";

                foreach (var chiTiet in HoaDon.CHI_TIET_DON_HANG)
                {
                    invoiceHtml += $@"
            <li>
                Sản phẩm: {chiTiet.SAN_PHAM.TEN_SAN_PHAM} - Số lượng: {chiTiet.SO_LUONG} - Thành tiền: {chiTiet.THANH_TIEN.ToString("N0")} đ
            </li>";
                }

                invoiceHtml += "</ul>";

                try
                {
                    _emailService.SendEmailAsync(HoaDon.NGUOI_DUNG.EMAIL, "TeamDev", invoiceHtml);
                    TempData["ThanhCong"] = "Gửi hóa đơn qua email thành công.";
                }
                catch (Exception ex)
                {
                    return BadRequest("Gửi hóa đơn qua email không thành công.");
                }
                TempData["ThanhCong"] = "Đặt hàng VnPay thành công.";
            }

            return RedirectToAction("Index", "Home");
        }



        public IActionResult DonMua()       
        {
            var userId = GetCurrentUserId();
            var orders = _dataContext.DON_HANGs
                .Include(o => o.NGUOI_DUNG)
                .Include(o => o.NHAN_VIEN)
                .Include(o => o.CHI_TIET_DON_HANG)
                    .ThenInclude(ct => ct.SAN_PHAM)
                    .ThenInclude(sp => sp.HINH_ANH) // Include HinhAnh
                .Where(o => o.ID_NGUOI_DUNG == userId) // Filter by current user ID
                .ToList();

            // Group orders by their status
            ViewBag.AllOrders = orders;
            ViewBag.PendingOrders = orders.Where(o => o.TRANG_THAI_DH == 0).ToList(); // Chờ duyệt
            ViewBag.ShippingOrders = orders.Where(o => o.TRANG_THAI_DH == 1).ToList(); // Đang giao
            ViewBag.PaidOrders = orders.Where(o => o.TRANG_THAI_DH == 2).ToList(); // Đã giao
            ViewBag.CancelledOrders = orders.Where(o => o.TRANG_THAI_DH == 3).ToList(); // Đã hủy
            return View();
        }

        [HttpPost("CancelOrder")]
        public async Task<IActionResult> CancelOrder(int orderId, int productId)
        {
            // Lấy thông tin người dùng từ session
            var khachHang = HttpContext.Session.GetJson<NguoiDungModel>("User");
            if (khachHang == null)
            {
                return RedirectToAction("DangNhap", "NguoiDung");
            }

            // Tìm đơn hàng
            var order = await _dataContext.DON_HANGs.FindAsync(orderId);
            if (order == null || order.TRANG_THAI_DH != 0 || order.TRANG_THAI_DH == 1)
            {
                return NotFound();
            }

            // Tìm chi tiết đơn hàng
            var chiTietDonHang = await _dataContext.CHI_TIET_DON_HANGs
                .FirstOrDefaultAsync(ct => ct.ID_DON_HANG == orderId && ct.ID_SAN_PHAM == productId);
            if (chiTietDonHang == null)
            {
                return NotFound();
            }

            // Tìm sản phẩm tương ứng
            var sanPham = await _dataContext.SAN_PHAMs.FindAsync(productId);
            if (sanPham == null)
            {
                return NotFound();
            }

            // Cập nhật số lượng sản phẩm trong kho
            sanPham.SO_LUONG += chiTietDonHang.SO_LUONG;
            _dataContext.SAN_PHAMs.Update(sanPham);


            // Cập nhật tài khoản người dùng trong session
            _dataContext.NGUOI_DUNGs.Update(khachHang);
            await _dataContext.SaveChangesAsync();
            HttpContext.Session.SetJson("User", khachHang);

            // Hủy đơn hàng
            order.TRANG_THAI_DH = 3;
            _dataContext.Update(order);
            await _dataContext.SaveChangesAsync();

            // Lưu thay đổi số lượng sản phẩm
            await _dataContext.SaveChangesAsync();

            TempData["ThanhCong"] = "Hủy đơn hàng thành công";

            return RedirectToAction("DonMua");
        }


        [HttpPost("Reorder")]
        public async Task<IActionResult> Reorder(int orderId, int productId)
        {
            var chiTietDonHang = await _dataContext.CHI_TIET_DON_HANGs
                .Include(ct => ct.SAN_PHAM)
                .Include(ct => ct.DON_HANG)
                .FirstOrDefaultAsync(ct => ct.ID_DON_HANG == orderId && ct.ID_SAN_PHAM == productId);

            if (chiTietDonHang == null || chiTietDonHang.SAN_PHAM == null || chiTietDonHang.DON_HANG == null || chiTietDonHang.DON_HANG.TRANG_THAI_DH != 3)
            {
                return NotFound();
            }


            var donHang = await _dataContext.DON_HANGs.FindAsync(orderId);
            return RedirectToAction("ChiTietSP", "CuaHang", new { id = productId });
        }

        public IActionResult ThongTinDonHang()
        {
            int userId = GetCurrentUserId();
            var allOrders = _dataContext.DON_HANGs.OrderBy(n => n.TRANG_THAI_DH).Where(d => d.ID_NGUOI_DUNG == userId).ToList();
            var pendingOrders = allOrders.Where(d => d.TRANG_THAI_DH == 0).ToList();
            var shippingOrders = allOrders.Where(d => d.TRANG_THAI_DH == 1).ToList();
            var paidOrders = allOrders.Where(d => d.TRANG_THAI_DH == 2).ToList();
            var cancelledOrders = allOrders.Where(d => d.TRANG_THAI_DH == 3).ToList();

            ViewBag.AllOrders = allOrders;
            ViewBag.PendingOrders = pendingOrders;
            ViewBag.ShippingOrders = shippingOrders;
            ViewBag.PaidOrders = paidOrders;
            ViewBag.CancelledOrders = cancelledOrders;

            return View();
        }

    }
}
