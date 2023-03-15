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
    public class ReturnModel : PageModel
    {
        public IList<Rezervation> ReservationsWithCarDetails { get;set; } = default!;
        private readonly RazorRentCarDemo_NetCore.Data.RentDbContext _context;

        public ReturnModel(RazorRentCarDemo_NetCore.Data.RentDbContext context)
        {
            _context = context;
        }


        public void OnGet()
        {
            //if (_context.Car != null)
            //{
            //    Car = await _context.Car.Where(c => c.Avaliable ==false).ToListAsync(); //where linq tanım olarak; Öyle arabalar getir ki avaliable false olsun
            //}

            ReservationsWithCarDetails = _context
                .Rez
                .Include(c => c.Car) // include = dahil et (Sql de ki JOIN görevi)
                .Where(r => r.End == DateTime.MinValue)
                .ToList();
        }
    }
}
