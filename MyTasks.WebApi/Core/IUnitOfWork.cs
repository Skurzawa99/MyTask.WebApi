using MyTasks.WebApi.Core.Repositories;
using MyTasks.WebApi.Models.Repositories;

namespace MyTasks.WebApi.Core
{
    public interface IUnitOfWork
    {
        ITasksRepositories Tasks { get; }
        ICategoryRepositories Categories { get; }
        IApplicationUserRepositories ApplicationUsers { get; }

        void Complete();
    }
}
