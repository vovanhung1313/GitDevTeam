using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebBanGiay.Models;

namespace WebBanGiay.Models
{
    public class HinhAnhModel
    {
        [Key]
        public int ID_HINH_ANH { get; set; }
        [Required]
        public string TEN_HINH_ANH { get; set; }

        public int ID_SAN_PHAM { get; set; }
        [ForeignKey("ID_SAN_PHAM")]
        public virtual SanPhamModel SAN_PHAM { get; set; }

    }
}
