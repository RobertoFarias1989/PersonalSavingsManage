using MediatR;
using PersonalSavingsManage.Application.FinancialGoal.ViewModels;
using PersonalSavingsManage.Core.Models;

namespace PersonalSavingsManage.Application.FinancialGoal.Queries.GetFinacialGoalById;

public class GetFinacialGoalByIdQuery : IRequest<ResultViewModel<FinancialGoalDetailsViewModel>>
{
    public GetFinacialGoalByIdQuery(string id)
    {
        Id = id;
    }

    public string Id { get; private set; }
}
