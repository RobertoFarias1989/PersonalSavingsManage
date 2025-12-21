using MediatR;

namespace PersonalSavingsManage.Application.Transaction.Commands.DeleteTransaction;

public class DeleteTransactionCommand : IRequest<Unit>
{
    public DeleteTransactionCommand(int id)
    {
        Id = id;
    }

    public int Id { get; private set; }
}
