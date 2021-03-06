using Business.Constants;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class StudentValidator: AbstractValidator<Student>
    {
        public StudentValidator()
        {
            RuleFor(st => st.ClassId).NotNull().NotEmpty().WithMessage(Messages.ClassIdCantBeEmpty);

            RuleFor(st => st.SchoolNumber).NotNull().NotEmpty().WithMessage(Messages.SchoolNumberCantBeEmpty);

            RuleFor(st => st.NationalIdentityNumber).NotNull().NotEmpty().WithMessage(Messages.NationalIdentityNumberCantBeEmpty);
            RuleFor(st => st.NationalIdentityNumber).NotNull().Must(MustBeElevenCharacters).WithMessage(Messages.NationalIdentityNumberMustBeElevenCharacters);

            RuleFor(st => st.FirstName).NotNull().NotEmpty().WithMessage(Messages.FirstNameCantBeEmpty);
            RuleFor(st => st.FirstName).MinimumLength(2).WithMessage(Messages.FirstNameTooShort);
            RuleFor(st => st.FirstName).MaximumLength(50).WithMessage(Messages.FirstNameTooLong);

            RuleFor(st => st.LastName).NotNull().NotEmpty().WithMessage(Messages.LastNameCantBeEmpty);
            RuleFor(st => st.LastName).MinimumLength(2).WithMessage(Messages.LastNameTooShort);
            RuleFor(st => st.LastName).MaximumLength(50).WithMessage(Messages.LastNameTooLong);
        }

        private bool MustBeElevenCharacters(long arg)
        {
            return arg.ToString().Length == 11;
        }
    }
}
