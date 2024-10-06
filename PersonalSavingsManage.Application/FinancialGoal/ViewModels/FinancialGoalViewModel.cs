namespace PersonalSavingsManage.Application.FinancialGoal.ViewModels;

public class FinancialGoalViewModel
{
    public FinancialGoalViewModel(string id,
        string title, decimal targetAmount, DateTime deadline, decimal idealMonthlyContribution, string status)
    {
        Id = id;
        Title = title;
        TargetAmount = targetAmount;
        Deadline = deadline;
        IdealMonthlyContribution = idealMonthlyContribution;
        Status = status;
    }

    public string Id { get; private set; }
    public string Title { get; private set; }
    public decimal TargetAmount { get; private set; }
    public DateTime Deadline { get; private set; }
    public decimal IdealMonthlyContribution { get; private set; }
    public string Status { get; private set; }
}
