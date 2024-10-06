using MediatR;
using PersonalSavingsManage.Core.Repositories;

namespace PersonalSavingsManage.Application.Transaction.Commands.DeleteTransaction;

public class DeleteTransactionCommandHandler : IRequestHandler<DeleteTransactionCommand, Unit>
{
    private readonly ITransactionRepository _repository;

    public DeleteTransactionCommandHandler(ITransactionRepository repository)
    {
        _repository = repository;
    }

    public async Task<Unit> Handle(DeleteTransactionCommand request, CancellationToken cancellationToken)
    {
        var transaction = await _repository.GetByIdAsync(request.Id);

        if (transaction != null && transaction.IsDeleted != true)
        {
            transaction.SetAsDelete();

            await _repository.UpdateAsync(transaction);

            //TODO: ao deletar uma Transaction deverá ser atualizado o saldo do FinancialGoal
        }
        else
        {
            throw new Exception("The Transaction was not found or already deleted.");
        }

        return Unit.Value;
    }
}
