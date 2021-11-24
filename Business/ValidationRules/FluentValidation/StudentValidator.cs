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

            RuleFor(st => st.SchoolNumber).NotEmpty().WithMessage(Messages.SchoolNumberCantBeEmpty);

            RuleFor(st => st.NationalIdentityNumber).NotEmpty().WithMessage(Messages.NationalIdentityNumberCantBeEmpty);
            RuleFor(st => st.NationalIdentityNumber).Must(MustBeElevenCharacters).WithMessage(Messages.NationalIdentityNumberMustBeElevenCharacters);

            RuleFor(st => st.Name).NotEmpty().WithMessage(Messages.NameCantBeEmpty);
            RuleFor(st => st.Name).MinimumLength(3).WithMessage(Messages.NameTooShort);
            RuleFor(st => st.Name).MaximumLength(50).WithMessage(Messages.NameTooLong);
        }

        private bool MustBeElevenCharacters(long arg)
        {
            return arg.ToString().Length == 11;
        }
    }
}
