using Microsoft.EntityFrameworkCore;
using WebApplicationTest.Models;

namespace WebApplicationTest.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Client> Client { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Purchase> Purchase { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Position> Position { get; set; }
    }
}
