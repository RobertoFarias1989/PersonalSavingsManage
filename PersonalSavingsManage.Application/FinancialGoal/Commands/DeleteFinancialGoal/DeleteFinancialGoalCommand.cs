using MediatR;

namespace PersonalSavingsManage.Application.FinancialGoal.Commands.DeleteFinancialGoal;

public class DeleteFinancialGoalCommand : IRequest<Unit>
{
    public DeleteFinancialGoalCommand(string id)
    {
        Id = id;
    }

    public string Id { get; private set; }
}
