using MediatR;
using PersonalSavingsManage.Core.Enums;
using PersonalSavingsManage.Core.Models;
using PersonalSavingsManage.Core.Repositories;

namespace PersonalSavingsManage.Application.FinancialGoal.Commands.CreateFinancialGoal;

public class CreateFinancialGoalCommandHandler : IRequestHandler<CreateFinancialGoalCommand, ResultViewModel<Guid>>
{
    private readonly IFinancialGoalRepository _repository;
    private readonly IUserRepository _userRepository;

    public CreateFinancialGoalCommandHandler(IFinancialGoalRepository repository, IUserRepository userRepository)
    {
        _repository = repository;
        _userRepository = userRepository;
    }

    public async Task<ResultViewModel<Guid>> Handle(CreateFinancialGoalCommand request, CancellationToken cancellationToken)
    {
        var user = _userRepository.GetByIdAsync(request.UserId);

        if (user == null)
            return ResultViewModel<Guid>.Error("User was not found.");

        var imagePath = Path.Combine("ImageGoals", request.ImageGoal!.FileName);

        using Stream fileStream = new FileStream(imagePath, FileMode.Create);

        request.ImageGoal.CopyTo(fileStream);

        var financialGoal = new Core.Entities.FinancialGoal(
            request.Title,
            request.TargetAmount,
            imagePath,
            request.Deadline);

        financialGoal.CalculateIdealMonthlyContribution(request.Deadline, request.TargetAmount);

        await _repository.AddAsync(financialGoal);

        return ResultViewModel<Guid>.Success(financialGoal.Id);
    }
}
