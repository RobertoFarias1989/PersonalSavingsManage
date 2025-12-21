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
        var financialGoal = await _repository.GetByIdAsync(request.Id);

        var transactions = financialGoal.Transactions
            .Select(t => new TransactionViewModel(
                t.Id,
                t.Amount,
                t.Type.ToString(),
                t.TransactionDate,
                t.IdUser,
                t.IdGoal)).ToList();

        var financialGoalDetailsViewModel = new GoalDetailsViewModel(
            financialGoal.Id,
            financialGoal.Title,
            financialGoal.TargetAmount,
            financialGoal.Deadline,
            financialGoal.IdealMonthlyContribution,
            financialGoal.Status.ToString(),
            financialGoal.IdUser,
            financialGoal.IsDeleted,
            financialGoal.CreatedAt,
            financialGoal.UpdatedAt,
            transactions);

        return financialGoalDetailsViewModel;
    }
}
