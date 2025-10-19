using MediatR;
using PersonalSavingsManage.Core.Enums;
using PersonalSavingsManage.Core.Models;
using PersonalSavingsManage.Core.Repositories;

namespace PersonalSavingsManage.Application.FinancialGoal.Commands.CreateFinancialGoal;

public class CreateFinancialGoalCommandHandler : IRequestHandler<CreateFinancialGoalCommand, ResultViewModel<Guid>>
{
    private readonly IFinancialGoalRepository _repository;

    public CreateFinancialGoalCommandHandler(IFinancialGoalRepository repository)
    {
        _repository = repository;
    }

    public async Task<ResultViewModel<Guid>> Handle(CreateFinancialGoalCommand request, CancellationToken cancellationToken)
    {
        var imagePath = Path.Combine("ImageGoals", request.ImageGoal!.FileName);

        using Stream fileStream = new FileStream(imagePath, FileMode.Create);

        var financialGoal = new Core.Entities.FinancialGoal(
            request.Title,
            request.TargetAmount,
            imagePath,
            request.Deadline,           
            (FinancialGoalStatusEnum)Enum.Parse(typeof(FinancialGoalStatusEnum),request.Status));

        financialGoal.CalculateIdealMonthlyContribution(request.Deadline, request.TargetAmount);

        await _repository.AddAsync(financialGoal);

        return ResultViewModel<Guid>.Success(financialGoal.Id);
    }
}
