using MediatR;
using Microsoft.AspNetCore.Http;
using PersonalSavingsManage.Core.Models;

namespace PersonalSavingsManage.Application.FinancialGoal.Commands.CreateFinancialGoal;

public class CreateGoalCommand : IRequest<ResultViewModel<int>>
{
    public string Title { get;  set; } = string.Empty;
    public decimal TargetAmount { get;  set; }
    public IFormFile? ImageGoal { get; set; }
    public DateTime Deadline { get;  set; }
    public string Status { get; set; } = string.Empty;
    public int IdUser { get;  set; }
}
