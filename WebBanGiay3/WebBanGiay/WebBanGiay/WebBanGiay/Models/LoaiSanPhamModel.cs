using System.ComponentModel.DataAnnotations;

namespace WebBanGiay.Models
{
    public class LoaiSanPhamModel
    {
        [Key]
        public int ID_LOAI { get; set; }

        [Required(ErrorMessage = "Không được để trống loại sản phẩm.")]
        [MinLength(5, ErrorMessage = "Loại sản phẩm phải từ 5 ký tự.")]
        public string TEN_LOAI { get; set; }
    }
}

