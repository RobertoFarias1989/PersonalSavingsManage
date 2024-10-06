using MediatR;
using PersonalSavingsManage.Core.Repositories;

namespace PersonalSavingsManage.Application.User.Commands.DeleteUser;

public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, Unit>
{
    private readonly IUserRepository _repository;

    public DeleteUserCommandHandler(IUserRepository repository)
    {
        _repository = repository;
    }

    public async Task<Unit> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _repository.GetByIdAsync(request.Id);

        if(user != null && user.IsDeleted != true)
        {
            user.SetAsDelete();

            await _repository.UpdateAsync(user);
        }
        else
        {
            throw new Exception("The User was not found or already deleted.");
        }

        return Unit.Value;
    }
}
