using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebBanGiay.Models
{
    public class GioHangModel
    {
        [Key]
        public int ID_GIO_HANG { get; set; }
        public int ID_NGUOI_DUNG { get; set; }
        [ForeignKey("ID_NGUOI_DUNG")]
        public NguoiDungModel NGUOI_DUNG { get; set; }
        public int ID_SAN_PHAM { get; set; }
        [ForeignKey("ID_SAN_PHAM")]
        public SanPhamModel SAN_PHAM { get; set; }
        public int SO_LUONG_GH { get; set; }
        public decimal THANH_TIEN { get; set; } = 0;
        public decimal GIA_BAN { get; set; } = 0;
        public string MAU_SP { get; set; }
        public string TRANG_THAI { set; get; } = "Chờ duyệt";
    }
}
