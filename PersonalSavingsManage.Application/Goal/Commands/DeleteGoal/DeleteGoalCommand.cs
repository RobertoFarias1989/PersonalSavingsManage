using MediatR;
using PersonalSavingsManage.Core.Models;

namespace PersonalSavingsManage.Application.FinancialGoal.Commands.DeleteFinancialGoal;

public class DeleteGoalCommand : IRequest<ResultViewModel<Unit>>
{
    public DeleteGoalCommand(int id)
    {
        Id = id;
    }

    public int Id { get; private set; }
}
