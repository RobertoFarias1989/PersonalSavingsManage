using MediatR;
using PersonalSavingsManage.Core.Models;

namespace PersonalSavingsManage.Application.FinancialGoal.Commands.DeleteFinancialGoal;

public class DeleteFinancialGoalCommand : IRequest<ResultViewModel<Unit>>
{
    public DeleteFinancialGoalCommand(Guid id)
    {
        Id = id;
    }

    public Guid Id { get; private set; }
}
