using Computer_Peripheral___Stock_Management.Model;
using Microsoft.EntityFrameworkCore;

namespace Computer_Peripheral___Stock_Management.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext>options) : base(options)
        {
            
        }

        public DbSet<Peripheral> peripherals { get; set; }
    }
}
