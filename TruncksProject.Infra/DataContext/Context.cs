using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TruncksProject.Domain.Entities;
using TruncksProject.Domain.Enums;

namespace TruncksProject.Infra.DataContext
{
    public class Context : DbContext
    {

        public DbSet<Trunck> Trunck { get; set; }
        public DbSet<ModelTrunck> ModelTrunck { get; set; }

        public Context( DbContextOptions<Context> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Entity ModelTrunck
            modelBuilder.Entity<ModelTrunck>().HasKey(x => x.Name);
            modelBuilder.Entity<ModelTrunck>().Property(x => x.Name).HasConversion(x => x.ToString(), x => (ETruncksModel)Enum.Parse(typeof(ETruncksModel), x));
            modelBuilder.Entity<ModelTrunck>().HasMany(x => x.Truncks).WithOne(x => x.ModelTrunck).HasForeignKey(x => x.IdModelTrunck).IsRequired();
            
            #endregion

            #region Entity Trunck
            modelBuilder.Entity<Trunck>().HasKey(t => t.Id);
            modelBuilder.Entity<Trunck>().Property(t => t.YearFabrication).HasMaxLength(4).IsRequired();
            modelBuilder.Entity<Trunck>().Property(t => t.YearModel).HasMaxLength(4).IsRequired();
            modelBuilder.Entity<Trunck>().HasOne(t => t.ModelTrunck).WithMany(x=> x.Truncks).HasForeignKey(t => t.IdModelTrunck).IsRequired();
            #endregion

            modelBuilder.Entity<ModelTrunck>().HasData(
                new ModelTrunck(ETruncksModel.FH),
                new ModelTrunck(ETruncksModel.FM)
            );
        }
    }
}
