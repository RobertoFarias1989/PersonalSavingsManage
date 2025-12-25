using MediatR;
using PersonalSavingsManage.Core.Enums;
using PersonalSavingsManage.Core.Models;
using PersonalSavingsManage.Core.Repositories;

namespace PersonalSavingsManage.Application.FinancialGoal.Commands.CreateFinancialGoal;

public class CreateGoalCommandHandler : IRequestHandler<CreateGoalCommand, ResultViewModel<int>>
{
    private readonly IGoalRepository _goalRepository;
    private readonly IUserRepository _userRepository;

    public CreateGoalCommandHandler(IGoalRepository goalRepository, IUserRepository userRepository)
    {
        _goalRepository = goalRepository;
        _userRepository = userRepository;
    }

    public async Task<ResultViewModel<int>> Handle(CreateGoalCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(request.IdUser);

        if (user == null || user.IsDeleted == true)
            return ResultViewModel<int>.Error("User was not found or already deleted.");

        var imagePath = Path.Combine("ImageGoals", request.ImageGoal!.FileName);

        using Stream fileStream = new FileStream(imagePath, FileMode.Create);

        request.ImageGoal.CopyTo(fileStream);

        var financialGoal = new Core.Entities.Goal(
            request.Title,
            request.TargetAmount,
            imagePath,
            request.Deadline,           
            (GoalStatusEnum)Enum.Parse(typeof(GoalStatusEnum),request.Status),
            request.IdUser);

        financialGoal.CalculateIdealMonthlyContribution(request.Deadline, request.TargetAmount);

        await _goalRepository.AddAsync(financialGoal);

        return ResultViewModel<int>.Success(financialGoal.Id);
    }
}
