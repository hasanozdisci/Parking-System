using Microsoft.EntityFrameworkCore;
using ParkingApp_Core.Models;

namespace ParkingWebApi.Data
{
    public class ParkingSystemDbContext : DbContext
    {
        public ParkingSystemDbContext(DbContextOptions<ParkingSystemDbContext> options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Score> Scores { get; set; }
        public DbSet<Park> Parks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=ParkingSystemDb;Integrated Security=True;");
        }
    }
}
