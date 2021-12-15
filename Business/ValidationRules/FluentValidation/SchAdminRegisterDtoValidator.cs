using Business.Constants;
using Entities.Dtos;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class SchAdminRegisterDtoValidator: AbstractValidator<SchAdminRegisterDto>
    {
        public SchAdminRegisterDtoValidator()
        {
            RuleFor(s => s.FirstName).NotNull().NotEmpty().WithMessage(Messages.FirstNameCantBeEmpty);
            RuleFor(s => s.FirstName).MinimumLength(2).WithMessage(Messages.FirstNameTooShort);
            RuleFor(s => s.FirstName).MaximumLength(50).WithMessage(Messages.FirstNameTooLong);

            RuleFor(s => s.LastName).NotNull().NotEmpty().WithMessage(Messages.LastNameCantBeEmpty);
            RuleFor(s => s.LastName).MinimumLength(2).WithMessage(Messages.LastNameTooShort);
            RuleFor(s => s.LastName).MaximumLength(50).WithMessage(Messages.LastNameTooLong);

            RuleFor(s => s.UserName).NotNull().NotEmpty().WithMessage(Messages.UsernameCantBeEmpty);
            RuleFor(s => s.UserName).MinimumLength(4).WithMessage(Messages.UsernameTooShort);
            RuleFor(s => s.UserName).MaximumLength(50).WithMessage(Messages.UsernameTooLong);

            RuleFor(s => s.Password).NotNull().NotEmpty().WithMessage(Messages.PasswordCantBeEmpty);
            RuleFor(s => s.Password).MinimumLength(6).WithMessage(Messages.PasswordTooShort);
            RuleFor(s => s.UserName).MaximumLength(50).WithMessage(Messages.PasswordTooLong);
        }
    }
}
