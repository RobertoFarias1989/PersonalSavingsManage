using MediatR;
using PersonalSavingsManage.Application.FinancialGoal.ViewModels;
using PersonalSavingsManage.Core.Repositories;

namespace PersonalSavingsManage.Application.FinancialGoal.Queries.GetAllFinacialGoals;

public class GetAllGoalsQueryHandler : IRequestHandler<GetAllGoalsQuery, List<GoalViewModel>>
{
    private readonly IGoalRepository _repository;

    public GetAllGoalsQueryHandler(IGoalRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<GoalViewModel>> Handle(GetAllGoalsQuery request, CancellationToken cancellationToken)
    {
        var financialGoals = await _repository.GetAllAsync();

        var financialGoalsViewModel = financialGoals
            .Select(fg => new GoalViewModel(
                fg.Id,
                fg.Title,
                fg.TargetAmount,
                fg.Deadline,
                fg.IdealMonthlyContribution,
                fg.Status.ToString())).ToList();

        return financialGoalsViewModel;
    }
}
