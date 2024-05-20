using EntityFrameworkDemo.Models;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkDemo.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<Employee> Employees { get; set; }
        
        public DbSet<Student> Students { get; set; }

        public DbSet<Book> Books { get; set; }

        public DbSet<Product> Products { get; set; }
    }
}
