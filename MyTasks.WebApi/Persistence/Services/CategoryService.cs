using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyTasks.WebApi.Core;
using MyTasks.WebApi.Core.Services;
using MyTasks.WebApi.Models.Converters;
using MyTasks.WebApi.Models.Domains;
using MyTasks.WebApi.Models.Dtos;
using MyTasks.WebApi.Models.Response;
using MyTasks.WebApi.Persistence;

namespace MyTasks.WebApi.Models.Services
{

    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<Category> Get()
        {
            return _unitOfWork.Categories.Get();
        }

        public Category Get(int id)
        {
            return _unitOfWork.Categories.Get(id);
        }

        public void Add(Category category)
        {
            _unitOfWork.Categories.Add(category);
            _unitOfWork.Complete();
        }

        public void Update(Category category)
        {
            _unitOfWork.Categories.Update(category);
            _unitOfWork.Complete();
        }

        public void Delete(int id)
        {
            _unitOfWork.Categories.Delete(id);
            _unitOfWork.Complete();
        }
    }
}
