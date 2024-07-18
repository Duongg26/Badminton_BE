namespace Badminton_BE.Models
{
    public class Yard
    {
        public int Id { get; set; }
        public string YardName { get; set; }
        public string YardDescription { get; set; }
        public int Price { get; set; }
        public int Status {  get; set; }
        public List<ReviewYard > Yards { get;set; }

    }
}
