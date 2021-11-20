using Business.Constants;
using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class StudentValidator: AbstractValidator<Student>
    {
        public StudentValidator()
        {
            RuleFor(st => st.ClassId).NotEmpty().WithMessage(Messages.ClassIdCantBeEmpty);

            RuleFor(st => st.SchoolId).NotEmpty().WithMessage(Messages.SchoolIdCantBeEmpty);

            RuleFor(st => st.SchoolNumber).NotEmpty().WithMessage(Messages.SchoolNumberCantBeEmpty);

            RuleFor(st => st.NationalIdentityNumber).NotEmpty().WithMessage(Messages.NationalIdentityNumberCantBeEmpty);
            RuleFor(st => st.NationalIdentityNumber).Must(MustBeElevenCharacters).WithMessage(Messages.NationalIdentityNumberMustBeElevenCharacters);

            RuleFor(st => st.FirstName).NotEmpty().WithMessage(Messages.FirstNameCantBeEmpty);
            RuleFor(st => st.FirstName).MinimumLength(3).WithMessage(Messages.FirstNameTooShort);
            RuleFor(st => st.FirstName).MaximumLength(50).WithMessage(Messages.FirstNameTooLong);

            RuleFor(st => st.LastName).NotEmpty().WithMessage(Messages.LastNameCantBeEmpty);
            RuleFor(st => st.LastName).MinimumLength(3).WithMessage(Messages.LastNameTooShort);
            RuleFor(st => st.LastName).MaximumLength(50).WithMessage(Messages.LastNameTooLong);
        }

        private bool MustBeElevenCharacters(long arg)
        {
            return arg.ToString().Length == 11;
        }
    }
}
