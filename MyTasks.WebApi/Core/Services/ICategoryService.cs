using MyTasks.WebApi.Models.Domains;

namespace MyTasks.WebApi.Core.Services
{
    public interface ICategoryService
    {
        IEnumerable<Category> Get();
        Category Get(int id);
        void Add(Category category);
        void Update(Category category);
        void Delete(int id);

    }
}
