using System.ComponentModel.DataAnnotations;

namespace RazorRentCarDemo_NetCore.Model
{
    public class Rezervation
    {
        public int ID { get; set; }
        [Required, StringLength(50)]
        public string CustomerName { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public int TotalPrice { get; set; }
        public Car Car { get; set; }

    }
}
