using System.ComponentModel.DataAnnotations;

namespace RazorRentCarDemo_NetCore.Model
{
    public class Rezervation
    {
        public int ID { get; set; } //EF > DB oluşturulacak
        [Required, StringLength(50), Display(Name = "Customer Name")] 
        public string CustomerName { get; set; } //UI dan gelecek
        public DateTime Start { get; set; } = DateTime.Now; //now
        public DateTime End { get; set; } = DateTime.MaxValue; // pas geçilecek
        public int TotalPrice { get; set; }
        public Car Car { get; set; } // id ile gelecek

    }
}
