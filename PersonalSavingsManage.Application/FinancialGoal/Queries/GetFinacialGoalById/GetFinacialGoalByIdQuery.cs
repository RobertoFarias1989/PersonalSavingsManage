using MediatR;
using PersonalSavingsManage.Application.FinancialGoal.ViewModels;
using PersonalSavingsManage.Core.Models;

namespace PersonalSavingsManage.Application.FinancialGoal.Queries.GetFinacialGoalById;

public class GetFinacialGoalByIdQuery : IRequest<ResultViewModel<FinancialGoalDetailsViewModel>>
{
    public GetFinacialGoalByIdQuery(Guid id)
    {
        Id = id;
    }

    public Guid Id { get; private set; }
}
