using MyTasks.WebApi.Models.Dtos;

namespace MyTasks.WebApi.Core.Services
{
    public interface IAccountService
    {
        string GenerateJwt(LoginDto dto);
        void RegisterUser(RegisterUserDto dto);
    }
}
