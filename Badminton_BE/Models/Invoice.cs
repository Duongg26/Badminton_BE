namespace Badminton_BE.Models
{
    public class Invoice
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string NameYard { get; set; }
        public int Price { get; set; }
        public DateTime DateTime { get; set; }
        public int Status { get; set; }
        public Yard Yard { get; set; }
        public Account Account { get; set; }
    }
}
