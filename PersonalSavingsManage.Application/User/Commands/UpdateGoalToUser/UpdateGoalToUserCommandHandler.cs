using MediatR;
using PersonalSavingsManage.Core.Models;
using PersonalSavingsManage.Core.Repositories;

namespace PersonalSavingsManage.Application.User.Commands.UpdateGoalToUser;

public class UpdateGoalToUserCommandHandler : IRequestHandler<UpdateGoalToUserCommand, ResultViewModel<Unit>>
{
    readonly IUserRepository _userRepository;

    public UpdateGoalToUserCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<ResultViewModel<Unit>> Handle(UpdateGoalToUserCommand request, CancellationToken cancellationToken)
    {

        var user = await _userRepository.GetByIdAsync(request.UserId);

        if (user == null || user.IsDeleted == true)
            return ResultViewModel<Unit>.Error("User was not found or already deleted.");

        var financialGoal = await _userRepository.GetUserGoalAsync(request.UserId, request.Id);

        if (financialGoal != null && financialGoal.IsDeleted != true)
        {

            if (request.ImageGoal != null)
            {
                var olderImagePath = financialGoal.ImageGoal;
                var imagePath = Path.Combine("ImageGoals", request.ImageGoal!.FileName);

                if (!string.IsNullOrEmpty(olderImagePath) && File.Exists(olderImagePath))
                {
                    File.Delete(olderImagePath);
                }

                using Stream fileStream = new FileStream(imagePath, FileMode.Create);
                request.ImageGoal.CopyTo(fileStream);
                financialGoal.UpdateImageGoal(imagePath);
            }

            financialGoal.Update(request.Title, request.TargetAmount, request.Deadline);

            financialGoal.CalculateIdealMonthlyContribution(request.Deadline, request.TargetAmount);

            await _userRepository.UpdateGoalToUserAsync(request.UserId, financialGoal);
        }
        else
        {
            return ResultViewModel<Unit>.Error("The FinancialGoal was not found or already deleted.");
        }

        return ResultViewModel<Unit>.Success(Unit.Value);
    }
}
