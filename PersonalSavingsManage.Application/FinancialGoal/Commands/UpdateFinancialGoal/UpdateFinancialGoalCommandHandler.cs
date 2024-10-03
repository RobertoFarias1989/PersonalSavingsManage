using MediatR;
using PersonalSavingsManage.Core.Repositories;

namespace PersonalSavingsManage.Application.FinancialGoal.Commands.UpdateFinancialGoal;

public class UpdateFinancialGoalCommandHandler : IRequestHandler<UpdateFinancialGoalCommand, Unit>
{
    private readonly IFinancialGoalRepository _repository;

    public UpdateFinancialGoalCommandHandler(IFinancialGoalRepository repository)
    {
        _repository = repository;
    }

    public async Task<Unit> Handle(UpdateFinancialGoalCommand request, CancellationToken cancellationToken)
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
