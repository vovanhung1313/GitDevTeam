using Microsoft.AspNetCore.Mvc;
using WebBanGiay.Models;  
using WebBanGiay.Repository; 
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


        public IActionResult Index()
        {
            
            var danhSachMau = _dataContext.MauSanPhamModels.ToList();
            var viewModel = new MauSanPhamViewModel
            {
                DanhSachMau = danhSachMau
            };
            return View(viewModel);
        }

        public IActionResult ThemMau()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ThemMau(MauSanPhamModel mau)
        {
            if (ModelState.IsValid)
            {
                _dataContext.Add(mau);
                await _dataContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));  
            }
            return View(mau);  
        }


        public IActionResult SuaMau(int id)
        {

            var mau = _dataContext.MauSanPhamModels.FirstOrDefault(m => m.ID_MAU == id);
            if (mau == null)
            {
                return NotFound();  
            }
            return View(mau);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SuaMau(int id, MauSanPhamModel mau)
        {
            if (id != mau.ID_MAU)
            {
                return NotFound(); 
            }

            if (ModelState.IsValid)
            {
                try
                {
                   
                    _dataContext.Update(mau);
                    await _dataContext.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_dataContext.MauSanPhamModels.Any(e => e.ID_MAU == mau.ID_MAU))
                    {
                        return NotFound(); 
                    }
                    else
                    {
                        throw;  
                    }
                }
                return RedirectToAction(nameof(Index));  
            }
            return View(mau);  
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> XoaMau(int id)
        {
            var mau = await _dataContext.MauSanPhamModels.FindAsync(id);
            if (mau == null)
            {
                return NotFound();  
            }

            _dataContext.MauSanPhamModels.Remove(mau);  
            await _dataContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));  
        }
    }
}
