using FluentValidation;
using PersonalSavingsManage.Application.FinancialGoal.Commands.CreateFinancialGoal;
using PersonalSavingsManage.Core.Enums;

namespace PersonalSavingsManage.Application.FinancialGoal.Validators;

public class CreateFinancialGoalCommandValidator : AbstractValidator<CreateFinancialGoalCommand>
{
    public CreateFinancialGoalCommandValidator()
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
           .PrecisionScale(100,2, true);

        RuleFor(fg => fg.Deadline)
            .NotEmpty()
               .WithMessage("Deadline's field mustn't be empty.")
           .NotNull()
               .WithMessage("Deadline's field mustn't be null.");

        RuleFor(fg => fg.Status)
            .NotEmpty()
               .WithMessage("Status's field mustn't be empty.")
            .NotNull()
               .WithMessage("Status's field mustn't be null.")
            .IsEnumName(typeof(FinancialGoalStatusEnum))
             .WithMessage("Status must match with one of these:InProgress,Complete,Cancelled,OnHold");
    }
}
