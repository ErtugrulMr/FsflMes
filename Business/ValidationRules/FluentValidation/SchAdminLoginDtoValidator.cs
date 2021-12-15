using Business.Constants;
using Entities.Dtos;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class SchAdminLoginDtoValidator: AbstractValidator<SchAdminLoginDto>
    {
        public SchAdminLoginDtoValidator()
        {
            RuleFor(s => s.UserName).NotNull().NotEmpty().WithMessage(Messages.UsernameCantBeEmpty);
            RuleFor(s => s.UserName).MinimumLength(4).WithMessage(Messages.UsernameTooShort);
            RuleFor(s => s.UserName).MaximumLength(50).WithMessage(Messages.UsernameTooLong);

            RuleFor(s => s.Password).NotNull().NotEmpty().WithMessage(Messages.PasswordCantBeEmpty);
            RuleFor(s => s.Password).MinimumLength(6).WithMessage(Messages.PasswordTooShort);
            RuleFor(s => s.UserName).MaximumLength(50).WithMessage(Messages.PasswordTooLong);
        }
    }
}
