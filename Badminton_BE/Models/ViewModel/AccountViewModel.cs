using System.ComponentModel.DataAnnotations;

namespace Badminton_BE.Models.ViewModel
{
    public class AccountViewModel
    {
        [Required]
        public String Name { get; set; }
        [Required] 
        public string UName { get; set; }
        [Required]
        public string Addr {  get; set; }
        [Required]
        public int Role { get; set; }
        [Required]
        public int Status { get; set; }
    }
}
