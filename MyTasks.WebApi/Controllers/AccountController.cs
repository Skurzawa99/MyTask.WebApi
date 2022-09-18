using LoggerService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using MyTasks.WebApi.Core.Services;
using MyTasks.WebApi.Models;
using MyTasks.WebApi.Models.Converters;
using MyTasks.WebApi.Models.Domains;
using MyTasks.WebApi.Models.Dtos;
using MyTasks.WebApi.Models.Response;
using MyTasks.WebApi.Services;

namespace MyTasks.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly ILoggerManager _logger;

        public AccountController(IAccountService accountService, ILoggerManager logger)
        {
            _accountService = accountService;
            _logger = logger;
        }

        [HttpPost("register")]
        public DataResponse<int> RegisterUser(RegisterUserDto userDto)
        {
            var response = new DataResponse<int>();
            try
            {
                _accountService.RegisterUser(userDto);
                response.Data = userDto.Id;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response.Errors.Add(new Error(ex.Source, ex.Message));
            };

            return response;
        }

        [HttpPost("login")]
        public DataResponse<string> LoginUser(LoginDto userDto)
        {
            var response = new DataResponse<string>();
            try
            {
                string token = _accountService.GenerateJwt(userDto);
                response.Data = token;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response.Errors.Add(new Error(ex.Source, ex.Message));
            };

            return response;
        }
    }
}
