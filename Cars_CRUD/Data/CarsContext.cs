using Cars_CRUD.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cars_CRUD.Data
{
    public class CarsContext : DbContext
    {
        public CarsContext(DbContextOptions<CarsContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CarImpactClass>()
                .Property(p => p.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<CarProbabilityClass>()
                .Property(p => p.Id)
                .ValueGeneratedOnAdd();
        }

        public DbSet<Report> Reports { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<CarCategory> CarCategories { get; set; }
        public DbSet<CarImpactClass> CarImpactClasses { get; set; }
        public DbSet<CarProbabilityClass> CarProbabilityClasses { get; set; }
        public DbSet<Area> Areas { get; set; }
        public DbSet<Garage> Garages { get; set; }
    }
}
