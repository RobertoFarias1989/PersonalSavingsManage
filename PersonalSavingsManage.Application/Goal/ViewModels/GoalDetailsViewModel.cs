using PersonalSavingsManage.Application.Transaction.ViewModel;

namespace PersonalSavingsManage.Application.FinancialGoal.ViewModels;

public class GoalDetailsViewModel
{
    public GoalDetailsViewModel(int id,
        string title,
        decimal targetAmount,
        DateTime deadline,
        decimal idealMonthlyContribution,
        string status,
        int idUser,
        bool isDeleted,
        DateTime createdAt,
        DateTime? updatedAt,
        List<TransactionDetailsViewModel> transactions)
    {
        Id = id;
        Title = title;
        TargetAmount = targetAmount;
        Deadline = deadline;
        IdealMonthlyContribution = idealMonthlyContribution;
        Status = status;
        IdUser = idUser;
        IsDeleted = isDeleted;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
        Transactions = transactions;
    }

    public int Id { get; private set; }
    public string Title { get; private set; }
    public decimal TargetAmount { get; private set; }
    public DateTime Deadline { get; private set; }
    public decimal IdealMonthlyContribution { get; private set; }
    public string Status { get; private set; }
    public int IdUser { get; private set; }
    public bool IsDeleted { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime? UpdatedAt { get; private set; }
    public List<TransactionDetailsViewModel>  Transactions { get; private set; }

    public static GoalDetailsViewModel FromEntity(Core.Entities.Goal entity)
    {
        var transactions = entity.Transactions?
            .Select(TransactionDetailsViewModel.FromEntity)
            .ToList() ?? new List<TransactionDetailsViewModel>();

        return new GoalDetailsViewModel(entity.Id, entity.Title, entity.TargetAmount, entity.Deadline,
            entity.IdealMonthlyContribution, entity.Status.ToString(), entity.IdUser, entity.IsDeleted,
            entity.CreatedAt, entity.UpdatedAt, transactions);
    }
}
