using MyTasks.WebApi.Models.Domains;

namespace MyTasks.WebApi.Core.Repositories
{
    public interface ICategoryRepositories
    {
        IEnumerable<Category> Get();
        Category Get(int id);
        void Add(Category category);
        void Update(Category category);
        void Delete(int id);
    }
}
