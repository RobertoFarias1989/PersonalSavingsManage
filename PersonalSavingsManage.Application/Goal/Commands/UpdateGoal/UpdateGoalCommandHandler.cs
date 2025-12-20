using MediatR;
using PersonalSavingsManage.Core.Repositories;

namespace PersonalSavingsManage.Application.FinancialGoal.Commands.UpdateFinancialGoal;

public class UpdateGoalCommandHandler : IRequestHandler<UpdateGoalCommand, Unit>
{
    private readonly IGoalRepository _repository;

    public UpdateGoalCommandHandler(IGoalRepository repository)
    {
        _repository = repository;
    }

    public async Task<Unit> Handle(UpdateGoalCommand request, CancellationToken cancellationToken)
    {
        var financialGoal = await _repository.GetByIdAsync(request.Id);

        if (financialGoal != null && financialGoal.IsDeleted != true)
        {
            financialGoal.Update(request.Title, request.TargetAmount, request.Deadline);

            financialGoal.CalculateIdealMonthlyContribution(request.Deadline, request.TargetAmount);

            await _repository.UpdateAsync(financialGoal);
        }
        else
        {
            throw new Exception("The FinancialGoal was not found or already deleted.");
        }

        return Unit.Value;
    }
}
