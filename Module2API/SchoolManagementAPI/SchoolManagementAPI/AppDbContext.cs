using Microsoft.EntityFrameworkCore;
using SchoolManagementAPI.Models;
namespace SchoolManagementAPI
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):
            base(options)
        {
            
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Student> Students { get; set; }
    }
}
