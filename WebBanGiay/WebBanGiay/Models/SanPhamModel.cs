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
        [ForeignKey("ID_LOAI")]
        public LoaiSanPhamModel? TEN_LOAI { get; set; }
        public int ID_KICH_THUOC { get; set; }
        [ForeignKey("ID_KICH_THUOC")]
        public KichThuocSanPhamModel? TEN_KICH_THUOC { get; set; }

        [Required(ErrorMessage = "Không được để trống số lượng.")]
        [Range(1, int.MaxValue, ErrorMessage = "Số lượng phải là số nguyên dương.")]
        [RegularExpression(@"^\d+$", ErrorMessage = "Số lượng phải là số nguyên dương.")]
        public int SO_LUONG { get; set; }

        [Required(ErrorMessage = "Không được để trống giá nhập.")]
        [Range(1, int.MaxValue, ErrorMessage = "Giá nhập phải là số nguyên dương.")]
        [RegularExpression(@"^\d+$", ErrorMessage = "Giá nhập phải là số nguyên dương.")]
        public int GIA_NHAP { get; set; }

        [Required(ErrorMessage = "Không được để trống giá bán.")]
        [Range(1, int.MaxValue, ErrorMessage = "Giá bán phải là số nguyên dương.")]
        [RegularExpression(@"^\d+$", ErrorMessage = "Giá bán phải là số nguyên dưdsdfsdfsdfơng.")]
        public int GIA_BAN { get; set; }


        [Required(ErrorMessage = "Không được để chống chất liệu.")]
        public string CHAT_LIEU { get; set; }
        [Required(ErrorMessage = "Không được để chống mô tả.")]
        public string MO_TA { get; set; }
        public DateTime NGAY_TAO { get; set; } = DateTime.Now;

        public ICollection<HinhAnhModel>? HINH_ANH { get; set; }

        public ICollection<SanPhamMauModel>? SanPhamMau { get; set; }

        [NotMapped]
        public IFormFile? HinhAnhTaiLen { get; set; }
        public virtual ICollection<Comment> Comments { get; set; } 

    }
}
