using MyTasks.WebApi.Models.Domains;

namespace MyTasks.WebApi.Core.Repositories
{
    public interface ITasksRepositories
    {
        IEnumerable<Tasks> Get(string userId);
        Tasks Get(int id, string userId);
        void Add(Tasks task);
        void Update(Tasks task, string userId);
        void Delete(int id, string userId);
        void Finish(int id, string userId);
    }
}
