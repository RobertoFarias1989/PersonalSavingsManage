using MediatR;

namespace PersonalSavingsManage.Application.FinancialGoal.Commands.UpdateFinancialGoal;

public class UpdateFinancialGoalCommand : IRequest<Unit>
{

    public string Id { get;  set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public decimal TargetAmount { get; set; }
    public DateTime Deadline { get; set; }
}
