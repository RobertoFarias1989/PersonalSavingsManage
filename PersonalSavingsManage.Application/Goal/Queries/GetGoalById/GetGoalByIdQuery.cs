using MediatR;
using PersonalSavingsManage.Application.FinancialGoal.ViewModels;

namespace PersonalSavingsManage.Application.FinancialGoal.Queries.GetFinacialGoalById;

public class GetGoalByIdQuery : IRequest<GoalDetailsViewModel>
{
    public GetGoalByIdQuery(int id)
    {
        Id = id;
    }

    public int Id { get; private set; }
}
