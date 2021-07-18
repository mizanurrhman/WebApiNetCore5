using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiNetCore5.Controllers.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options)
        { }




        public DbSet<Country> Countries { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Country>().HasData(
                new Country { Id = 1, Name = "India", ShortName = "In" },
                new Country { Id = 2, Name = "Pakistan", ShortName = "Pa" },
                new Country { Id = 3, Name = "Bangladesh", ShortName = "Ba" }
                );
            builder.Entity<Hotel>().HasData(
                new Hotel { Id = 1, Name = "Hotel Santi Niketon", Address = "Bohorom Pur", CountryId = 1, Rating = 4.8 },
                new Hotel { Id = 2, Name = "Hotel Islamabad", Address = "Islamabad", CountryId = 2, Rating = 4.7 },
                new Hotel { Id = 3, Name = "Hotel Sonar Bangla", Address = "Coxs Bazar", CountryId = 3, Rating = 4.8 }
                );
        }


    }
}
