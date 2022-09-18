using Microsoft.EntityFrameworkCore;
using MyTasks.WebApi.Core;
using MyTasks.WebApi.Core.Services;
using MyTasks.WebApi.Models.Domains;
using MyTasks.WebApi.Persistence;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MyTasks.WebApi.Models.Services
{
    public class TasksService : ITasksService
    {
        private readonly IUnitOfWork _unitOfWork;

        public TasksService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<Tasks> Get(string userId)
        {
            return _unitOfWork.Tasks.Get(userId);
        }

        public Tasks Get(int id, string userId)
        {
            return _unitOfWork.Tasks.Get(id, userId);
        }

        public void Add(Tasks tasks)
        {
            _unitOfWork.Tasks.Add(tasks);
            _unitOfWork.Complete();
        }

        public void Update(Tasks tasks, string userId)
        {
            _unitOfWork.Tasks.Update(tasks, userId);
            _unitOfWork.Complete();
        }

        public void Delete(int id, string userId)
        {
            _unitOfWork.Tasks.Delete(id, userId);
            _unitOfWork.Complete();
        }

        public void Finish(int id, string userId)
        {
            _unitOfWork.Tasks.Finish(id, userId);
            _unitOfWork.Complete();
        }
    }
}

