using MediatR;
using PersonalSavingsManage.Core.Models;

namespace PersonalSavingsManage.Application.Transaction.Commands.DeleteTransaction;

public class DeleteTransactionCommand : IRequest<ResultViewModel<Unit>>
{
    public DeleteTransactionCommand(int id)
    {
        Id = id;
    }

    public int Id { get; private set; }
}
