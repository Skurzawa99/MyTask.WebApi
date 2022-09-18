using MyTasks.WebApi.Models.Domains;

namespace MyTasks.WebApi.Core.Services
{
    public interface ITasksService
    {
        IEnumerable<Tasks> Get(string userId);
        Tasks Get(int id, string userId);
        void Add(Tasks tasks);
        void Update(Tasks task, string userIds);
        void Delete(int id, string userId);
        void Finish(int id, string userId);
    }
}
