using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebBanGiay.Models
{
    public class SanPhamModel
    {
        [Key]
        public int ID_SAN_PHAM { get; set; }
        [Required(ErrorMessage = "Không được để chống tên sản phẩm.")]
        public string TEN_SAN_PHAM { get; set; }

        public int ID_LOAI { get; set; }
        [ForeignKey("ID_LOAI_SAN_PHAM")]
        public LoaiSanPhamModel? TEN_LOAI { get; set; }
        public int ID_KICH_THUOC { get; set; }
        [ForeignKey("ID_KICH_THUOC")]
        public KichThuocSanPhamModel? TEN_KICH_THUOC { get; set; }

        [Required(ErrorMessage = "Không được để chống số lượng.")]
        [Range(1, int.MaxValue, ErrorMessage = "Số lượng không được âm")]
        public int SO_LUONG { get; set; }
        [Required(ErrorMessage = "Không được để trống giá nhập.")]
        [Range(1, double.MaxValue, ErrorMessage = "Giá nhập không được âm.")]
        public decimal GIA_NHAP { get; set; }

        [Required(ErrorMessage = "Không được để trống giá bán.")]
        [Range(1, double.MaxValue, ErrorMessage = "Giá bán không được âm.")]
        public decimal GIA_BAN { get; set; }

        [Required(ErrorMessage = "Không được để chống chất liệu.")]
        public string CHAT_LIEU { get; set; }
        [Required(ErrorMessage = "Không được để chống mô tả.")]
        public string MO_TA { get; set; }
        public DateTime NGAY_TAO { get; set; } = DateTime.Now;

        public ICollection<HinhAnhModel>? HINH_ANH { get; set; }

        public ICollection<MauSanPhamModel>? MauSanPham { get; set; }

        [NotMapped]
        public IFormFile? HinhAnhTaiLen { get; set; }
    }
}
