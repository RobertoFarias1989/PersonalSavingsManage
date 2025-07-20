using MediatR;
using PersonalSavingsManage.Core.Models;

namespace PersonalSavingsManage.Application.User.Commands.DeleteUser;

public class DeleteUserCommand : IRequest<ResultViewModel>
{
    public DeleteUserCommand(string id)
    {
        Id = id;
    }

    public string Id { get; private set; }
}
