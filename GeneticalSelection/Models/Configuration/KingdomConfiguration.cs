using GeneticalSelection.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeneticalSelection.Models.Configuration
{
    public class KingdomConfiguration : IEntityTypeConfiguration<Kingdom>
    {
        public void Configure(EntityTypeBuilder<Kingdom> builder)
        {
            builder.HasData(
                new Kingdom
                {
                    Id = 1,
                    Name = "Animals",
                    LatinName = "Animalia",
                    Description = "Multicellular eukaryotic organisms."
                },
                new Kingdom
                {
                    Id = 2,
                    Name = "Plants",
                    LatinName = "Plantae",
                    Description = "Mainly multicellular organisms, predominantly photosynthetic aukaryotes."
                }
            );
        }
    }
}
