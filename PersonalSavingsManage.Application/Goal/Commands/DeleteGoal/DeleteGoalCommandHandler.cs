using MediatR;
using PersonalSavingsManage.Core.Models;
using PersonalSavingsManage.Core.Repositories;

namespace PersonalSavingsManage.Application.FinancialGoal.Commands.DeleteFinancialGoal;

public class DeleteGoalCommandHandler : IRequestHandler<DeleteGoalCommand, ResultViewModel<Unit>>
{
    private readonly IGoalRepository _goalRepository;

    public DeleteGoalCommandHandler(IGoalRepository goalRepository)
    {
        _goalRepository = goalRepository;
    }

    public async Task<ResultViewModel<Unit>> Handle(DeleteGoalCommand request, CancellationToken cancellationToken)
    {
        var financialGoal = await _goalRepository.GetByIdAsync(request.Id);
        
        if (financialGoal != null && financialGoal.IsDeleted != true)
        {
            financialGoal.SetAsDelete();

            await _goalRepository.UpdateAsync(financialGoal);
        }
        else
        {
            return ResultViewModel<Unit>.Error("The FinancialGoal was not found or already deleted.");
        }

        return ResultViewModel<Unit>.Success(Unit.Value);
    }
}
