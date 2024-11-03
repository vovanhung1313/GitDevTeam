using System.ComponentModel.DataAnnotations;

namespace WebBanGiay.Models
{
    public class LienHeModel
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Phone { get; set; }

        [Required]
        [StringLength(1000)]
        public string Message { get; set; }
    }
}
