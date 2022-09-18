using MyTasks.WebApi.Models.Domains;
using MyTasks.WebApi.Models.Dtos;

namespace MyTasks.WebApi.Core.Repositories
{
    public interface IApplicationUserRepositories
    {
        void Add(ApplicationUser user);
        ApplicationUser Get(LoginDto user);
    }
}
