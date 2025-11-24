using MediatR;
using PersonalSavingsManage.Core.Models;

namespace PersonalSavingsManage.Application.FinancialGoal.Commands.UpdateTransaction;

public class UpdateTransactionToGoalCommand : IRequest<ResultViewModel<Unit>>
{
    public Guid Id { get; private set; }
    public decimal Amount { get; set; }
    public string Type { get; set; } = string.Empty;
    public Guid UserId { get; set; }
    public Guid GoalId { get; set; }
}
