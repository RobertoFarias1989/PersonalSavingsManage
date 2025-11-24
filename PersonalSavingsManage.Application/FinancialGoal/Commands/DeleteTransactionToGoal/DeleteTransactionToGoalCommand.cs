using MediatR;
using PersonalSavingsManage.Core.Models;

namespace PersonalSavingsManage.Application.FinancialGoal.Commands.DeleteTransaction;

public class DeleteTransactionToGoalCommand : IRequest<ResultViewModel<Unit>>
{
    public DeleteTransactionToGoalCommand(Guid userId, Guid goalId, Guid id)
    {
        Id = id;
        UserId = userId;
        GoalId = goalId;
    }

    public Guid Id { get; private set; }
    public Guid UserId { get; private set; }
    public Guid GoalId { get; private set; }
}
