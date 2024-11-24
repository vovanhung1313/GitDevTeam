using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebBanGiay.Models
{
    public class ChiTietDonHangModel
    {
        [Key]
        public int ID_CHI_TIET_DON_HANG { get; set; }
        public int ID_DON_HANG { get; set; }
        [ForeignKey("ID_DON_HANG")]
        public DonHangModel DON_HANG { get; set; }

        public int ID_SAN_PHAM { get; set; }
        [ForeignKey("ID_SAN_PHAM")]
        public SanPhamModel SAN_PHAM { get; set; }

        public string MauSanPham { get; set; }
        public int SO_LUONG { get; set; }
        public decimal GIA_BAN { get; set; } = 0;
        public decimal THANH_TIEN { get; set; } = 0;
    }
}
