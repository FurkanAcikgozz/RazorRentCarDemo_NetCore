using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;

namespace RazorRentCarDemo_NetCore.Model
{
    public class Car
    {
        public int Id { get; set; }
        [System.ComponentModel.DataAnnotations.Required,StringLength(20)]
        public string Brand { get; set; }

        [Display(Name = "Unit Price2")]
        public decimal UnitPrace { get; set; }

        public bool Avaliable { get; set; } /*= default;*/


    }
}
