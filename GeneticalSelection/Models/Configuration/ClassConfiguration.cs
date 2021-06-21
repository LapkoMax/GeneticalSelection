using GeneticalSelection.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeneticalSelection.Models.Configuration
{
    public class ClassConfiguration : IEntityTypeConfiguration<Class>
    {
        public void Configure(EntityTypeBuilder<Class> builder)
        {
            builder.HasData(
                new Class
                {
                    Id = 1,
                    Name = "Mammal",
                    LatinName = "Mamma",
                    Description = "Group of verteble animals.",
                    SubphylumId = 1
                },
                new Class
                {
                    Id = 2,
                    Name = "Dicotyledonae",
                    LatinName = "Dicotyledon",
                    Description = "Are one of the two groups into which all the flowering plants or angiosperms were formerly divided.",
                    SubphylumId = 2
                }
            );
        }
    }
}
