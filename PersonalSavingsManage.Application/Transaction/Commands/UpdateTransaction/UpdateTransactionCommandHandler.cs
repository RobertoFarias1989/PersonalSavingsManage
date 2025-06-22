using MediatR;
using PersonalSavingsManage.Core.Enums;
using PersonalSavingsManage.Core.Models;
using PersonalSavingsManage.Core.Repositories;

namespace PersonalSavingsManage.Application.Transaction.Commands.UpdateTransaction;

public class UpdateTransactionCommandHandler : IRequestHandler<UpdateTransactionCommand, ResultViewModel<Unit>>
{
    private readonly ITransactionRepository _repository;

    public UpdateTransactionCommandHandler(ITransactionRepository repository)
    {
        _repository = repository;
    }

    public async Task<ResultViewModel<Unit>> Handle(UpdateTransactionCommand request, CancellationToken cancellationToken)
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
            return ResultViewModel<Unit>.Error("The Transaction was not found or already deleted.");            
        }

        return ResultViewModel<Unit>.Success(Unit.Value);
    }
}
