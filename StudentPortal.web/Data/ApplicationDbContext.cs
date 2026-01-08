using Microsoft.EntityFrameworkCore;
using StudentPortal.web.Models.Table;
using StudentPortal.web.Models;

namespace StudentPortal.web.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options): base(options)
        {
            
        }
        public DbSet<Student> Students{ get; set; }
    }
}
