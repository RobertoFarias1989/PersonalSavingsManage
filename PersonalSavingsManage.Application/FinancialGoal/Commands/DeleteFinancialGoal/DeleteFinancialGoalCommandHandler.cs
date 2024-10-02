using MediatR;
using PersonalSavingsManage.Core.Repositories;

namespace PersonalSavingsManage.Application.FinancialGoal.Commands.DeleteFinancialGoal;

public class DeleteFinancialGoalCommandHandler : IRequestHandler<DeleteFinancialGoalCommand, Unit>
{
    private readonly IFinancialGoalRepository _repository;

    public DeleteFinancialGoalCommandHandler(IFinancialGoalRepository repository)
    {
        _repository = repository;
    }

    public async Task<Unit> Handle(DeleteFinancialGoalCommand request, CancellationToken cancellationToken)
    {
        var financialGoal = await _repository.GetByIdAsync(request.Id);
        
        if (financialGoal != null && financialGoal.IsDeleted != true)
        {
            financialGoal.SetAsDelete();

            await _repository.UpdateAsync(financialGoal);
        }
        else
        {
            throw new Exception("");
        }

        return Unit.Value;
    }
}
