using Business.Constants;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class PostValidator: AbstractValidator<Post>
    {
        public PostValidator()
        {
            RuleFor(p => p.TypeId).NotNull().NotEmpty().WithMessage(Messages.TypeIdCantBeEmpty);

            RuleFor(p => p.StudentId).NotNull().NotEmpty().WithMessage(Messages.StudentIdCantBeEmpty);

            RuleFor(p => p.Title).NotNull().NotEmpty().WithMessage(Messages.TitleCantBeEmpty);
            RuleFor(p => p.Title).MinimumLength(3).WithMessage(Messages.TitleTooShort);
            RuleFor(p => p.Title).MaximumLength(50).WithMessage(Messages.TitleTooLong);

            RuleFor(p => p.IsRepliedByAdmin).NotNull().NotEmpty().WithMessage(Messages.IsRepliedByAdminCantBeEmpty);

            RuleFor(p => p.IsSolved).NotNull().NotEmpty().WithMessage(Messages.IsSolvedCantBeEmpty);

            RuleFor(p => p.CreationDate).NotNull().NotEmpty().WithMessage(Messages.CreationDateCantBeEmpty);
        }
    }
}
