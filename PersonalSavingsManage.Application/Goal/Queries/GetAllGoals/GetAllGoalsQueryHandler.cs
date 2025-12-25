using MediatR;
using PersonalSavingsManage.Application.FinancialGoal.ViewModels;
using PersonalSavingsManage.Core.Models;
using PersonalSavingsManage.Core.Repositories;

namespace PersonalSavingsManage.Application.FinancialGoal.Queries.GetAllFinacialGoals;

public class GetAllGoalsQueryHandler : IRequestHandler<GetAllGoalsQuery, ResultViewModel<List<GoalViewModel>>>
{
    private readonly IGoalRepository _goalRepository;

    public GetAllGoalsQueryHandler(IGoalRepository goalRepository)
    {
        _goalRepository = goalRepository;
    }

    public async Task<ResultViewModel<List<GoalViewModel>>> Handle(GetAllGoalsQuery request, CancellationToken cancellationToken)
    {
        var goals = await _goalRepository.GetAllAsync();

        var goalsViewModel = goals
            .Select(GoalViewModel.FromEntity).ToList();

        return ResultViewModel<List<GoalViewModel>>.Success(goalsViewModel);
    }
}
