using FluentValidation;
using Kontakty.Data;
using Kontakty.Models;

namespace Kontakty.DTO.Validators
{
    public class RegisterUserDTOValidator : AbstractValidator<RegisterDTO>
    {
        public RegisterUserDTOValidator(KontaktyDbContext dbContext)
        {

            RuleFor(x => x.Email).NotEmpty().EmailAddress();

            RuleFor(x => x.Password).MinimumLength(6);
            RuleFor(x => x.ConfirmPassword).Equal(e => e.Password);

            RuleFor(x => x.Email).Custom((value, context) =>
            {
                var emailInUse = dbContext.Użytkowniks.Any(u => u.Email == value);
                if (emailInUse)
                {
                    context.AddFailure("Email", "That email is taken");
                }
            });
        }
    }
}
