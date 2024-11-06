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

        [Required(ErrorMessage = "Không được để trống tên kích thước.")]
        [Range(1, 100, ErrorMessage = "Tên kích thước phải là số từ 1 đến 100.")]

        public int TEN_KICH_THUOC { get; set; }
    }
}
