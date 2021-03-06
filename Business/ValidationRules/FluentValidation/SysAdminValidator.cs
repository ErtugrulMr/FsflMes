using Business.Constants;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class SysAdminValidator: AbstractValidator<SysAdmin>
    {
        public SysAdminValidator()
        {
            RuleFor(s => s.UserName).NotNull().NotEmpty().WithMessage(Messages.UsernameCantBeEmpty);
            RuleFor(s => s.UserName).MinimumLength(4).WithMessage(Messages.UsernameTooShort);
            RuleFor(s => s.UserName).MaximumLength(50).WithMessage(Messages.UsernameTooLong);

            RuleFor(s => s.Status).NotNull().NotEmpty().WithMessage(Messages.StatusCantBeEmpty);
        }
    }
}
