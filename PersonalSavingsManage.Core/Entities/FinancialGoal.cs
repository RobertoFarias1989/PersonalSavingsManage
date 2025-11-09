using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using PersonalSavingsManage.Core.Enums;
using PersonalSavingsManage.Core.Models;
using System.Text.Json.Serialization;

namespace PersonalSavingsManage.Core.Entities;

public class FinancialGoal : BaseEntity
{
    public FinancialGoal(string title,
        decimal targetAmount,
        string imageGoal,
        DateTime deadline) : base()
    {
        Title = title;
        TargetAmount = targetAmount;
        ImageGoal = imageGoal;
        Deadline = deadline;
        
        Status = FinancialGoalStatusEnum.InProgress;
        Transactions = new List<Transaction>();
    }

    public string Title { get; private set; }
    public decimal TargetAmount { get; private set; }
    public string ImageGoal { get; set; }
    public DateTime Deadline { get; private set; }
    public decimal IdealMonthlyContribution { get; private set; }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    [BsonRepresentation(BsonType.String)]
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

    public void CalculateIdealMonthlyContribution(DateTime deadline, decimal targetAmount)
    {
        var monthAmount = Math.Abs((deadline.Month - DateTime.Now.Month) + 12 * (deadline.Year - DateTime.Now.Year));

        var contribution = Math.Round(targetAmount / monthAmount);

        IdealMonthlyContribution = contribution;
    }

    public void UpdateImageGoal(string path)
    {
        ImageGoal = path;
    }
}
