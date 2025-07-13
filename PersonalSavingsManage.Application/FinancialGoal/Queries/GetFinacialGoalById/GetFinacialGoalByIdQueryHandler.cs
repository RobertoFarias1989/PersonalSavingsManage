using MediatR;
using PersonalSavingsManage.Application.FinancialGoal.ViewModels;
using PersonalSavingsManage.Application.Transaction.ViewModel;
using PersonalSavingsManage.Core.Models;
using PersonalSavingsManage.Core.Repositories;

namespace PersonalSavingsManage.Application.FinancialGoal.Queries.GetFinacialGoalById;

public class GetFinacialGoalByIdQueryHandler : IRequestHandler<GetFinacialGoalByIdQuery, ResultViewModel<FinancialGoalDetailsViewModel>>
{
    private readonly IFinancialGoalRepository _repository;

    public GetFinacialGoalByIdQueryHandler(IFinancialGoalRepository repository)
    {
        _repository = repository;
    }

    public async Task<ResultViewModel<FinancialGoalDetailsViewModel>> Handle(GetFinacialGoalByIdQuery request, CancellationToken cancellationToken)
    {
        var financialGoal = await _repository.GetByIdAsync(request.Id);

        if (financialGoal == null)
            return ResultViewModel<FinancialGoalDetailsViewModel>.Error($"Financial goal for id:{request.Id} not found");

        //var transactions = financialGoal.Transactions
        //    .Select(t => new TransactionViewModel(
        //        t.Id,
        //        t.Amount,
        //        t.Type.ToString(),
        //        t.TransactionDate)).ToList();


        //var transactions = financialGoal.Transactions
        //    .Select(TransactionViewModel.FromEntity).ToList();

        //var financialGoalDetailsViewModel = new FinancialGoalDetailsViewModel(
        //    financialGoal.Id,
        //    financialGoal.Title,
        //    financialGoal.TargetAmount,
        //    financialGoal.Deadline,
        //    financialGoal.IdealMonthlyContribution,
        //    financialGoal.Status.ToString(),
        //    financialGoal.IsDeleted,
        //    financialGoal.CreatedAt,
        //    financialGoal.UpdatedAt,
        //    transactions);

        var financialGoalDetailsViewModel = FinancialGoalDetailsViewModel.FromEntity(financialGoal);

        return ResultViewModel<FinancialGoalDetailsViewModel>.Success(financialGoalDetailsViewModel);
    }
}
