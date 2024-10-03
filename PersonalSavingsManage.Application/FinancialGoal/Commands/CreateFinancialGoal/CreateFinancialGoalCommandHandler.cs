using MediatR;
using PersonalSavingsManage.Core.Enums;
using PersonalSavingsManage.Core.Repositories;

namespace PersonalSavingsManage.Application.FinancialGoal.Commands.CreateFinancialGoal;

public class CreateFinancialGoalCommandHandler : IRequestHandler<CreateFinancialGoalCommand, string>
{
    private readonly IFinancialGoalRepository _repository;

    public CreateFinancialGoalCommandHandler(IFinancialGoalRepository repository)
    {
        _repository = repository;
    }

    public async Task<string> Handle(CreateFinancialGoalCommand request, CancellationToken cancellationToken)
    {
        var financialGoal = new Core.Entities.FinancialGoal(
            request.Title,
            request.TargetAmount,
            request.Deadline,           
            (FinancialGoalStatusEnum)Enum.Parse(typeof(FinancialGoalStatusEnum),request.Status));

        financialGoal.CalculateIdealMonthlyContribution(request.Deadline, request.TargetAmount);

        await _repository.AddAsync(financialGoal);

        return financialGoal.Id;
    }
}
