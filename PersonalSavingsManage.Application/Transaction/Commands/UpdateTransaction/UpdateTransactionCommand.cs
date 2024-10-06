using MediatR;

namespace PersonalSavingsManage.Application.Transaction.Commands.UpdateTransaction;

public class UpdateTransactionCommand : IRequest<Unit>
{
    public string Id { get; private set; }
    public decimal Amount { get; set; }
    public string Type { get; set; } = string.Empty;
}
