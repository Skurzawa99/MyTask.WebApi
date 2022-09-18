using Microsoft.AspNetCore.Mvc;
using MyTasks.WebApi.Models.Dtos;
using MyTasks.WebApi.Models.Response;
using MyTasks.WebApi.Models.Converters;
using Microsoft.AspNetCore.Identity;
using MyTasks.WebApi.Models.Domains;
using MyTasks.WebApi.Models;
using MyTasks.WebApi.Core.Services;
using MyTasks.WebApi.Persistence;
using MyTasks.WebApi.Core;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;

namespace MyTasks.WebApi.Services
{
    public class AccountService : IAccountService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPasswordHasher<ApplicationUser> _passwordHasher;
        private readonly AuthenticationSettings _authenticationSettings;

        public AccountService(IUnitOfWork unitOfWork, IPasswordHasher<ApplicationUser> passwordHasher, AuthenticationSettings authenticationSettings)
        {
            _unitOfWork = unitOfWork;
            _passwordHasher = passwordHasher;
            _authenticationSettings = authenticationSettings;
        }

        public void RegisterUser(RegisterUserDto userDto)
        {
            var user = new ApplicationUser { Name = userDto.Name };
            var hashedPassword = _passwordHasher.HashPassword(user, userDto.Password);
            user.Password = hashedPassword;

            _unitOfWork.ApplicationUsers.Add(user);
            _unitOfWork.Complete();
        }

        public string GenerateJwt(LoginDto dto)
        {
            var user = _unitOfWork.ApplicationUsers.Get(dto);

            if(user is null)
            {
                throw new Exception("Błędne hasło lub nazwa uzytkownika");
            }

            var result = _passwordHasher.VerifyHashedPassword(user, user.Password, dto.Password);

            if(result == PasswordVerificationResult.Failed)
            {
                throw new Exception("Błędne hasło lub nazwa uzytkownika");
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Name)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_authenticationSettings.JwtKey));
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddDays(_authenticationSettings.JwtExpireDays);

            var token = new JwtSecurityToken(
                _authenticationSettings.JwtIssuer,
                _authenticationSettings.JwtIssuer,
                claims,
                expires: expires,
                signingCredentials: cred);

            var tokenHandler = new JwtSecurityTokenHandler();
            return tokenHandler.WriteToken(token);
        }
    }
}
