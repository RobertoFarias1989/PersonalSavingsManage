using MediatR;
using PersonalSavingsManage.Core.Models;
using PersonalSavingsManage.Core.Repositories;

namespace PersonalSavingsManage.Application.Transaction.Commands.DeleteTransaction;

public class DeleteTransactionCommandHandler : IRequestHandler<DeleteTransactionCommand, ResultViewModel<Unit>>
{
    private readonly ITransactionRepository _transactionRepository;

    public DeleteTransactionCommandHandler(ITransactionRepository transactionRepository)
    {
        _transactionRepository = transactionRepository;
    }

    public async Task<ResultViewModel<Unit>> Handle(DeleteTransactionCommand request, CancellationToken cancellationToken)
    {
        var transaction = await _transactionRepository.GetByIdAsync(request.Id);

        if (transaction != null && transaction.IsDeleted != true)
        {
            transaction.SetAsDelete();

            await _transactionRepository.UpdateAsync(transaction);

            //TODO: ao deletar uma Transaction deverá ser atualizado o saldo do FinancialGoal
        }
        else
        {
            return ResultViewModel<Unit>.Error("The Transaction was not found or already deleted.");
        }

        return ResultViewModel<Unit>.Success(Unit.Value);
    }
}
