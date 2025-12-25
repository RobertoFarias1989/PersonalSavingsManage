using MediatR;
using PersonalSavingsManage.Core.Models;
using PersonalSavingsManage.Core.Repositories;

namespace PersonalSavingsManage.Application.FinancialGoal.Commands.UpdateFinancialGoal;

public class UpdateGoalCommandHandler : IRequestHandler<UpdateGoalCommand, ResultViewModel<Unit>>
{
    private readonly IGoalRepository _goalRepository;

    public UpdateGoalCommandHandler(IGoalRepository goalRepository)
    {
        _goalRepository = goalRepository;
    }

    public async Task<ResultViewModel<Unit>> Handle(UpdateGoalCommand request, CancellationToken cancellationToken)
    {
        var financialGoal = await _goalRepository.GetByIdAsync(request.Id);

        if (financialGoal != null && financialGoal.IsDeleted != true)
        {
            financialGoal.Update(request.Title, request.TargetAmount, request.Deadline);

            financialGoal.CalculateIdealMonthlyContribution(request.Deadline, request.TargetAmount);

            await _goalRepository.UpdateAsync(financialGoal);
        }
        else
        {
            return ResultViewModel<Unit>.Error("The FinancialGoal was not found or already deleted.");
        }

        return ResultViewModel<Unit>.Success(Unit.Value);
    }
}
