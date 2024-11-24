    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using WebBanGiay.Models;
    using WebBanGiay.Repository;
    using WebBanGiay.Repositoty;
    using X.PagedList;

    namespace WebBanGiay.Controllers
    {
        public class CuaHangController : Controller
        {
            private readonly DataContext _dataContext;

            public CuaHangController(DataContext dataContext)
            {
                _dataContext = dataContext;
            }

            // Hiển thị trang chính của cửa hàng với phân trang
            public async Task<IActionResult> Index(int page = 1, int pageSize = 12)
            {
                var sanPhamQuery = _dataContext.SAN_PHAMs
                                        .Include(sp => sp.HINH_ANH)
                                        .Where(sp => sp.SO_LUONG > 0);

                var sanPham = await sanPhamQuery
                                .ToPagedListAsync(page, pageSize);

                return View(sanPham);
            }

            // Tìm kiếm sản phẩm với phân trang
            public async Task<IActionResult> Search(string searchQuery, int? minPrice, int? maxPrice, int page = 1, int pageSize = 12)
            {
                var sanPhamQuery = _dataContext.SAN_PHAMs
                                    .Include(sp => sp.HINH_ANH)
                                    .Where(sp => sp.SO_LUONG > 0);

                if (!string.IsNullOrEmpty(searchQuery))
                {
                    sanPhamQuery = sanPhamQuery.Where(sp => sp.TEN_SAN_PHAM.Contains(searchQuery.Trim()));
                }

                if (minPrice.HasValue)
                {
                    sanPhamQuery = sanPhamQuery.Where(sp => sp.GIA_BAN >= minPrice.Value);
                }

                if (maxPrice.HasValue)
                {
                    sanPhamQuery = sanPhamQuery.Where(sp => sp.GIA_BAN <= maxPrice.Value);
                }

                var sanPham = await sanPhamQuery
                                    .ToPagedListAsync(page, pageSize);

                return PartialView("_ProductList", sanPham);
            }

            // Chi tiết sản phẩm
            public async Task<IActionResult> ChiTietSP(int id)
            {
                var sanPham = await _dataContext.SAN_PHAMs
                                                .Include(sp => sp.HINH_ANH)
                                                .Include(sp => sp.Comments)
                                                .ThenInclude(c => c.NguoiDung)
                                                .FirstOrDefaultAsync(sp => sp.ID_SAN_PHAM == id);

                if (sanPham == null)
                {
                    return NotFound("Sản phẩm không tồn tại.");
                }

                // Tính điểm đánh giá trung bình
                var averageRating = sanPham.Comments.Any()
                    ? sanPham.Comments.Average(c => c.SaoDanhGia)
                    : 0;

                ViewBag.AverageRating = Math.Round(averageRating, 1);

                // Lấy danh sách màu và sản phẩm liên quan
                var danhSachMau = await _dataContext.MauSanPhamModels.ToListAsync();
                var sanPhamLienQuan = await _dataContext.SAN_PHAMs
                    .Include(sp => sp.HINH_ANH)
                    .Where(sp => sp.ID_LOAI == sanPham.ID_LOAI && sp.ID_SAN_PHAM != id)
                    .Take(4)
                    .ToListAsync();

                ViewBag.DANHSACHMAU = danhSachMau;
                ViewBag.SanPhamLienQuan = sanPhamLienQuan;

                return View(sanPham);
            }

        [HttpPost]
        public async Task<IActionResult> AddComment(int productId, string commentContent, int starRating)
        {
            var user = HttpContext.Session.GetJson<NguoiDungModel>("User");

            if (user == null)
            {
                TempData["Message"] = "Bạn cần đăng nhập để thực hiện đánh giá.";
                TempData["MessageType"] = "danger";
                return RedirectToAction("ChiTietSP", new { id = productId });
            }

            var sanPham = await _dataContext.SAN_PHAMs.FindAsync(productId);
            if (sanPham == null)
            {
                TempData["Message"] = "Sản phẩm không tồn tại.";
                TempData["MessageType"] = "danger";
                return RedirectToAction("Index");
            }

            // Kiểm tra người dùng đã đánh giá trước đó
            var existingComment = await _dataContext.Comments
                .FirstOrDefaultAsync(c => c.ID_SAN_PHAM == productId && c.ID_NGUOI_DUNG == user.ID_NGUOI_DUNG);

            if (existingComment != null)
            {
                TempData["Message"] = "Bạn đã đánh giá sản phẩm này trước đó.";
                TempData["MessageType"] = "warning";
                return RedirectToAction("ChiTietSP", new { id = productId });
            }

            // Lưu nhận xét và đánh giá
            var comment = new Comment
            {
                NoiDungComment = commentContent,
                ID_SAN_PHAM = productId,
                ID_NGUOI_DUNG = user.ID_NGUOI_DUNG,
                SaoDanhGia = starRating,
                NgayTao = DateTime.Now
            };

            _dataContext.Comments.Add(comment);
            await _dataContext.SaveChangesAsync();

            TempData["Message"] = "Cảm ơn bạn đã đánh giá sản phẩm!";
            TempData["MessageType"] = "success";
            return RedirectToAction("ChiTietSP", new { id = productId });
        }


    }
    }
