using MediatR;
using PersonalSavingsManage.Core.Models;
using PersonalSavingsManage.Core.Repositories;

namespace PersonalSavingsManage.Application.FinancialGoal.Commands.DeleteTransaction;

public class DeleteTransactionToGoalCommandHandler : IRequestHandler<DeleteTransactionToGoalCommand, ResultViewModel<Unit>>
{
    readonly IUserRepository _userRepository;

    public DeleteTransactionToGoalCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<ResultViewModel<Unit>> Handle(DeleteTransactionToGoalCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(request.UserId);

        if (user == null || user.IsDeleted == true)
            return ResultViewModel<Unit>.Error("User was not found or already deleted.");

        var goal = await _userRepository.GetUserGoalAsync(request.UserId, request.GoalId);

        if (goal == null || goal.IsDeleted == true)
            return ResultViewModel<Unit>.Error("Goal was not found or already deleted.");

        var transaction = goal.Transactions.Where(t => t.Id == request.Id).SingleOrDefault();

        if (transaction != null && transaction.IsDeleted != true)
        {
            transaction.SetAsDelete();

            await _userRepository.UpdateTransactionToGoalAsync(request.UserId, request.GoalId, transaction);

            //TODO: ao deletar uma Transaction deverá ser atualizado o saldo do FinancialGoal
        }
        else
        {
            return ResultViewModel<Unit>.Error("The Transaction was not found or already deleted.");            
        }

        return ResultViewModel<Unit>.Success(Unit.Value);
    }
}
