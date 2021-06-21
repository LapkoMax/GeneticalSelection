using GeneticalSelection.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeneticalSelection.Models.Configuration
{
    public class SubphylumConfiguration : IEntityTypeConfiguration<Subphylum>
    {
        public void Configure(EntityTypeBuilder<Subphylum> builder)
        {
            builder.HasData(
                new Subphylum
                {
                    Id = 1,
                    Name = "Vertebrates",
                    LatinName = "Vertebrata",
                    Description = "Chordates with backbones.",
                    PhylumId = 1
                },
                new Subphylum
                {
                    Id = 2,
                    Name = "Flowering plant",
                    LatinName = "Angiospermae",
                    Description = "Most diverse group of land plants.",
                    PhylumId = 2
                }
            );
        }
    }
}
