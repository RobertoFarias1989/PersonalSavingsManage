using FluentValidation;
using PersonalSavingsManage.Application.User.Commands.UpdateGoalToUser;

namespace PersonalSavingsManage.Application.User.Validators;

public class UpdateGoalToUserCommandValidator : AbstractValidator<UpdateGoalToUserCommand>
{
    public UpdateGoalToUserCommandValidator()
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

        RuleFor(fg => fg.UserId)
            .NotEmpty()
                .WithMessage("UserId's field mustn't be empty.")
            .NotNull()
                .WithMessage("UserId's field mustn't be null.");

        RuleFor(fg => fg.Id)
            .NotEmpty()
                .WithMessage("GoalId's field mustn't be empty.")
            .NotNull()
                .WithMessage("GoalId's field mustn't be null.");
    }
}
