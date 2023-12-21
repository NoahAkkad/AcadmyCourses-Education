using Microsoft.EntityFrameworkCore;
using CoursesAppMVC.Models;

namespace CoursesAppMVC.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<CourseItem> Courses { get; set; }
    }
}
