using MediatR;
using PersonalSavingsManage.Core.Repositories;

namespace PersonalSavingsManage.Application.FinancialGoal.Commands.DeleteFinancialGoal;

public class DeleteGoalCommandHandler : IRequestHandler<DeleteGoalCommand, Unit>
{
    private readonly IGoalRepository _repository;

    public DeleteGoalCommandHandler(IGoalRepository repository)
    {
        _repository = repository;
    }

    public async Task<Unit> Handle(DeleteGoalCommand request, CancellationToken cancellationToken)
    {
        var financialGoal = await _repository.GetByIdAsync(request.Id);
        
        if (financialGoal != null && financialGoal.IsDeleted != true)
        {
            financialGoal.SetAsDelete();

            await _repository.UpdateAsync(financialGoal);
        }
        else
        {
            throw new Exception("The FinancialGoal was not found or already deleted.");
        }

        return Unit.Value;
    }
}
