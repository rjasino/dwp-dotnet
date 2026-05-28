using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) //passing of values to the base class constructor
        {
            
        }

        public DbSet<Game> Games { get; set; }
    }
}
