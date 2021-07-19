using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiNetCore5.Data;

namespace WebApiNetCore5.Configurations.Entities
{
    public class HotelConfiguration : IEntityTypeConfiguration<Hotel>
    {
        
        public void Configure(EntityTypeBuilder<Hotel> builder)
        {
            builder.HasData(
                new Hotel { Id = 1, Name = "Hotel Santi Niketon", Address = "Bohorom Pur", CountryId = 1, Rating = 4.8 },
                new Hotel { Id = 2, Name = "Hotel Islamabad", Address = "Islamabad", CountryId = 2, Rating = 4.7 },
                new Hotel { Id = 3, Name = "Hotel Sonar Bangla", Address = "Coxs Bazar", CountryId = 3, Rating = 4.8 }
                );
        }
    }
}
