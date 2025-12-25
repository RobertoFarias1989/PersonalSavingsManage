using MediatR;
using PersonalSavingsManage.Core.Models;

namespace PersonalSavingsManage.Application.FinancialGoal.Commands.UpdateFinancialGoal;

public class UpdateGoalCommand : IRequest<ResultViewModel<Unit>>
{

    public int Id { get;  set; }
    public string Title { get; set; } = string.Empty;
    public decimal TargetAmount { get; set; }
    public DateTime Deadline { get; set; }
}
