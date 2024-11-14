using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebBanGiay.Models
{
    public class MauSanPhamModel
    {
        [Key]
        public int ID_MAU { get; set; }

        [Required(ErrorMessage = "Không được để trống màu")]
        [MinLength(1, ErrorMessage = "Màu phải từ 2 ký tự.")]
        public string TEN_MAU { get; set; }
    }
}
