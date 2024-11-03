using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebBanGiay.Models
{
    public class KichThuocSanPhamModel
    {
        [Key]
        public int ID_KICH_THUOC { get; set; }

        [Required(ErrorMessage = "YKhông được để trống kích thước")]
        [RegularExpression(@"^\d{1}$", ErrorMessage = "Kich phải là số và có 1 ký tự.")]
        [StringLength(1, MinimumLength = 5, ErrorMessage = "Kích thước phải là số và từ 1 đến 5 kí tự.")]

        public int TEN_KICH_THUOC { get; set; }
    }
}
