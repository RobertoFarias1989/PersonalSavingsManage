using MediatR;
using PersonalSavingsManage.Core.Models;

namespace PersonalSavingsManage.Application.Transaction.Commands.DeleteTransaction;

public class DeleteTransactionCommand : IRequest<ResultViewModel<Unit>>
{
    public DeleteTransactionCommand(Guid id)
    {
        Id = id;
    }

    public Guid Id { get; private set; }
}
