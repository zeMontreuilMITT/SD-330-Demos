using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SD_330_Demos.Models;

namespace SD_330_Demos.Data
{
    public class SD_330_DemosContext : DbContext
    {
        public SD_330_DemosContext (DbContextOptions<SD_330_DemosContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Organism>()
                .HasDiscriminator<string>("organism_type")
                .HasValue<Animal>("organism_animal")
                .HasValue<Plant>("organism_plant");
        }

        public DbSet<Plant> Plant { get; set; } = default!;
        public DbSet<Animal> Animal { get; set; } = default!;

        public DbSet<Diet> Diets { get; set; } = default!;
        public DbSet<Food> Foods { get; set;} = default!;

        // table per heirarchy
        // table per class
    }
}
