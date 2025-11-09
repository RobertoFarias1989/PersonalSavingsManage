using MediatR;
using Microsoft.AspNetCore.Http;
using PersonalSavingsManage.Core.Models;

namespace PersonalSavingsManage.Application.User.Commands.UpdateGoalToUser;

public class UpdateGoalToUserCommand : IRequest<ResultViewModel<Unit>>
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public string Title { get; set; } = string.Empty;
    public decimal TargetAmount { get; set; }
    public IFormFile? ImageGoal { get; set; }
    public DateTime Deadline { get; set; }
}
