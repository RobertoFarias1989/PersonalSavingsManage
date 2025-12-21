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
        var goals = await _repository.GetAllAsync();

        var goalsViewModel = goals
            .Select(GoalViewModel.FromEntity).ToList();

        return goalsViewModel;
    }
}
