using MediatR;
using Microsoft.AspNetCore.Http;
using PersonalSavingsManage.Core.Models;

namespace PersonalSavingsManage.Application.User.Commands.CreateGoalToUser;

public class CreateGoalToUserCommand : IRequest<ResultViewModel<Guid>>
{
    public string Title { get; set; } = string.Empty;
    public decimal TargetAmount { get; set; }
    public IFormFile? ImageGoal { get; set; }
    public DateTime Deadline { get; set; }
    public Guid UserId { get; set; }
}
