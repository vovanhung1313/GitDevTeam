using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using WebBanGiay.Models;

public class Comment
{
    [Key]
    public int ID_COMMENT { get; set; }

    [Required(ErrorMessage = "Nội dung bình luận không được để trống.")]
    [StringLength(500, ErrorMessage = "Nội dung bình luận không được vượt quá 500 ký tự.")]
    public string NoiDungComment { get; set; }

    public int ID_SAN_PHAM { get; set; }
    [ForeignKey("ID_SAN_PHAM")]
    public virtual SanPhamModel SanPham { get; set; }

    public int ID_NGUOI_DUNG { get; set; }
    [ForeignKey("ID_NGUOI_DUNG")]
    public virtual NguoiDungModel NguoiDung { get; set; }

    [Required]
    public DateTime NgayTao { get; set; } = DateTime.Now;

    [Range(1, 5, ErrorMessage = "Số sao phải nằm trong khoảng từ 1 đến 5.")]
    public int SaoDanhGia { get; set; }
}
