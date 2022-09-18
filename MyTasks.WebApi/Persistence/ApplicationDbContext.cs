using Microsoft.EntityFrameworkCore;
using MyTasks.WebApi.Core;

namespace MyTasks.WebApi.Models.Domains
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
        }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Tasks> Tasks { get; set; }
    }
}
