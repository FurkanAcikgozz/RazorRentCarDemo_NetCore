
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorRentCarDemo_NetCore.Data;
using RazorRentCarDemo_NetCore.Model;

namespace RazorRentCarDemo_NetCore.Pages.Rent
{
    public class IndexModel : PageModel
    {
        private readonly RentDbContext _context;

        public IndexModel(RentDbContext context)
        {
            _context = context;
        }

        public IList<Car> Cars { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Car != null)
            {
                //Cars = await _context.Car.Where(c => c.Avaliable == true).ToListAsync();
                Cars = await _context.Car.ToListAsync();
            }
        }
    }
}
