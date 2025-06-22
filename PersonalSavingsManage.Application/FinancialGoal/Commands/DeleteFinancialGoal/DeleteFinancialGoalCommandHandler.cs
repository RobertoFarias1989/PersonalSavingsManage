using MediatR;
using PersonalSavingsManage.Core.Models;
using PersonalSavingsManage.Core.Repositories;

namespace PersonalSavingsManage.Application.FinancialGoal.Commands.DeleteFinancialGoal;

public class DeleteFinancialGoalCommandHandler : IRequestHandler<DeleteFinancialGoalCommand, ResultViewModel<Unit>>
{
    private readonly IFinancialGoalRepository _repository;

    public DeleteFinancialGoalCommandHandler(IFinancialGoalRepository repository)
    {
        _repository = repository;
    }

    public async Task<ResultViewModel<Unit>> Handle(DeleteFinancialGoalCommand request, CancellationToken cancellationToken)
    {
        var financialGoal = await _repository.GetByIdAsync(request.Id);
        
        if (financialGoal != null && financialGoal.IsDeleted != true)
        {
            financialGoal.SetAsDelete();

            await _repository.UpdateAsync(financialGoal);
        }
        else
        {
            return ResultViewModel<Unit>.Error("The FinancialGoal was not found or already deleted.");            
        }

        return ResultViewModel<Unit>.Success(Unit.Value);
    }
}
