using dotnet7_webapi.Models;
using Microsoft.EntityFrameworkCore;

namespace dotnet7_webapi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions <DataContext> options) : base(options)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=127.0.0.1,1433;Database=superhero;User Id=SA;TrustServerCertificate=true;Password=Password123") ;
        }

        public DbSet<SuperHero> SuperHeroes { get; set; }
    }
}
