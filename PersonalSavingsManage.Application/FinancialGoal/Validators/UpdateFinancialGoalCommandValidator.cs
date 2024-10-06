using FluentValidation;
using PersonalSavingsManage.Application.FinancialGoal.Commands.UpdateFinancialGoal;
using PersonalSavingsManage.Core.Enums;

namespace PersonalSavingsManage.Application.FinancialGoal.Validators;

public class UpdateFinancialGoalCommandValidator : AbstractValidator<UpdateFinancialGoalCommand>
{
    public UpdateFinancialGoalCommandValidator()
    {
        RuleFor(fg => fg.Title)
           .NotEmpty()
               .WithMessage("Title's field mustn't be empty.")
           .NotNull()
               .WithMessage("Title's field mustn't be null.")
           .MaximumLength(150)
               .WithMessage("Title's maximum length is around 150 characters.");

        RuleFor(fg => fg.TargetAmount)
           .NotEmpty()
               .WithMessage("TargetAmount's field mustn't be empty.")
           .NotNull()
               .WithMessage("TargetAmount's field mustn't be null.")
           .PrecisionScale(100, 2, true);

        RuleFor(fg => fg.Deadline)
            .NotEmpty()
               .WithMessage("Deadline's field mustn't be empty.")
           .NotNull()
               .WithMessage("Deadline's field mustn't be null.");

    }
}
