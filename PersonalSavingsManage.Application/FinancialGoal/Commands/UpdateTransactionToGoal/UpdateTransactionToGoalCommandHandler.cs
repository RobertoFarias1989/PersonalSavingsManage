using MediatR;
using PersonalSavingsManage.Core.Enums;
using PersonalSavingsManage.Core.Models;
using PersonalSavingsManage.Core.Repositories;

namespace PersonalSavingsManage.Application.FinancialGoal.Commands.UpdateTransaction;

public class UpdateTransactionToGoalCommandHandler : IRequestHandler<UpdateTransactionToGoalCommand, ResultViewModel<Unit>>
{
    readonly IUserRepository _userRepository;

    public UpdateTransactionToGoalCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<ResultViewModel<Unit>> Handle(UpdateTransactionToGoalCommand request, CancellationToken cancellationToken)
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
            transaction.Update(request.Amount, (TransactionTypeEnum)Enum.Parse(typeof(TransactionTypeEnum), request.Type));

            await _userRepository.UpdateTransactionToGoalAsync(request.UserId, request.GoalId, transaction);
        }
        else
        {
            return ResultViewModel<Unit>.Error("The Transaction was not found or already deleted.");            
        }

        return ResultViewModel<Unit>.Success(Unit.Value);
    }
}
