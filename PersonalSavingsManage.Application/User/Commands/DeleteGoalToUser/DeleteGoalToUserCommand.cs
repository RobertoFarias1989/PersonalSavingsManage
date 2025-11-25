using MediatR;
using PersonalSavingsManage.Core.Models;

namespace PersonalSavingsManage.Application.User.Commands.DeleteGoalToUser;

public class DeleteGoalToUserCommand : IRequest<ResultViewModel<Unit>>
{
    public DeleteGoalToUserCommand(Guid id, Guid userId)
    {
        Id = id;
        UserId = userId;
    }

    public Guid Id { get; private set; }
    public Guid UserId { get; private set; }
}
