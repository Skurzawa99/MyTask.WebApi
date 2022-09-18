using FluentValidation;
using MyTasks.WebApi.Models.Domains;
using MyTasks.WebApi.Models.Dtos;

namespace MyTasks.WebApi.Core.Validators
{
    public class ApplicationUserDtoValidator : AbstractValidator<RegisterUserDto>
    {
        public ApplicationUserDtoValidator(IApplicationDbContext dbContext)
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .EmailAddress();

            RuleFor(x => x.Password).MinimumLength(6);

            RuleFor(x => x.ConfirmPassword).Equal(e => e.Password);

            RuleFor(x => x.Name)
                .Custom((value, context) =>
                {
                    var emailInUse = dbContext.ApplicationUsers.Any(u => u.Name == value);
                    if (emailInUse)
                    {
                        context.AddFailure("Email", "That email is taken");
                    }
                });
        }

    }
}
