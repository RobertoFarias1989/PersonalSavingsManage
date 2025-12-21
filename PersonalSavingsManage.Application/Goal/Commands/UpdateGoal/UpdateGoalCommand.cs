using MediatR;

namespace PersonalSavingsManage.Application.FinancialGoal.Commands.UpdateFinancialGoal;

public class UpdateGoalCommand : IRequest<Unit>
{

    public int Id { get;  set; }
    public string Title { get; set; } = string.Empty;
    public decimal TargetAmount { get; set; }
    public DateTime Deadline { get; set; }
}
