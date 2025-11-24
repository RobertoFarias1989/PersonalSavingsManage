using PersonalSavingsManage.Application.Transaction.ViewModel;

namespace PersonalSavingsManage.Application.FinancialGoal.ViewModels;

public class FinancialGoalDetailsViewModel
{
    public FinancialGoalDetailsViewModel(Guid id,
        string title,
        decimal targetAmount,
        string imageGoal,
        DateTime deadline,
        decimal idealMonthlyContribution,
        string status,
        bool isDeleted,
        DateTime createdAt,
        DateTime? updatedAt,
        List<TransactionDetailsViewModel> transactions)
    {
        Id = id;
        Title = title;
        TargetAmount = targetAmount;
        ImageGoal = imageGoal;
        Deadline = deadline;
        IdealMonthlyContribution = idealMonthlyContribution;
        Status = status;
        IsDeleted = isDeleted;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
        Transactions = transactions;
    }

    public Guid Id { get; private set; }
    public string Title { get; private set; }
    public decimal TargetAmount { get; private set; }
    public string ImageGoal {  get; private set; }
    public DateTime Deadline { get; private set; }
    public Guid UserId { get; private set; }
    public decimal IdealMonthlyContribution { get; private set; }
    public string Status { get; private set; }
    public bool IsDeleted { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime? UpdatedAt { get; private set; }
    public List<TransactionDetailsViewModel>  Transactions { get; private set; }

    public static FinancialGoalDetailsViewModel FromEntity(Core.Entities.FinancialGoal entity)
    {
        var transactions = entity.Transactions?
        .Select(TransactionDetailsViewModel.FromEntity)
        .ToList() ?? new List<TransactionDetailsViewModel>();


        return new FinancialGoalDetailsViewModel(entity.Id, entity.Title, entity.TargetAmount, entity.ImageGoal, entity.Deadline, entity.IdealMonthlyContribution, entity.Status.ToString(),
            entity.IsDeleted, entity.CreatedAt, entity.UpdatedAt, transactions);
    }

}
