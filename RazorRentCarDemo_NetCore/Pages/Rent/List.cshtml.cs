using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorRentCarDemo_NetCore.Data;
using RazorRentCarDemo_NetCore.Model;

namespace RazorRentCarDemo_NetCore.Pages.Rent
{
    public class ListModel : PageModel
    {
        private readonly RazorRentCarDemo_NetCore.Data.RentDbContext _context;

        public ListModel(RazorRentCarDemo_NetCore.Data.RentDbContext context)
        {
            _context = context;
        }

        public IList<Rezervation> Rezervation { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Rez != null)
            {
                Rezervation = await _context.Rez.ToListAsync();
            }
        }
    }
}
