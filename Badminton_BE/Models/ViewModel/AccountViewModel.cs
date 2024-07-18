using System.ComponentModel.DataAnnotations;

namespace Badminton_BE.Models.ViewModel
{
    public class AccountViewModel
    {
        [MinLength(1)]
        public String Name { get; set; }
        [MinLength(1)]
        public string UName { get; set; }
        [MinLength(1)]
        public string Addr {  get; set; }
       
        [Range(0, 2, ErrorMessage = "Vai trò phải là 0, 1 hoặc 2")]
        public int Role { get; set; }
        
        [Range(0, 1, ErrorMessage = "Trạng thái phải là 0 hoặc 1")]
        public int Status { get; set; }
    }
}
