using PersonalSavingsManage.Application.Transaction.ViewModel;

namespace PersonalSavingsManage.Application.FinancialGoal.ViewModels;

public class FinancialGoalDetailsViewModel
{
    public FinancialGoalDetailsViewModel(string id,
        string title,
        decimal targetAmount,
        DateTime deadline,
        decimal idealMonthlyContribution,
        string status,
        bool isDeleted,
        DateTime createdAt,
        DateTime? updatedAt,
        List<TransactionViewModel> transactions)
    {
        Id = id;
        Title = title;
        TargetAmount = targetAmount;
        Deadline = deadline;
        IdealMonthlyContribution = idealMonthlyContribution;
        Status = status;
        IsDeleted = isDeleted;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
        Transactions = transactions;
    }

    public string Id { get; private set; }
    public string Title { get; private set; }
    public decimal TargetAmount { get; private set; }
    public DateTime Deadline { get; private set; }
    public decimal IdealMonthlyContribution { get; private set; }
    public string Status { get; private set; }
    public bool IsDeleted { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime? UpdatedAt { get; private set; }
    public List<TransactionViewModel>  Transactions { get; private set; }

    public static FinancialGoalDetailsViewModel FromEntity(Core.Entities.FinancialGoal entity)
    {
        var transactions = entity.Transactions?
        .Select(TransactionViewModel.FromEntity)
        .ToList() ?? new List<TransactionViewModel>();


        return new FinancialGoalDetailsViewModel(entity.Id, entity.Title, entity.TargetAmount, entity.Deadline, entity.IdealMonthlyContribution, entity.Status.ToString(),
            entity.IsDeleted, entity.CreatedAt, entity.UpdatedAt, transactions);
    }

}
