using MediatR;
using PersonalSavingsManage.Core.Models;

namespace PersonalSavingsManage.Application.FinancialGoal.Commands.CreateTransaction;

public class CreateTransactionToGoalCommand : IRequest<ResultViewModel<Unit>>
{
    public decimal Amount { get;  set; }
    public string Type { get; set; } = string.Empty;
    public Guid UserId { get;  set; }
    public Guid GoalId { get;  set; }
}
