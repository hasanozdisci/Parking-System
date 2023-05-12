using Microsoft.EntityFrameworkCore;
using ParkingWebApi.Models;

namespace ParkingWebApi.Data
{
    public class ParkingSystemDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Score> Scores { get; set; }
        public DbSet<Car> Cars { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=ParkingSystemDb;Integrated Security=True;");
        }
    }
}
