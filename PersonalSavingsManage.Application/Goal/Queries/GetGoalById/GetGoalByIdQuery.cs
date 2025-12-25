using MediatR;
using PersonalSavingsManage.Application.FinancialGoal.ViewModels;
using PersonalSavingsManage.Core.Models;

namespace PersonalSavingsManage.Application.FinancialGoal.Queries.GetFinacialGoalById;

public class GetGoalByIdQuery : IRequest<ResultViewModel<GoalDetailsViewModel>>
{
    public GetGoalByIdQuery(int id)
    {
        Id = id;
    }

    public int Id { get; private set; }
}
