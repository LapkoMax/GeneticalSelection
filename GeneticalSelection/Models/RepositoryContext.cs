using GeneticalSelection.Models.Configuration;
using GeneticalSelection.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeneticalSelection.Models
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions options)
            : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new KingdomConfiguration());
            modelBuilder.ApplyConfiguration(new PhylumConfiguration());
            modelBuilder.ApplyConfiguration(new SubphylumConfiguration());
            modelBuilder.ApplyConfiguration(new ClassConfiguration());
            modelBuilder.ApplyConfiguration(new OrderConfiguration());
            modelBuilder.ApplyConfiguration(new FamilyConfiguration());
            modelBuilder.ApplyConfiguration(new GenusConfiguration());
            modelBuilder.ApplyConfiguration(new SpeciesConfiguration());
        }
        public DbSet<Kingdom> Kingdoms { get; set; }
        public DbSet<Phylum> Phylums { get; set; }
        public DbSet<Subphylum> Subphylums { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Family> Families { get; set; }
        public DbSet<Genus> Genuses { get; set; }
        public DbSet<Species> Species { get; set; }
    }
}
