namespace PersonalSavingsManage.Application.FinancialGoal.ViewModels;

public class GoalViewModel
{
    public GoalViewModel(int id,
        string title, decimal targetAmount, string imageGoal, DateTime deadline, decimal idealMonthlyContribution, string status, int idUser)
    {
        Id = id;
        Title = title;
        TargetAmount = targetAmount;
        ImageGoal = imageGoal;
        Deadline = deadline;
        IdealMonthlyContribution = idealMonthlyContribution;
        Status = status;
        IdUser = idUser;
    }

    public int Id { get; private set; }
    public string Title { get; private set; }
    public decimal TargetAmount { get; private set; }
    public string ImageGoal { get; private set; }
    public DateTime Deadline { get; private set; }
    public decimal IdealMonthlyContribution { get; private set; }
    public string Status { get; private set; }
    public int IdUser { get; private set; }

    public static GoalViewModel FromEntity(Core.Entities.Goal entity)
    => new GoalViewModel(entity.Id, entity.Title, entity.TargetAmount, entity.ImageGoal,
        entity.Deadline, entity.IdealMonthlyContribution,
        entity.Status.ToString(), entity.IdUser);
}
