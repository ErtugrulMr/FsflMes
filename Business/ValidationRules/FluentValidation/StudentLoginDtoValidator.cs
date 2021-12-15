using Business.Constants;
using Entities.Dtos;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class StudentLoginDtoValidator: AbstractValidator<StudentLoginDto>
    {
        public StudentLoginDtoValidator()
        {
            RuleFor(s => s.Name).NotNull().NotEmpty().WithMessage(Messages.NameCantBeEmpty);

            RuleFor(s => s.SchoolNumber).NotNull().NotEmpty().WithMessage(Messages.SchoolNumberCantBeEmpty);

            RuleFor(s => s.Password).NotNull().NotEmpty().WithMessage(Messages.PasswordCantBeEmpty);
        }
    }
}
