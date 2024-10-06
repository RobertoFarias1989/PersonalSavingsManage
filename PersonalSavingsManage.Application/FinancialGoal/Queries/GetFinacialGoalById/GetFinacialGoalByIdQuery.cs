using MediatR;
using PersonalSavingsManage.Application.FinancialGoal.ViewModels;

namespace PersonalSavingsManage.Application.FinancialGoal.Queries.GetFinacialGoalById;

public class GetFinacialGoalByIdQuery : IRequest<FinancialGoalDetailsViewModel>
{
    public GetFinacialGoalByIdQuery(string id)
    {
        Id = id;
    }

    public string Id { get; private set; }
}
