using FluentValidation;
using PersonalSavingsManage.Application.Transaction.Commands.UpdateTransaction;
using PersonalSavingsManage.Core.Enums;

namespace PersonalSavingsManage.Application.Transaction.Validators;

public class UpdateTransactionCommandValidator : AbstractValidator<UpdateTransactionCommand>
{
    public UpdateTransactionCommandValidator()
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
              .WithMessage("Status must match with one of these:Deposit,Withdraw");
    }
}
