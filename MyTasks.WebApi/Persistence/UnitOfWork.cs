using MyTasks.WebApi.Core;
using MyTasks.WebApi.Core.Repositories;
using MyTasks.WebApi.Models.Domains;
using MyTasks.WebApi.Models.Repositories;

namespace MyTasks.WebApi.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IApplicationDbContext _context;

        public UnitOfWork(IApplicationDbContext context)
        {
            _context = context;
            Tasks = new TasksRepositories(context);
            Categories = new CategoryRepositories(context);
            ApplicationUsers = new ApplicationUserRepositories(context);
        }

        public ITasksRepositories Tasks { get; }
        public ICategoryRepositories Categories { get; }
        public IApplicationUserRepositories ApplicationUsers { get; }

        public void Complete()
        {
            _context.SaveChanges();
        }

    }
}
