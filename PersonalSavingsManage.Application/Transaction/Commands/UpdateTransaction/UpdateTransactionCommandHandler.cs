using MediatR;
using PersonalSavingsManage.Core.Enums;
using PersonalSavingsManage.Core.Repositories;

namespace PersonalSavingsManage.Application.Transaction.Commands.UpdateTransaction;

public class UpdateTransactionCommandHandler : IRequestHandler<UpdateTransactionCommand, Unit>
{
    private readonly ITransactionRepository _repository;

    public UpdateTransactionCommandHandler(ITransactionRepository repository)
    {
        _repository = repository;
    }

    public async Task<Unit> Handle(UpdateTransactionCommand request, CancellationToken cancellationToken)
    {
        var transaction = await _repository.GetByIdAsync(request.Id);


        if (transaction != null && transaction.IsDeleted != true)
        {
            transaction.Update(request.Amount, (TransactionTypeEnum)Enum.Parse(typeof(TransactionTypeEnum), request.Type));

            await _repository.UpdateAsync(transaction);

            //TODO: ver se faz sentido permitir mudar o Type da Transaction
            //se sim, ver tratamento para o impacto disso no saldo do FinancialGoal
        }
        else
        {
            throw new Exception("The Transaction was not found or already deleted.");
        }

        return Unit.Value;
    }
}
