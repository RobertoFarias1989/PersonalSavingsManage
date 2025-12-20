using PersonalSavingsManage.Core.Enums;

namespace PersonalSavingsManage.Core.Entities;

public class Goal : BaseEntity
{
    public Goal(string title,
        decimal targetAmount,
        DateTime deadline,
        GoalStatusEnum status) : base()
    {
        Title = title;
        TargetAmount = targetAmount;
        Deadline = deadline;        
        Status = status;

        Transactions = new List<Transaction>();
    }

    public string Title { get; private set; }
    public decimal TargetAmount { get; private set; }
    public DateTime Deadline { get; private set; }
    public decimal IdealMonthlyContribution { get; private set; }
    public GoalStatusEnum Status { get; private set; }
    public List<Transaction> Transactions { get; private set; }

    public void Update(string title,
        decimal targetAmount,
        DateTime deadline )
    {
        Title = title;
        TargetAmount = targetAmount;
        Deadline = deadline;

        UpdatedAt = DateTime.Now;
    }

    public override void SetAsDelete()
    {
        if(Status != GoalStatusEnum.Complete)
        {
            IsDeleted = true;
            Status = GoalStatusEnum.Cancelled;
            UpdatedAt = DateTime.Now;
        }
        else
        {
            throw new Exception("It's not allow delete a FinancialGoal that was already complete.");
        }
    }

    //TODO: criar um método para calcular o campo IdealMonthlyContribution
    //a ideia é ao adicionar um novo registro realizar o cálculo desse campo automaticamente(dividir o TargetAmount pela quantidade de meses tendo por base o DeadLine)

    public void CalculateIdealMonthlyContribution(DateTime deadline, decimal targetAmount)
    {
        var monthAmount = deadline.Month - DateTime.Now.Month;

        var contribution = targetAmount / monthAmount;

        IdealMonthlyContribution = contribution;
    }
}
