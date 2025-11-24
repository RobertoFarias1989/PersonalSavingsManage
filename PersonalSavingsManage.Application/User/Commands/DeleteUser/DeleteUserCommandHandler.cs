using MediatR;
using PersonalSavingsManage.Core.Models;
using PersonalSavingsManage.Core.Repositories;

namespace PersonalSavingsManage.Application.User.Commands.DeleteUser;

public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, ResultViewModel>
{
    readonly IUserRepository _repository;

    public DeleteUserCommandHandler(IUserRepository repository)
    {
        _repository = repository;
    }

    public async Task<ResultViewModel> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _repository.GetByIdAsync(request.Id);

        if(user != null && user.IsDeleted != true)
        {
            user.SetAsDelete();

            await _repository.UpdateAsync(user);
        }
        else
        {
            return ResultViewModel.Error("The User was not found or already deleted.");            
        }

        return ResultViewModel.Success();
    }
}
