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
    public class CountryConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.HasData(
                new Country { Id = 1, Name = "India", ShortName = "In" },
                new Country { Id = 2, Name = "Pakistan", ShortName = "Pa" },
                new Country { Id = 3, Name = "Bangladesh", ShortName = "Ba" }
                );
        }
    }
}
