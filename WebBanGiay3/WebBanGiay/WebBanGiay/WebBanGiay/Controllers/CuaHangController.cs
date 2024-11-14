using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebBanGiay.Models;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;
using WebBanGiay.Repositoty;
using WebBanGiay.Repository;

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
        public async Task<IActionResult> Index(int page = 1, int pageSize = 9)
        {
            var sanPhamQuery = _dataContext.SAN_PHAMs
                                    .Include(sp => sp.HINH_ANH)
                                    .Where(sp => sp.SO_LUONG > 0)
                                    .AsQueryable();

            var sanPham = await sanPhamQuery
                            .ToPagedListAsync(page, pageSize);

            return View(sanPham);
        }

        public async Task<IActionResult> Search(string searchQuery, int minPrice = 0, int maxPrice = 1000000)
        {
            // Truy vấn sản phẩm từ database với điều kiện số lượng sản phẩm phải lớn hơn 0
            var sanPhamQuery = _dataContext.SAN_PHAMs
                                            .Include(sp => sp.HINH_ANH) // Bao gồm hình ảnh liên quan đến sản phẩm
                                            .Where(sp => sp.SO_LUONG > 0) // Kiểm tra số lượng sản phẩm còn hàng
                                            .AsQueryable(); // Chuyển về dạng truy vấn

            // Tìm kiếm theo tên sản phẩm nếu có searchQuery
            if (!string.IsNullOrEmpty(searchQuery))
            {
                sanPhamQuery = sanPhamQuery.Where(sp => sp.TEN_SAN_PHAM.Contains(searchQuery));
            }

            // Tìm kiếm theo khoảng giá (minPrice và maxPrice)
            sanPhamQuery = sanPhamQuery.Where(sp => sp.GIA_BAN >= minPrice && sp.GIA_BAN <= maxPrice);

            // Lấy danh sách sản phẩm từ cơ sở dữ liệu
            var sanPham = await sanPhamQuery
                .OrderBy(sp => sp.TEN_SAN_PHAM)  // Sắp xếp theo tên sản phẩm (hoặc có thể theo các trường khác tùy yêu cầu)
                .ToListAsync();

            // Trả về partial view với danh sách sản phẩm
            return PartialView("_ProductList", sanPham);
        }



        // Hiển thị chi tiết sản phẩm
        public async Task<IActionResult> ChiTietSP(int id)
        {

            var sanPham = await _dataContext.SAN_PHAMs
                                            .Include(sp => sp.HINH_ANH)
                                            .Include(sp => sp.TEN_KICH_THUOC)
                                            .Include(sp => sp.TEN_LOAI)
                                            .FirstOrDefaultAsync(sp => sp.ID_SAN_PHAM == id);

            if (sanPham == null)
            {
                return NotFound();
            }

            var danhSachMau = await _dataContext.MauSanPhamModels
                                                .Where(mau => _dataContext.SAN_PHAM_MAUs
                                                                           .Any(spm => spm.ID_MAU == mau.ID_MAU))
                                                .ToListAsync();
            ViewBag.DANHSACHMAU = danhSachMau;

            var sanPhamLienQuan = await _dataContext.SAN_PHAMs
                .Include(sp => sp.HINH_ANH)
                .Where(sp => sp.ID_LOAI == sanPham.ID_LOAI && sp.ID_SAN_PHAM != id)
                .Take(4)
                .ToListAsync();

            ViewBag.HinhAnhLienQuan = sanPhamLienQuan.Select(sp => sp.HINH_ANH.FirstOrDefault()).ToList();
            ViewBag.SanPhamLienQuan = sanPhamLienQuan;

            return View(sanPham);
        }
    }
}
