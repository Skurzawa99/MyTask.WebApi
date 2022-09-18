using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.Internal;
using MyTasks.WebApi.Models.Domains;
using MyTasks.WebApi.Models.Dtos;
using MyTasks.WebApi.Models.Converters;
using MyTasks.WebApi.Models.Response;
using System.Threading.Tasks;
using MyTasks.WebApi.Models;
using MyTasks.WebApi.Models.Services;
using MyTasks.WebApi.Core.Services;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using MyTasks.WebApi.Persistence.Extensions;
using LoggerService;

namespace MyTasks.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TasksController : ControllerBase
    {
        private readonly ITasksService _taskservice;
        private readonly ILoggerManager _logger;

        public TasksController(ITasksService taskservice, ILoggerManager logger)
        {
            _taskservice = taskservice;
            _logger = logger;
        }

        [HttpGet]
        public DataResponse<IEnumerable<TasksDto>> Get()
        {
            var response = new DataResponse<IEnumerable<TasksDto>>();
            var userId = User.GetUserId();

            try
            {
                response.Data = _taskservice.Get(userId).ToDtos();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response.Errors.Add(new Error(ex.Source, ex.Message));
            }

            return response;
        }

        [HttpGet("{id}")]
        public DataResponse<TasksDto> Get(int id)
        {
            var response = new DataResponse<TasksDto>();
            var userId = User.GetUserId();

            try
            {
                response.Data = _taskservice.Get(id, userId).ToDto();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response.Errors.Add(new Error(ex.Source, ex.Message));
            }

            return response;
        }

        [HttpPost]
        public DataResponse<int> Add(TasksDto tasksDto)
        {
            var response = new DataResponse<int>();
            tasksDto.UserId = User.GetUserId();
            try
            {
                var task = tasksDto.ToDao();
                _taskservice.Add(task);
                response.Data = tasksDto.Id;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response.Errors.Add(new Error(ex.Source, ex.Message));
            }

            return response;
        }

        [HttpPut]
        public Response Update(TasksDto tasksDto)
        {
            var response = new Response();
            var userId = User.GetUserId();

            try
            {
                var task = tasksDto.ToDao();
                _taskservice.Update(task, userId);
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
            var userId = User.GetUserId();

            try
            {
                _taskservice.Delete(id, userId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response.Errors.Add(new Error(ex.Source, ex.Message));
            }

            return response;
        }

        [HttpPut("{id}")]
        public Response Finish(int id)
        {
            var response = new Response();
            var userId = User.GetUserId();

            try
            {
                _taskservice.Finish(id, userId);
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
