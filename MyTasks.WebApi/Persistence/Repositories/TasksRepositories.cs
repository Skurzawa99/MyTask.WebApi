using MyTasks.WebApi.Core;
using MyTasks.WebApi.Core.Repositories;
using MyTasks.WebApi.Models.Domains;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MyTasks.WebApi.Models.Repositories
{
    public class TasksRepositories : ITasksRepositories
    {
        private readonly IApplicationDbContext _context;

        public TasksRepositories(IApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Tasks> Get(string userId)
        {
            return _context.Tasks.Where(x => x.UserId == userId);
        }

        public Tasks Get(int id, string userId)
        {
            return _context.Tasks.Where(x => x.Id == id && x.UserId == userId).FirstOrDefault();
        }

        public void Add(Tasks task)
        {
            _context.Tasks.Add(task);
        }

        public void Update(Tasks task, string userId)
        {
            var taskToUpdate = _context.Tasks.Where(x => x.Id == task.Id).FirstOrDefault();

            if (taskToUpdate.UserId != userId)
            {
                throw new Exception("Nie można edytować nieswojego zadania.");
            }

            taskToUpdate.Title = task.Title;
            taskToUpdate.Description = task.Description;
            taskToUpdate.CategoryId = task.CategoryId;
            taskToUpdate.IsExecuted = task.IsExecuted;
        }

        public void Delete(int id, string userId)
        {
            var taskToDelete = _context.Tasks.Where(x => x.Id == id).FirstOrDefault();

            if(taskToDelete.UserId != userId)
            {
                throw new Exception("Nie można usunąć nieswojego zadania.");
            }

            _context.Tasks.Remove(taskToDelete);
        }

        public void Finish(int id, string userId)
        {
            var taskToFinish = _context.Tasks.Where(x => x.Id == id).FirstOrDefault();

            if (taskToFinish.UserId != userId)
            {
                throw new Exception("Nie można zakończyć nieswojego zadania.");
            }

            taskToFinish.IsExecuted = true;
        }
    }
}
