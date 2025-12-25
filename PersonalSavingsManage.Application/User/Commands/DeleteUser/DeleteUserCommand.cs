using MediatR;
using PersonalSavingsManage.Core.Models;

namespace PersonalSavingsManage.Application.User.Commands.DeleteUser;

public class DeleteUserCommand : IRequest<ResultViewModel<Unit>>
{
    public DeleteUserCommand(int id)
    {
        Id = id;
    }

    public int Id { get; private set; }
}
