using Microsoft.EntityFrameworkCore;
using MyContactBook.Models;

namespace MyContactBook.Database
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Person> Contacts { get; set; }
    }
}
