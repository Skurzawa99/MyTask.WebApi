using Microsoft.EntityFrameworkCore;
using MyTasks.WebApi.Models.Domains;

namespace MyTasks.WebApi.Core
{
    public interface IApplicationDbContext
    {
        DbSet<Category> Categories { get; set; }
        DbSet<ApplicationUser> ApplicationUsers { get; set; }
        DbSet<Tasks> Tasks { get; set; }
        int SaveChanges();
    }
}
