using GeneticalSelection.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeneticalSelection.Models.Configuration
{
    public class FamilyConfiguration : IEntityTypeConfiguration<Family>
    {
        public void Configure(EntityTypeBuilder<Family> builder)
        {
            builder.HasData(
                new Family
                {
                    Id = 1,
                    Name = "Canidae",
                    LatinName = "Canidae",
                    Description = "Dog-like carnivorans.",
                    OrderId = 1
                },
                new Family
                {
                    Id = 2,
                    Name = "Asceraceae",
                    LatinName = "Asceraceae",
                    Description = "One of the largest families of dicotyledonous plants.",
                    OrderId = 2
                }
            );
        }
    }
}
