using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorRentCarDemo_NetCore.Data;
using RazorRentCarDemo_NetCore.Model;



namespace RazorRentCarDemo_NetCore.Pages.Rent
{
    public class ReturnProcModel : PageModel
    {
        public Rezervation? Reservation { get; set; }

        private readonly RentDbContext _context;

        public ReturnProcModel(RentDbContext context)
        {
            _context = context;
        }
        public IActionResult OnGet(int id)
        {
            Reservation = _context
                .Rez
                .Include(c => c.Car)
                .FirstOrDefault(d => d.ID == id);


            if (Reservation is not null)
            {
                Reservation.End = DateTime.Now;
                Reservation.TotalPrice = CalculatePrice(Reservation);
                return Page();
            }

            return NotFound();
        }

        public IActionResult OnGetReturnOK(int id)
        {
            var res = _context.Rez.Include(c => c.Car).FirstOrDefault(d => d.ID == id);

            if (res is not null)
            {
                res.End = DateTime.Now;
                res.TotalPrice = CalculatePrice(res);
                res.Car.Avaliable = true;

                _context.Rez.Update(res);
                _context.SaveChanges();

                return RedirectToPage("ReturnFinal", new { res.TotalPrice });
            }
            return NotFound();
        }

        private int CalculatePrice(Rezervation r)
        {
            
            var duration = r.End - r.Start;
            int p = (int)duration.TotalMinutes * (int)r.Car.UnitPrace;

            return p;
        }

    }
}
