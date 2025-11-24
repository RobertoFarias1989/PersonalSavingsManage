using FluentValidation;
using PersonalSavingsManage.Application.FinancialGoal.Commands.CreateTransaction;
using PersonalSavingsManage.Core.Enums;

namespace PersonalSavingsManage.Application.FinancialGoal.Validators;

public class CreateTransactionToGoalCommandValidator : AbstractValidator<CreateTransactionToGoalCommand>
{
    public CreateTransactionToGoalCommandValidator()
    {
        RuleFor(t => t.Amount)
           .NotEmpty()
               .WithMessage("Amount's field mustn't be empty.")
           .NotNull()
               .WithMessage("Amount's field mustn't be null.")
           .PrecisionScale(100, 2, true);

        RuleFor(t => t.Type)
           .NotEmpty()
              .WithMessage("Type's field mustn't be empty.")
           .NotNull()
              .WithMessage("Type's field mustn't be null.")
           .IsEnumName(typeof(TransactionTypeEnum))
              .WithMessage("Type must match with one of these:Deposit,Withdraw");

        RuleFor(t => t.UserId)
           .NotEmpty()
              .WithMessage("UserId's field mustn't be empty.")
           .NotNull()
              .WithMessage("UserId's field mustn't be null.");

        RuleFor(t => t.GoalId)
             .NotEmpty()
                .WithMessage("GoalId's field mustn't be empty.")
             .NotNull()
                .WithMessage("GoalId's field mustn't be null.");
    }
}
