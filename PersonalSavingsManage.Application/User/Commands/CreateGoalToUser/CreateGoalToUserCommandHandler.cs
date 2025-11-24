using MediatR;
using PersonalSavingsManage.Core.Models;
using PersonalSavingsManage.Core.Repositories;

namespace PersonalSavingsManage.Application.User.Commands.CreateGoalToUser;

public class CreateGoalToUserCommandHandler : IRequestHandler<CreateGoalToUserCommand, ResultViewModel<Unit>>
{
    readonly IUserRepository _userRepository;

    public CreateGoalToUserCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<ResultViewModel<Unit>> Handle(CreateGoalToUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(request.UserId);

        if (user == null || user.IsDeleted == true)
            return ResultViewModel<Unit>.Error("User was not found or already deleted.");

        var imagePath = Path.Combine("ImageGoals", request.ImageGoal!.FileName);

        using Stream fileStream = new FileStream(imagePath, FileMode.Create);

        request.ImageGoal.CopyTo(fileStream);

        var financialGoal = new Core.Entities.FinancialGoal(
            request.Title,
            request.TargetAmount,
            imagePath,
            request.Deadline);

        financialGoal.CalculateIdealMonthlyContribution(request.Deadline, request.TargetAmount);

        await _userRepository.AddGoalToUserAsync(request.UserId, financialGoal);

        return ResultViewModel<Unit>.Success(Unit.Value);
    }
}
