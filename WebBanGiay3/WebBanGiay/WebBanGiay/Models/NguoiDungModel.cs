using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebBanGiay.Models
{
    public class NguoiDungModel
    {
        [Key]
        public int ID_NGUOI_DUNG { get; set; }

        [Required(ErrorMessage = "Không được để trống họ và tên.")]
        [StringLength(40, MinimumLength = 5, ErrorMessage = "Họ tên phải từ 5 đến 40 ký tự.")]

        public string HO_TEN { get; set; }

        [Required(ErrorMessage = "Yêu cầu nhập số điện thoại")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "SDT phải là số và có 10 ký tự.")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "Số điện thoại phải có đúng 10 chữ số.")]
        public string SDT { get; set; }

        [Required(ErrorMessage = "Không được để trống giấy tờ tùy thân.")]
        public string GTTT { get; set; } = "User_images.jpg";

        [Required(ErrorMessage = "Yêu cầu nhập Email")]
        [EmailAddress(ErrorMessage = "Định dạng Email không đúng")]
        public string EMAIL { get; set; }

        [Required(ErrorMessage = "Yêu cầu nhập tên tài khoản")]
        [MinLength(5, ErrorMessage = "Tên tài khoản phải có ít nhất 5 ký tự.")]
        [MaxLength(20, ErrorMessage = "Tên tài khoản không được vượt quá 20 ký tự.")]
        public string TAI_KHOAN { get; set; }

        [Required(ErrorMessage = "Yêu cầu nhập mật khẩu")]
        [MinLength(5, ErrorMessage = "Mật khẩu phải có ít nhất 5 ký tự.")]
        [MaxLength(20, ErrorMessage = "Mật khẩu không được vượt quá 20 ký tự.")]
        public string MAT_KHAU { get; set; }

        public int VAI_TRO { get; set; } = 0;

        [Required(ErrorMessage = "Không được để trống hình ảnh.")]
        public string HINH_ANH { get; set; } = "User_images.jpg";
        public DateTime NGAY_TAO { get; set; } = DateTime.Now;
        public int TRANG_THAI { get; set; } = 0;

        [NotMapped]
        public IFormFile? HinhAnhTaiLen { get; set; }

        [Required(ErrorMessage = "Không được để trống địa chỉ.")]
        [StringLength(40, MinimumLength = 5, ErrorMessage = "Địa chỉ phải từ 5 đến 40 ký tự.")]

        public string DIA_CHI { get; set; } 

    }
}
