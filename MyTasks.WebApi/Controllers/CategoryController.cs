using LoggerService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyTasks.WebApi.Core.Services;
using MyTasks.WebApi.Models;
using MyTasks.WebApi.Models.Converters;
using MyTasks.WebApi.Models.Domains;
using MyTasks.WebApi.Models.Dtos;
using MyTasks.WebApi.Models.Response;
using MyTasks.WebApi.Models.Services;

namespace MyTasks.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly ILoggerManager _logger;

        public CategoryController(ICategoryService categoryService, ILoggerManager logger)
        {
            _categoryService = categoryService;
            _logger = logger;
        }


        [HttpGet]
        public DataResponse<IEnumerable<CategoryDto>> Get()
        {
            var response = new DataResponse<IEnumerable<CategoryDto>>();

            try
            {
                response.Data = _categoryService.Get().ToDtos();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response.Errors.Add(new Error(ex.Source, ex.Message));
            }

            return response;
        }

        [HttpGet("{id}")]
        public DataResponse<CategoryDto> Get(int id)
        {
            var response = new DataResponse<CategoryDto>();

            try
            {
                response.Data = _categoryService.Get(id).ToDto();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response.Errors.Add(new Error(ex.Source, ex.Message));
            }

            return response;
        }

        [HttpPost]
        public DataResponse<int> Add(CategoryDto categoryDto)
        {
            var response = new DataResponse<int>();

            try
            {
                var category = categoryDto.ToDao();
                _categoryService.Add(category);
                response.Data = category.Id;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response.Errors.Add(new Error(ex.Source, ex.Message));
            }

            return response;
        }

        [HttpPut]
        public Response Update(CategoryDto categoryDto)
        {
            var response = new Response();

            try
            {
                var category = categoryDto.ToDao();
                _categoryService.Update(category);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response.Errors.Add(new Error(ex.Source, ex.Message));
            }

            return response;
        }

        [HttpDelete("{id}")]
        public Response Delete(int id)
        {
            var response = new Response();

            try
            {
                _categoryService.Delete(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response.Errors.Add(new Error(ex.Source, ex.Message));
            }

            return response;
        }

    }
}
