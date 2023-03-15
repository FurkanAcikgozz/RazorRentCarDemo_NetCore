using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorRentCarDemo_NetCore.Data;
using RazorRentCarDemo_NetCore.Model;

namespace RazorRentCarDemo_NetCore.Pages.Rent
{
    public class EditModel : PageModel
    {
        private readonly RazorRentCarDemo_NetCore.Data.RentDbContext _context;

        public EditModel(RazorRentCarDemo_NetCore.Data.RentDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Rezervation Rezervation { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Rez == null)
            {
                return NotFound();
            }

            var rezervation =  await _context.Rez.FirstOrDefaultAsync(m => m.ID == id);
            if (rezervation == null)
            {
                return NotFound();
            }
            Rezervation = rezervation;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Rezervation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RezervationExists(Rezervation.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool RezervationExists(int id)
        {
          return _context.Rez.Any(e => e.ID == id);
        }
    }
}
