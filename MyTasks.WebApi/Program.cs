using FluentValidation;
using FluentValidation.AspNetCore;
using LoggerService;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MyTasks.WebApi;
using MyTasks.WebApi.Core;
using MyTasks.WebApi.Core.Services;
using MyTasks.WebApi.Core.Validators;
using MyTasks.WebApi.Models.Domains;
using MyTasks.WebApi.Models.Dtos;
using MyTasks.WebApi.Models.Services;
using MyTasks.WebApi.Persistence;
using MyTasks.WebApi.Services;
using NLog;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

LogManager.LoadConfiguration(string.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));


var authenticationSettings = new AuthenticationSettings();

builder.Configuration.GetSection("Authentication").Bind(authenticationSettings);

builder.Services.AddSingleton(authenticationSettings);
builder.Services.AddAuthentication(option =>
{
    option.DefaultAuthenticateScheme = "Bearer";
    option.DefaultScheme = "Bearer";
    option.DefaultChallengeScheme = "Bearer";
}).AddJwtBearer(cfg =>
{
    cfg.RequireHttpsMetadata = false;
    cfg.SaveToken = true;
    cfg.TokenValidationParameters = new TokenValidationParameters
    {
        ValidIssuer = authenticationSettings.JwtIssuer,
        ValidAudience = authenticationSettings.JwtIssuer,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authenticationSettings.JwtKey))
    };
});



// Add services to the container.
builder.Services.AddControllers().AddFluentValidation();
builder.Services.AddScoped<IPasswordHasher<ApplicationUser>, PasswordHasher<ApplicationUser>>();
builder.Services.AddScoped<IValidator<RegisterUserDto>, ApplicationUserDtoValidator>();
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ITasksService, TasksService>();
builder.Services.AddScoped<IApplicationDbContext, ApplicationDbContext>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<ILoggerManager, LoggerManager>();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("ApplicationDbContext")));


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
