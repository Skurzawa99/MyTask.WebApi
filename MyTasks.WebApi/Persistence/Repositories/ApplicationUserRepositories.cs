using Microsoft.AspNetCore.Identity;
using MyTasks.WebApi.Core;
using MyTasks.WebApi.Core.Repositories;
using MyTasks.WebApi.Models.Domains;
using MyTasks.WebApi.Models.Dtos;

namespace MyTasks.WebApi.Models.Repositories
{
    public class ApplicationUserRepositories : IApplicationUserRepositories
    {
        private readonly IApplicationDbContext _context;

        public ApplicationUserRepositories(IApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(ApplicationUser user)
        {
            _context.ApplicationUsers.Add(user);
        }

        public ApplicationUser Get(LoginDto user)
        {
            return _context.ApplicationUsers.FirstOrDefault(x => x.Name == user.Name);
        }
    }
}
