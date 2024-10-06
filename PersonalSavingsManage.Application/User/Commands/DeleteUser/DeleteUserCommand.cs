using MediatR;

namespace PersonalSavingsManage.Application.User.Commands.DeleteUser;

public class DeleteUserCommand : IRequest<Unit>
{
    public DeleteUserCommand(string id)
    {
        Id = id;
    }

    public string Id { get; private set; }
}
