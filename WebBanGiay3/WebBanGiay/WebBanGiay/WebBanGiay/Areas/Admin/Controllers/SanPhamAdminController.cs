using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebBanGiay.Models;
using WebBanGiay.Repository;
using System.IO;
using X.PagedList;
using WebBanGiay.Repositoty;
namespace WebBanGiay.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin")]
    [Route("Admin/SanPhamAdmin")]
    public class SanPhamAdminController : Controller
    {
        private readonly DataContext _dataContext;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public SanPhamAdminController(DataContext dataContext, IWebHostEnvironment webHostEnvironment)
        {
            _dataContext = dataContext;
            _webHostEnvironment = webHostEnvironment;
        }
        [Route("")]
        [Route("Index")]
        public IActionResult Index(int page = 1, int pageSize = 20)
        {
            var DanhSachSanPham = _dataContext.SAN_PHAMs.Include(s => s.HINH_ANH).Include(m => m.SanPhamMau).ThenInclude(V => V.Mau).AsQueryable();
            var SanPhamTrang = DanhSachSanPham.ToPagedList(page, pageSize);
            return View(SanPhamTrang);
        }

        [Route("ThemSanPham")]
        public IActionResult ThemSanPham()
        {
            ViewBag.Loais = new SelectList(_dataContext.LOAI_SAN_PHAMs, "ID_LOAI", "TEN_LOAI");
            ViewBag.KichThuocs = new SelectList(_dataContext.KICH_THUOCs, "ID_KICH_THUOC", "TEN_KICH_THUOC");
            ViewBag.Maus = new SelectList(_dataContext.MAU_SACs, "ID_MAU", "TEN_MAU");
            return View();
        }


        [Route("ThemSanPham")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SanPhamModel sanPham, List<IFormFile> HinhAnhTaiLen, int[] selectedColors)
        {
            if (ModelState.IsValid)
            {
                _dataContext.Add(sanPham);
                await _dataContext.SaveChangesAsync();

                foreach (var colorId in selectedColors)
                {
                    var sanPhamMau = new SanPhamMauModel
                    {
                        ID_SAN_PHAM = sanPham.ID_SAN_PHAM,
                        ID_MAU = colorId
                    };
                    _dataContext.SAN_PHAM_MAUs.Add(sanPhamMau);
                }

                foreach (var file in HinhAnhTaiLen)
                {
                    if (file != null && file.Length > 0)
                    {
                        string uploadDir = Path.Combine(_webHostEnvironment.WebRootPath, "media/SanPham");
                        string imageName = Guid.NewGuid().ToString() + "_" + file.FileName;
                        string filePath = Path.Combine(uploadDir, imageName);

                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await file.CopyToAsync(stream);
                        }

                        HinhAnhModel anh = new HinhAnhModel
                        {
                            TEN_HINH_ANH = imageName,
                            ID_SAN_PHAM = sanPham.ID_SAN_PHAM
                        };
                        _dataContext.HINH_ANHs.Add(anh);
                    }
                }

                await _dataContext.SaveChangesAsync();
                TempData["ThanhCong"] = "Thêm sản phẩm thành công";
                return RedirectToAction(nameof(Index));
            }

            TempData["ThatBai"] = "Thêm sản phẩm thất bại";
            return View(sanPham);
        }

        [Route("SuaSanPham/{id}")]
        public IActionResult SuaSanPham(int id)
        {
            var SanPham = _dataContext.SAN_PHAMs.Include(h => h.HINH_ANH).Include(sp => sp.SanPhamMau).FirstOrDefault(sp => sp.ID_SAN_PHAM == id);
            if (SanPham == null)
            {
                return NotFound();
            }

            ViewBag.Loais = new SelectList(_dataContext.LOAI_SAN_PHAMs, "ID_LOAI", "TEN_LOAI");
            ViewBag.KichThuocs = new SelectList(_dataContext.KICH_THUOCs, "ID_KICH_THUOC", "TEN_KICH_THUOC");
            ViewBag.Maus = _dataContext.MAU_SACs.ToList();

            // Truyền các màu đã chọn
            ViewBag.SelectedColors = SanPham.SanPhamMau.Select(sm => sm.ID_MAU).ToList();

            return View(SanPham);
        }

        [Route("SuaSanPham/{id}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SuaSanPham(int id, SanPhamModel SanPham, List<IFormFile> hinhAnhTaiLen, int[] selectedImages, int[] selectedColors)
        {
            if (ModelState.IsValid)
            {
                var existingSanPham = await _dataContext.SAN_PHAMs.Include(h => h.HINH_ANH).Include(sp => sp.SanPhamMau).FirstOrDefaultAsync(sp => sp.ID_SAN_PHAM == id);
                if (existingSanPham == null)
                {
                    return NotFound();
                }

                existingSanPham.TEN_SAN_PHAM = SanPham.TEN_SAN_PHAM;
                existingSanPham.ID_LOAI = SanPham.ID_LOAI;
                existingSanPham.ID_KICH_THUOC = SanPham.ID_KICH_THUOC;
                existingSanPham.GIA_BAN = SanPham.GIA_BAN;
                existingSanPham.GIA_NHAP = SanPham.GIA_NHAP;
                existingSanPham.SO_LUONG = SanPham.SO_LUONG;
                existingSanPham.CHAT_LIEU = SanPham.CHAT_LIEU;
                existingSanPham.MO_TA = SanPham.MO_TA;

                // Cập nhật màu sắc
                existingSanPham.SanPhamMau.Clear();
                foreach (var colorId in selectedColors)
                {
                    var sanPhamMau = new SanPhamMauModel
                    {
                        ID_SAN_PHAM = existingSanPham.ID_SAN_PHAM,
                        ID_MAU = colorId
                    };
                    existingSanPham.SanPhamMau.Add(sanPhamMau);
                }


                foreach (var file in hinhAnhTaiLen)
                {
                    if (file != null && file.Length > 0)
                    {
                        string uploadDir = Path.Combine(_webHostEnvironment.WebRootPath, "media/SanPham");
                        string imageName = Guid.NewGuid().ToString() + "_" + file.FileName;
                        string filePath = Path.Combine(uploadDir, imageName);

                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await file.CopyToAsync(stream);
                        }

                        HinhAnhModel anh = new HinhAnhModel
                        {
                            TEN_HINH_ANH = imageName,
                            ID_SAN_PHAM = existingSanPham.ID_SAN_PHAM
                        };
                        _dataContext.HINH_ANHs.Add(anh);
                    }
                }

                if (selectedImages != null && selectedImages.Length > 0)
                {
                    var imagesToRemove = existingSanPham.HINH_ANH.Where(h => !selectedImages.Contains(h.ID_HINH_ANH)).ToList();
                    foreach (var image in imagesToRemove)
                    {
                        var filePath = Path.Combine(_webHostEnvironment.WebRootPath, "media/SanPham", image.TEN_HINH_ANH);
                        if (System.IO.File.Exists(filePath))
                        {
                            System.IO.File.Delete(filePath);
                        }
                        _dataContext.HINH_ANHs.Remove(image);
                    }
                }

                _dataContext.Update(existingSanPham);
                await _dataContext.SaveChangesAsync();
                TempData["ThanhCong"] = "Sửa sản phẩm thành công";
                return RedirectToAction(nameof(Index));
            }

            TempData["ThatBai"] = "Sửa sản phẩm thất bại";
            return View(SanPham);
        }

        [HttpPost]
        [Route("XoaSanPham")]
        public async Task<IActionResult> XoaSanPham(int id)
        {
            var sanPham = await _dataContext.SAN_PHAMs.Include(h => h.HINH_ANH).Include(sp => sp.SanPhamMau).FirstOrDefaultAsync(sp => sp.ID_SAN_PHAM == id);
            if (sanPham == null)
            {
                return NotFound();
            }

            foreach (var image in sanPham.HINH_ANH)
            {
                var filePath = Path.Combine(_webHostEnvironment.WebRootPath, "media/SanPham", image.TEN_HINH_ANH);
                if (System.IO.File.Exists(filePath))
                {
                    System.IO.File.Delete(filePath);
                }
            }

            _dataContext.SAN_PHAMs.Remove(sanPham);
            await _dataContext.SaveChangesAsync();
            TempData["ThanhCong"] = "Xóa sản phẩm thành công";
            return RedirectToAction(nameof(Index));
        }
    }
}
