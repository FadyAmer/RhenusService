using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Rhenus_Special_Delivery.DataAccess.Players.Models;


namespace Rhenus_Special_Delivery.DataAccess
{
    public class RhenusContext : DbContext
    {
        public DbSet<Player> Players { get; set; }
        private readonly string dbName = "RhenusDatabase";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(dbName);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Player>().HasData(
                new Player
                {
                    Id = "84693b55-2521-406e-ac87-87cc6dec7a57",
                    Points = 1000,
                    Username = "Fady Amir"
                },
                new Player
                    {
                        Id = "7e20148a-335d-4775-9257-1238a17b9074",
                        Points = 10000,
                        Username = "John Amir"
                }
            );
        }
    }
}