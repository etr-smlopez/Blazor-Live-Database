using Microsoft.EntityFrameworkCore;

namespace Blazor.Live.Database.Data
{
    public class AppDbContext : DbContext
    {
        string _connectionString = "Server=DESKTOP-PK86BAT;Database=ETR-IS-PGA-TEST;User Id=awit;Password=awit;Trusted_Connection=True;MultipleActiveResultSets=true";
      
        public DbSet<Employees> Employees { get; set; }
   
        public DbSet<vwProvince> vwProvince { get; set; }

         
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}
