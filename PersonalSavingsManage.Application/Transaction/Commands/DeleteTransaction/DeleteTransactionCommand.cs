using MediatR;
using PersonalSavingsManage.Core.Models;

namespace PersonalSavingsManage.Application.Transaction.Commands.DeleteTransaction;

public class DeleteTransactionCommand : IRequest<ResultViewModel<Unit>>
{
    public DeleteTransactionCommand(string id)
    {
        Id = id;
    }

    public string Id { get; private set; }
}
