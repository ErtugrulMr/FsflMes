using Business.Constants;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class ReportValidator: AbstractValidator<Report>
    {
        public ReportValidator()
        {
            RuleFor(r => r.PostId).NotNull().NotEmpty().WithMessage(Messages.PostIdCantBeEmpty);

            RuleFor(r => r.UserId).NotNull().NotEmpty().WithMessage(Messages.UserIdCantBeEmpty);

            RuleFor(r => r.IsFromStudent).NotNull().NotEmpty().WithMessage(Messages.IsFromStudentCantBeEmpty);

            RuleFor(r => r.Message).NotNull().NotEmpty().WithMessage(Messages.MessageCantBeEmpty);
            RuleFor(r => r.Message).MinimumLength(10).WithMessage(Messages.MessageTooShort);
            RuleFor(r => r.Message).MaximumLength(1000).WithMessage(Messages.MessageTooLong);

            RuleFor(r => r.CreationDate).NotNull().NotEmpty().WithMessage(Messages.CreationDateCantBeEmpty);
        }
    }
}
