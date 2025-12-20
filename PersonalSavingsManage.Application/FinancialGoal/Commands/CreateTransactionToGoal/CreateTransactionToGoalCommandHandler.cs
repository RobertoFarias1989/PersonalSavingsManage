using MediatR;
using PersonalSavingsManage.Core.Enums;
using PersonalSavingsManage.Core.Models;
using PersonalSavingsManage.Core.Repositories;

namespace PersonalSavingsManage.Application.FinancialGoal.Commands.CreateTransaction;

public class CreateTransactionToGoalCommandHandler : IRequestHandler<CreateTransactionToGoalCommand, ResultViewModel<Unit>>
{
    readonly IUserRepository _userRepository;

    public CreateTransactionToGoalCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<ResultViewModel<Unit>> Handle(CreateTransactionToGoalCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(request.UserId);

        if (user == null || user.IsDeleted == true)
            return ResultViewModel<Unit>.Error("User was not found or already deleted.");

        var goal = await _userRepository.GetUserGoalAsync(request.UserId, request.GoalId);

        if (goal == null || goal.IsDeleted == true)
            return ResultViewModel<Unit>.Error("Goal was not found or already deleted.");

        //var transaction = new Core.Entities.Transaction(
        //    request.Amount,
        //    (TransactionTypeEnum)Enum.Parse(typeof(TransactionTypeEnum),request.Type));

        var transaction = new Core.Entities.Transaction(
           request.Amount,
           request.Type);

        await _userRepository.AddTransactionToGoalAsync(request.UserId, request.GoalId, transaction);

        return ResultViewModel<Unit>.Success(Unit.Value);
    }
}
