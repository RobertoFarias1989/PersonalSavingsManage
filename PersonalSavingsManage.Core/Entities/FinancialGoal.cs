using PersonalSavingsManage.Core.Enums;
using PersonalSavingsManage.Core.Models;
using static System.Net.Mime.MediaTypeNames;

namespace PersonalSavingsManage.Core.Entities;

public class FinancialGoal : BaseEntity
{
    public FinancialGoal(string title,
        decimal targetAmount,
        string imageGoal,
        DateTime deadline,
        FinancialGoalStatusEnum status) : base()
    {
        Title = title;
        TargetAmount = targetAmount;
        ImageGoal = imageGoal;
        Deadline = deadline;        
        Status = status;

        Transactions = new List<Transaction>();
    }

    public string Title { get; private set; }
    public decimal TargetAmount { get; private set; }
    public string ImageGoal { get; set; }
    public DateTime Deadline { get; private set; }
    public decimal IdealMonthlyContribution { get; private set; }
    public FinancialGoalStatusEnum Status { get; private set; }
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

    public override ResultViewModel SetAsDelete()
    {
        if(Status != FinancialGoalStatusEnum.Complete)
        {
            IsDeleted = true;
            Status = FinancialGoalStatusEnum.Cancelled;
            UpdatedAt = DateTime.Now;
        }
        else
        {
            return ResultViewModel.Error("It's not allow delete a FinancialGoal that was already complete.");         
        }

        return ResultViewModel.Success();
    }

    //TODO: criar um método para calcular o campo IdealMonthlyContribution
    //a ideia é ao adicionar um novo registro realizar o cálculo desse campo automaticamente(dividir o TargetAmount pela quantidade de meses tendo por base o DeadLine)

    public void CalculateIdealMonthlyContribution(DateTime deadline, decimal targetAmount)
    {
        var monthAmount = deadline.Month - DateTime.Now.Month;

        var contribution = targetAmount / monthAmount;

        IdealMonthlyContribution = contribution;
    }

    public void UpdateImageGoal(string path)
    {
        ImageGoal = path;
    }
}
