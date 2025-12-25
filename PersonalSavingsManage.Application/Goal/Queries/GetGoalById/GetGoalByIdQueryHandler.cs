using MediatR;
using PersonalSavingsManage.Application.FinancialGoal.ViewModels;
using PersonalSavingsManage.Core.Models;
using PersonalSavingsManage.Core.Repositories;

namespace PersonalSavingsManage.Application.FinancialGoal.Queries.GetFinacialGoalById;

public class GetGoalByIdQueryHandler : IRequestHandler<GetGoalByIdQuery, ResultViewModel<GoalDetailsViewModel>>
{
    private readonly IGoalRepository _goalRepository;

    public GetGoalByIdQueryHandler(IGoalRepository goalRepository)
    {
        _goalRepository = goalRepository;
    }

    public async Task<ResultViewModel<GoalDetailsViewModel>> Handle(GetGoalByIdQuery request, CancellationToken cancellationToken)
    {
        var goal = await _goalRepository.GetByIdAsync(request.Id);

        var goalDetailsViewModel = GoalDetailsViewModel.FromEntity(goal);

        return ResultViewModel<GoalDetailsViewModel>.Success(goalDetailsViewModel);
    }
}
