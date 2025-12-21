using MediatR;

namespace PersonalSavingsManage.Application.FinancialGoal.Commands.DeleteFinancialGoal;

public class DeleteGoalCommand : IRequest<Unit>
{
    public DeleteGoalCommand(int id)
    {
        Id = id;
    }

    public int Id { get; private set; }
}
