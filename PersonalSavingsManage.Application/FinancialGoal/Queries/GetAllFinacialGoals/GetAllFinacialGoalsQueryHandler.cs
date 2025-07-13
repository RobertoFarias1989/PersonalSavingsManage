using MediatR;
using PersonalSavingsManage.Application.FinancialGoal.ViewModels;
using PersonalSavingsManage.Core.Models;
using PersonalSavingsManage.Core.Repositories;

namespace PersonalSavingsManage.Application.FinancialGoal.Queries.GetAllFinacialGoals;

public class GetAllFinacialGoalsQueryHandler : IRequestHandler<GetAllFinacialGoalsQuery, ResultViewModel<List<FinancialGoalViewModel>>>
{
    private readonly IFinancialGoalRepository _repository;

    public GetAllFinacialGoalsQueryHandler(IFinancialGoalRepository repository)
    {
        _repository = repository;
    }

    public async Task<ResultViewModel<List<FinancialGoalViewModel>>> Handle(GetAllFinacialGoalsQuery request, CancellationToken cancellationToken)
    {
        var financialGoals = await _repository.GetAllAsync();

        //var financialGoalsViewModel = financialGoals
        //    .Select(fg => new FinancialGoalViewModel(
        //        fg.Id,
        //        fg.Title,
        //        fg.TargetAmount,
        //        fg.Deadline,
        //        fg.IdealMonthlyContribution,
        //        fg.Status.ToString())).ToList();


        var financialGoalsViewModel = financialGoals
             .Select(FinancialGoalViewModel.FromEntity).ToList();

        return ResultViewModel<List<FinancialGoalViewModel>>.Success(financialGoalsViewModel);
    }
}
