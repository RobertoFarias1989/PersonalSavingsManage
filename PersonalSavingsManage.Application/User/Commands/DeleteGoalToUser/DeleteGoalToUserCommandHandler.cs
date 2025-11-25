using MediatR;
using PersonalSavingsManage.Core.Models;
using PersonalSavingsManage.Core.Repositories;

namespace PersonalSavingsManage.Application.User.Commands.DeleteGoalToUser;

public class DeleteGoalToUserCommandHandler : IRequestHandler<DeleteGoalToUserCommand, ResultViewModel<Unit>>
{
    readonly IUserRepository _userRepository;

    public DeleteGoalToUserCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<ResultViewModel<Unit>> Handle(DeleteGoalToUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(request.UserId);

        if (user == null || user.IsDeleted == true)
            return ResultViewModel<Unit>.Error("User was not found or already deleted.");

        var goal = await _userRepository.GetUserGoalAsync(request.UserId, request.Id);

        if(goal != null && goal.IsDeleted != true)
        {
            goal.SetAsDelete();

            await _userRepository.UpdateGoalToUserAsync(request.UserId, goal);
        }
        else
        {
            return ResultViewModel<Unit>.Error("The Goal was not found or already deleted.");
        }

        return ResultViewModel<Unit>.Success(Unit.Value);
    }
}
