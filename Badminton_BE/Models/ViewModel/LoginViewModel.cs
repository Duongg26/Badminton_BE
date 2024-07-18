using System.ComponentModel.DataAnnotations;

namespace Badminton_BE.Models.ViewModel
{
    public class LoginViewModel
    {
        [Required]
        public string UName { get; set; }
        [Required]
       // [MinLength(7, ErrorMessage = "Mật khẩu quá ngắn")]
        public string Pass {  get; set; }
    }
}
