using MediatR;
using PersonalSavingsManage.Core.Enums;
using PersonalSavingsManage.Core.Models;
using PersonalSavingsManage.Core.Repositories;

namespace PersonalSavingsManage.Application.Transaction.Commands.CreateTransaction;

public class CreateTransactionCommandHandler : IRequestHandler<CreateTransactionCommand, ResultViewModel<int>>
{
    private readonly ITransactionRepository _transactionRepository;

    public CreateTransactionCommandHandler(ITransactionRepository transactionRepository)
    {
        _transactionRepository = transactionRepository;
    }

    public async Task<ResultViewModel<int>> Handle(CreateTransactionCommand request, CancellationToken cancellationToken)
    {
        var transaction = new Core.Entities.Transaction(
            request.Amount,
            (TransactionTypeEnum)Enum.Parse(typeof(TransactionTypeEnum),request.Type),
            request.IdUser,
            request.IdGoal);

        await _transactionRepository.AddAsync(transaction);

        return ResultViewModel<int>.Success(transaction.Id);
    }
}
