using GeneticalSelection.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeneticalSelection.Models.Configuration
{
    public class PhylumConfiguration : IEntityTypeConfiguration<Phylum>
    {
        public void Configure(EntityTypeBuilder<Phylum> builder)
        {
            builder.HasData(
                new Phylum
                {
                    Id = 1,
                    Name = "Chordate",
                    LatinName = "Chordata",
                    Description = "Has chorda.",
                    KingdomId = 1
                },
                new Phylum
                {
                    Id = 2,
                    Name = "Vascular plant",
                    LatinName = "Vasculum",
                    Description = "Land plants with lignified tissues.",
                    KingdomId = 2
                }
            );
        }
    }
}
