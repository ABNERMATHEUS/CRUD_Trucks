using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TrucksProject.Domain.Entities;
using TrucksProject.Domain.Enums;

namespace TrucksProject.Infra.DataContext
{
    public class Context : DbContext
    {

        public DbSet<Truck> Truck { get; set; }
        public DbSet<ModelTruck> ModelTruck { get; set; }

        public Context( DbContextOptions<Context> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Entity ModelTruck
            modelBuilder.Entity<ModelTruck>().HasKey(x => x.Name);
            modelBuilder.Entity<ModelTruck>().Property(x => x.Name).HasConversion(x => x.ToString(), x => (ETrucksModel)Enum.Parse(typeof(ETrucksModel), x));
            modelBuilder.Entity<ModelTruck>().HasMany(x => x.Trucks).WithOne(x => x.ModelTruck).HasForeignKey(x => x.IdModelTruck).IsRequired();
            
            #endregion

            #region Entity Truck
            modelBuilder.Entity<Truck>().HasKey(t => t.Id);
            modelBuilder.Entity<Truck>().Property(t => t.YearFabrication).HasMaxLength(4).IsRequired();
            modelBuilder.Entity<Truck>().Property(t => t.YearModel).HasMaxLength(4).IsRequired();
            modelBuilder.Entity<Truck>().HasOne(t => t.ModelTruck).WithMany(x=> x.Trucks).HasForeignKey(t => t.IdModelTruck).IsRequired();
            #endregion

            modelBuilder.Entity<ModelTruck>().HasData(
                new ModelTruck(ETrucksModel.FH),
                new ModelTruck(ETrucksModel.FM)
            );
        }
    }
}
