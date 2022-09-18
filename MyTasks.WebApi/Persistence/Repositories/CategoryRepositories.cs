using MyTasks.WebApi.Core;
using MyTasks.WebApi.Core.Repositories;
using MyTasks.WebApi.Models.Domains;

namespace MyTasks.WebApi.Models.Repositories
{
    public class CategoryRepositories : ICategoryRepositories
    {
        private readonly IApplicationDbContext _context;

        public CategoryRepositories(IApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Category> Get()
        {
            return _context.Categories;
        }

        public Category Get(int id)
        {
            return _context.Categories.Where(x => x.Id == id).FirstOrDefault();
        }

        public void Add(Category category)
        {
            _context.Categories.Add(category);
        }

        public void Update(Category category)
        {
            var categoryToUpdate = _context.Categories.Where(x => x.Id == category.Id).FirstOrDefault();

            categoryToUpdate.Name = category.Name;
        }

        public void Delete(int id)
        {
            var categoryToDelete = _context.Categories.Where(x => x.Id == id).FirstOrDefault();

            _context.Categories.Remove(categoryToDelete);
        }
    }
}
