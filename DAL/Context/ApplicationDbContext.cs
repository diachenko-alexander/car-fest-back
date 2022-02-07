using CarFest.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Car> Cars { get; set; }
                
    }
}
