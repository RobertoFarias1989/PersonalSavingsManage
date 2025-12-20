using MediatR;
using PersonalSavingsManage.Core.Enums;
using PersonalSavingsManage.Core.Repositories;

namespace PersonalSavingsManage.Application.FinancialGoal.Commands.CreateFinancialGoal;

public class CreateGoalCommandHandler : IRequestHandler<CreateGoalCommand, string>
{
    private readonly IGoalRepository _repository;

    public CreateGoalCommandHandler(IGoalRepository repository)
    {
        _repository = repository;
    }

    public async Task<string> Handle(CreateGoalCommand request, CancellationToken cancellationToken)
    {
        var financialGoal = new Core.Entities.Goal(
            request.Title,
            request.TargetAmount,
            request.Deadline,           
            (GoalStatusEnum)Enum.Parse(typeof(GoalStatusEnum),request.Status));

        financialGoal.CalculateIdealMonthlyContribution(request.Deadline, request.TargetAmount);

        await _repository.AddAsync(financialGoal);

        return financialGoal.Id;
    }
}
