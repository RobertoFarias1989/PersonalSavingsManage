using MediatR;
using PersonalSavingsManage.Core.Models;

namespace PersonalSavingsManage.Application.FinancialGoal.Commands.DeleteFinancialGoal;

public class DeleteFinancialGoalCommand : IRequest<ResultViewModel<Unit>>
{
    public DeleteFinancialGoalCommand(string id)
    {
        Id = id;
    }

    public string Id { get; private set; }
}
