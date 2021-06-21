using GeneticalSelection.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeneticalSelection.Models.Configuration
{
    public class SpeciesConfiguration : IEntityTypeConfiguration<Species>
    {
        public void Configure(EntityTypeBuilder<Species> builder)
        {
            builder.HasData(
                new Species
                {
                    Id = 1,
                    Name = "Gray Wolf",
                    LatinName = "Canis lupus",
                    Description = "Is a large canine native to Eurasia and North America.",
                    GenusId = 1
                },
                new Species
                {
                    Id = 2,
                    Name = "Sunflower",
                    LatinName = "Helianthus",
                    Description = "The common names sunflower and common sunflower typically refer to the popular annual species Helianthus annuus.",
                    GenusId = 2
                }
            );
        }
    }
}
