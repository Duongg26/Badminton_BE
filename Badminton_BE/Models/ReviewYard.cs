namespace Badminton_BE.Models
{
    public class ReviewYard
    {
   
  
            public int Id { get; set; }
            public string Comment { get; set; }
            public int Rating { get; set; }

            public Yard Yard { get; set; }
        }
    }


