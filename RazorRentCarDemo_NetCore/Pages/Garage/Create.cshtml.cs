using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RazorRentCarDemo_NetCore.Data;
using RazorRentCarDemo_NetCore.Model;

namespace RazorRentCarDemo_NetCore.Pages.Garage
{
    public enum CarState
    {
        [Display(Name ="Avaliable For Rent")]
        Avaliable = 1,
        [Display(Name = "Avaliable For Not Rent")]
        NotAvaliable = 2,
        [Display(Name = "Rented")]
        Rented = 3
    }
    public class CreateModel : PageModel
    {
        private readonly RentDbContext _context;

        [BindProperty] //post ile alıyoruz
        public CarState CStateEnum { get; set; }
        [BindProperty]//post ile alıyoruz
        public string CStateListSelection { get; set; }


        [BindProperty]
        public string TestText { get; set; }


        //Get ile dolduruyoruz
        public List<SelectListItem> CarStateList { get; } = new List<SelectListItem>
        {
            new SelectListItem { Value = "MX", Text = "Avaliable" },
            new SelectListItem { Value = "CA", Text = "NotAvaliable" },
            new SelectListItem { Value = "US", Text = "Rented"  },
        };



        public CreateModel(RentDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Car Car { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Car.Add(Car);
            await _context.SaveChangesAsync();

            TempData["success"] = "Added succesfully";

            return RedirectToPage("./Index");
        }
    }
}
