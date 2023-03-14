using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RazorRentCarDemo_NetCore.Model;

namespace RazorRentCarDemo_NetCore.Data
{
    public class RentDbContext : DbContext
    {
        public RentDbContext (DbContextOptions<RentDbContext> options)
            : base(options)
        {
        }

        public DbSet<Car> Car { get; set; } = default!;

        
        //convercion
        //attriburete
        //fluent api bu 3.den biri ile default değerini ayarlayabiliriz. Biz aşağıda fluent api ile yaptık


        //Fluent API
        //Avaliable değişkeninin default değerini true yaptık
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>()
                .Property(b => b.Avaliable)
                .HasDefaultValue(true);
        }
    }
}
