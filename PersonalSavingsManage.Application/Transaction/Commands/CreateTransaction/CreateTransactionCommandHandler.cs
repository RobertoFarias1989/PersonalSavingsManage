using MediatR;
using PersonalSavingsManage.Core.Enums;
using PersonalSavingsManage.Core.Repositories;

namespace PersonalSavingsManage.Application.Transaction.Commands.CreateTransaction;

public class CreateTransactionCommandHandler : IRequestHandler<CreateTransactionCommand, string>
{
    private readonly ITransactionRepository _repository;

    public CreateTransactionCommandHandler(ITransactionRepository repository)
    {
        _repository = repository;
    }

    public async Task<string> Handle(CreateTransactionCommand request, CancellationToken cancellationToken)
    {
        var transaction = new Core.Entities.Transaction(
            request.Amount,
            (TransactionTypeEnum)Enum.Parse(typeof(TransactionTypeEnum),request.Type));

        await _repository.AddAsync(transaction);

        return transaction.Id;
    }
}
