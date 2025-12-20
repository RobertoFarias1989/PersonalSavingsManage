using MediatR;
using PersonalSavingsManage.Core.Enums;
using PersonalSavingsManage.Core.Models;

namespace PersonalSavingsManage.Application.FinancialGoal.Commands.CreateTransaction;

public class CreateTransactionToGoalCommand : IRequest<ResultViewModel<Unit>>
{
    public decimal Amount { get;  set; }
    public TransactionTypeEnum Type { get; set; }
    public Guid UserId { get;  set; }
    public Guid GoalId { get;  set; }
}
