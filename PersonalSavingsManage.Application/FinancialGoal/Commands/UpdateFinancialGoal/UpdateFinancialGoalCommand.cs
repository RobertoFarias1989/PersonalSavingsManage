using MediatR;
using Microsoft.AspNetCore.Http;
using PersonalSavingsManage.Core.Models;

namespace PersonalSavingsManage.Application.FinancialGoal.Commands.UpdateFinancialGoal;

public class UpdateFinancialGoalCommand : IRequest<ResultViewModel<Unit>>
{

    public string Id { get;  set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public decimal TargetAmount { get; set; }
    public IFormFile? ImageGoal { get; set; }
    public DateTime Deadline { get; set; }
}
