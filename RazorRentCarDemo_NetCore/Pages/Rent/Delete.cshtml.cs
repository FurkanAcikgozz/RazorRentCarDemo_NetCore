﻿using System;
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
    public class DeleteModel : PageModel
    {
        private readonly RazorRentCarDemo_NetCore.Data.RentDbContext _context;

        public DeleteModel(RazorRentCarDemo_NetCore.Data.RentDbContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Rezervation Rezervation { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Rez == null)
            {
                return NotFound();
            }

            var rezervation = await _context.Rez.FirstOrDefaultAsync(m => m.ID == id);

            if (rezervation == null)
            {
                return NotFound();
            }
            else 
            {
                Rezervation = rezervation;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Rez == null)
            {
                return NotFound();
            }
            var rezervation = await _context.Rez.FindAsync(id);

            if (rezervation != null)
            {
                Rezervation = rezervation;
                _context.Rez.Remove(Rezervation);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
