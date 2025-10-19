using MediatR;
using PersonalSavingsManage.Core.Models;

namespace PersonalSavingsManage.Application.User.Commands.DeleteUser;

public class DeleteUserCommand : IRequest<ResultViewModel>
{
    public DeleteUserCommand(Guid id)
    {
        Id = id;
    }

    public Guid Id { get; private set; }
}
