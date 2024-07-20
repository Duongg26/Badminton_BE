using System.ComponentModel.DataAnnotations;

namespace Badminton_BE.Models.ViewModel
{
    public class YardViewModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string YardName { get; set; }
        [Required]
        public string YardDescription { get; set; }
        [Required]
        public int Price { get; set; }
        public int Status { get; set; } = 1;
    }
}
