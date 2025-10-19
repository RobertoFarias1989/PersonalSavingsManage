namespace PersonalSavingsManage.Application.FinancialGoal.ViewModels;

public class FinancialGoalViewModel
{
    public FinancialGoalViewModel(Guid id,
        string title, decimal targetAmount, string imageGoal, DateTime deadline, decimal idealMonthlyContribution, string status)
    {
        Id = id;
        Title = title;
        TargetAmount = targetAmount;
        ImageGoal = imageGoal;
        Deadline = deadline;
        IdealMonthlyContribution = idealMonthlyContribution;
        Status = status;
    }

    public Guid Id { get; private set; }
    public string Title { get; private set; }
    public decimal TargetAmount { get; private set; }
    public string ImageGoal { get; private set; }
    public DateTime Deadline { get; private set; }
    public decimal IdealMonthlyContribution { get; private set; }
    public string Status { get; private set; }

    public static FinancialGoalViewModel FromEntity(Core.Entities.FinancialGoal entity)
        => new FinancialGoalViewModel(entity.Id, entity.Title, entity.TargetAmount,
            entity.ImageGoal, entity.Deadline, entity.IdealMonthlyContribution, entity.Status.ToString());
}
