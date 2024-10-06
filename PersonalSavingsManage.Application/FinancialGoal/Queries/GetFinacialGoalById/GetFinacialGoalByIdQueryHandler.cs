using MediatR;
using PersonalSavingsManage.Application.FinancialGoal.ViewModels;
using PersonalSavingsManage.Application.Transaction.ViewModel;
using PersonalSavingsManage.Core.Repositories;

namespace PersonalSavingsManage.Application.FinancialGoal.Queries.GetFinacialGoalById;

public class GetFinacialGoalByIdQueryHandler : IRequestHandler<GetFinacialGoalByIdQuery, FinancialGoalDetailsViewModel>
{
    private readonly IFinancialGoalRepository _repository;

    public GetFinacialGoalByIdQueryHandler(IFinancialGoalRepository repository)
    {
        _repository = repository;
    }

    public async Task<FinancialGoalDetailsViewModel> Handle(GetFinacialGoalByIdQuery request, CancellationToken cancellationToken)
    {
        var financialGoal = await _repository.GetByIdAsync(request.Id);

        var transactions = financialGoal.Transactions
            .Select(t => new TransactionViewModel(
                t.Id,
                t.Amount,
                t.Type.ToString(),
                t.TransactionDate)).ToList();

        var financialGoalDetailsViewModel = new FinancialGoalDetailsViewModel(
            financialGoal.Id,
            financialGoal.Title,
            financialGoal.TargetAmount,
            financialGoal.Deadline,
            financialGoal.IdealMonthlyContribution,
            financialGoal.Status.ToString(),
            financialGoal.IsDeleted,
            financialGoal.CreatedAt,
            financialGoal.UpdatedAt,
            transactions);

        return financialGoalDetailsViewModel;
    }
}
