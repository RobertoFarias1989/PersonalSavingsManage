﻿using PersonalSavingsManage.Core.Enums;

namespace PersonalSavingsManage.Core.Entities;

public class FinancialGoal : BaseEntity
{
    public FinancialGoal(string title,
        decimal targetAmount,
        DateTime deadline,
        decimal idealMonthlyContribution,
        FinancialGoalStatusEnum status) : base()
    {
        Title = title;
        TargetAmount = targetAmount;
        Deadline = deadline;
        IdealMonthlyContribution = idealMonthlyContribution;
        Status = status;

        Transactions = new List<Transaction>();
    }

    public string Title { get; private set; }
    public decimal TargetAmount { get; private set; }
    public DateTime Deadline { get; private set; }
    public decimal IdealMonthlyContribution { get; private set; }
    public FinancialGoalStatusEnum Status { get; private set; }
    public List<Transaction> Transactions { get; private set; }

    private void Update(string title,
        decimal targetAmount,
        DateTime deadline,
        decimal idealMonthlyContribution)
    {
        Title = title;
        TargetAmount = targetAmount;
        Deadline = deadline;
        IdealMonthlyContribution = idealMonthlyContribution;
    }



}
