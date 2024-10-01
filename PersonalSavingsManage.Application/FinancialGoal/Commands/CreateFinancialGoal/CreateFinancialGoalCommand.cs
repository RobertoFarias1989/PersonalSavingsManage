using MediatR;

namespace PersonalSavingsManage.Application.FinancialGoal.Commands.CreateFinancialGoal;

public class CreateFinancialGoalCommand : IRequest<string>
{
    public string Title { get;  set; } = string.Empty;
    public decimal TargetAmount { get;  set; }
    public DateTime Deadline { get;  set; }
    public decimal IdealMonthlyContribution { get;  set; }
    public string Status { get; set; } = string.Empty;
}
