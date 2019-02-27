using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using SamuraiApp.Domain;

namespace SamuraiApp.Data
{
    public class SamuraiContext : DbContext
    {

        public static readonly LoggerFactory MyConsoleLoggerFactory
           = new LoggerFactory(new[] {
              new ConsoleLoggerProvider((category, level)
                => category == DbLoggerCategory.Database.Command.Name
               && level == LogLevel.Information, true) });

        //Solution using ASP.NET DI.
        //public SamuraiContext(DbContextOptions<SamuraiContext> options) : base(options)
        //{
        //}


        public DbSet<Samurai> Samurais { get; set; }
        public DbSet<Quote> Quotes { get; set; }
        public DbSet<Battle> Battles { get; set; }

        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SamuraiBattle>().HasKey(sb => new { sb.BattleId, sb.SamuraiId });
            //modelBuilder.Entity<Samurai>().Property(s => s.SecretIdentity).IsRequired();


            /***  Model Seed Data  ***/

            //When applying model seed data the Id for the entity must be given explicit.
            //Use negative values for the Id:s so it will not collide with records created by the application.

            modelBuilder.Entity<Samurai>().HasData(
                new Samurai { Id = -1, Name = "Kikuchiyo" },
                new Samurai { Id = -2, Name = "Kambei Shimada" },
                new Samurai { Id = -3, Name = "Shichirōji " },
                new Samurai { Id = -4, Name = "Katsushirō Okamoto" },
                new Samurai { Id = -5, Name = "Heihachi Hayashida" },
                new Samurai { Id = -6, Name = "Kyūzō" },
                new Samurai { Id = -7, Name = "Gorōbei Katayama" }
            );

            modelBuilder.Entity<Battle>().HasData(
                new Battle { Id = -1, Name = "Battle of Okehazama", StartDate = new DateTime(1560, 05, 01), EndDate = new DateTime(1560, 06, 15) },
                new Battle { Id = -2, Name = "Battle of Shiroyama", StartDate = new DateTime(1877, 9, 24), EndDate = new DateTime(1877, 9, 24) },
                new Battle { Id = -3, Name = "Siege of Osaka", StartDate = new DateTime(1614, 1, 1), EndDate = new DateTime(1615, 12, 31) },
                new Battle { Id = -4, Name = "Boshin War", StartDate = new DateTime(1868, 1, 1), EndDate = new DateTime(1869, 1, 1) }
            );


            //base.OnModelCreating(modelBuilder);
        }

        //Solution without DI
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseLoggerFactory(MyConsoleLoggerFactory)
                .UseSqlServer("Data Source=localhost;Initial Catalog=SamuraiDb;User ID=sa;Password=[iatgoat42]")
                .EnableSensitiveDataLogging(true);
            //optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=SamuraiDbContext;Trusted_Connection=True;MultipleActiveResultSets=true");
            //base.OnConfiguring(optionsBuilder);
        }
    }
}
