using GeneticalSelection.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeneticalSelection.Models.Configuration
{
    public class GenusConfiguration : IEntityTypeConfiguration<Genus>
    {
        public void Configure(EntityTypeBuilder<Genus> builder)
        {
            builder.HasData(
                new Genus
                {
                    Id = 1,
                    Name = "Canis",
                    LatinName = "Canis",
                    Description = "Genus of the Caninae containing multiple extant species.",
                    FamilyId = 1
                },
                new Genus
                {
                    Id = 2,
                    Name = "Helianthus",
                    LatinName = "Helianthus",
                    Description = "Genus comprising about 70 species of annual and perennial flowering plants.",
                    FamilyId = 2
                }
            );
        }
    }
}
