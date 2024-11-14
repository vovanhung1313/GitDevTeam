using System.ComponentModel.DataAnnotations;

namespace WebBanGiay.Models
{
    public class QuenMatKhauModel
    {
        [Required(ErrorMessage = "Yêu cầu nhập Email")]
        [EmailAddress(ErrorMessage = "Định dạng Email không đúng")]
        public string Email { get; set; }
    }
}
