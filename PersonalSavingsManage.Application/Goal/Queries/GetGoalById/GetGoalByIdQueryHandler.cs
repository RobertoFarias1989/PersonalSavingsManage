using MediatR;
using PersonalSavingsManage.Application.FinancialGoal.ViewModels;
using PersonalSavingsManage.Application.Transaction.ViewModel;
using PersonalSavingsManage.Core.Repositories;

namespace PersonalSavingsManage.Application.FinancialGoal.Queries.GetFinacialGoalById;

public class GetGoalByIdQueryHandler : IRequestHandler<GetGoalByIdQuery, GoalDetailsViewModel>
{
    private readonly IGoalRepository _repository;

    public GetGoalByIdQueryHandler(IGoalRepository repository)
    {
        _repository = repository;
    }

    public async Task<GoalDetailsViewModel> Handle(GetGoalByIdQuery request, CancellationToken cancellationToken)
    {
        var goal = await _repository.GetByIdAsync(request.Id);

        var goalDetailsViewModel = GoalDetailsViewModel.FromEntity(goal);

        return goalDetailsViewModel;
    }
}
