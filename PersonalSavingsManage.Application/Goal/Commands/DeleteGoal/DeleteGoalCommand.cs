using MediatR;

namespace PersonalSavingsManage.Application.FinancialGoal.Commands.DeleteFinancialGoal;

public class DeleteGoalCommand : IRequest<Unit>
{
    public DeleteGoalCommand(string id)
    {
        Id = id;
    }

    public string Id { get; private set; }
}
