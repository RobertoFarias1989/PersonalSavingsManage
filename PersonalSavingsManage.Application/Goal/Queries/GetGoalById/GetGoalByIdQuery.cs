using MediatR;
using PersonalSavingsManage.Application.FinancialGoal.ViewModels;

namespace PersonalSavingsManage.Application.FinancialGoal.Queries.GetFinacialGoalById;

public class GetGoalByIdQuery : IRequest<GoalDetailsViewModel>
{
    public GetGoalByIdQuery(string id)
    {
        Id = id;
    }

    public string Id { get; private set; }
}
