using MediatR;
using PersonalSavingsManage.Core.Enums;
using PersonalSavingsManage.Core.Models;
using PersonalSavingsManage.Core.Repositories;

namespace PersonalSavingsManage.Application.Transaction.Commands.CreateTransaction;

public class CreateTransactionCommandHandler : IRequestHandler<CreateTransactionCommand, ResultViewModel<string>>
{
    private readonly ITransactionRepository _repository;

    public CreateTransactionCommandHandler(ITransactionRepository repository)
    {
        _repository = repository;
    }

    public async Task<ResultViewModel<string>> Handle(CreateTransactionCommand request, CancellationToken cancellationToken)
    {
        var transaction = new Core.Entities.Transaction(
            request.Amount,
            (TransactionTypeEnum)Enum.Parse(typeof(TransactionTypeEnum),request.Type));

        await _repository.AddAsync(transaction);

        return ResultViewModel<string>.Success(transaction.Id);
    }
}
