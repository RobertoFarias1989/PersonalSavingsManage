using MediatR;

namespace PersonalSavingsManage.Application.Transaction.Commands.DeleteTransaction;

public class DeleteTransactionCommand : IRequest<Unit>
{
    public DeleteTransactionCommand(string id)
    {
        Id = id;
    }

    public string Id { get; private set; }
}
