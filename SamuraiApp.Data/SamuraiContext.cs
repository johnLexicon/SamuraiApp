using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using SamuraiApp.Domain;

namespace SamuraiApp.Data
{
    public class SamuraiContext : DbContext
    {
        //Solution using ASP.NET DI.
        public SamuraiContext(DbContextOptions<SamuraiContext> options) : base(options)
        {
        }

        public DbSet<Samurai> Samurais { get; set; }
        public DbSet<Quote> Quotes { get; set; }
        public DbSet<Battle> Battles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SamuraiBattle>().HasKey(sb => new { sb.BattleId, sb.SamuraiId });
            //modelBuilder.Entity<Samurai>().Property(s => s.SecretIdentity).IsRequired();

            base.OnModelCreating(modelBuilder);
        }

        //Solution without DI
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=SamuraiDbContext;Trusted_Connection=True;MultipleActiveResultSets=true");
        //    base.OnConfiguring(optionsBuilder);
        //}
    }
}
