
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorRentCarDemo_NetCore.Data;
using RazorRentCarDemo_NetCore.Model;

namespace RazorRentCarDemo_NetCore.Pages.Rent
{
    public class CreateModel : PageModel
    {
        public Car Cars { get; set; }

        [BindProperty]
        public string CustomerName { get; set; }
        [BindProperty]
        public int CarId { get; set; }

        //[BindProperty]
        //public Rezervation Rezervation { get; set; }


        private readonly RentDbContext _context;
        public CreateModel(RentDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet(int id)
        {
            Cars = _context.Car.Find(id);

            if (Cars == null) return NotFound();

            return Page();

        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var carGarage = _context.Car.Find(CarId);

            if (carGarage != null)
            {

                carGarage.Avaliable = false;
                _context.Car.Update(carGarage);

                Rezervation res = new();
                res.Car = carGarage;
                res.Start = DateTime.Now;
                res.CustomerName = CustomerName;
                _context.Rez.Add(res);

                await _context.SaveChangesAsync();

                return RedirectToPage("./Index");
            }

            return Page();
        }

    }
}
