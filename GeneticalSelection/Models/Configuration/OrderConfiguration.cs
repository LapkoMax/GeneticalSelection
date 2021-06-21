using GeneticalSelection.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeneticalSelection.Models.Configuration
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasData(
                new Order
                {
                    Id = 1,
                    Name = "Carnivora",
                    LatinName = "Carnivora",
                    Description = "Specialized in primary eating flesh.",
                    ClassId = 1
                },
                new Order
                {
                    Id = 2,
                    Name = "Asterales",
                    LatinName = "Asterales",
                    Description = "Composite flowers made of florets.",
                    ClassId = 2
                }
            );
        }
    }
}
