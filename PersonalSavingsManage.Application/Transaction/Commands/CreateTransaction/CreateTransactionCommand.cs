using MediatR;

namespace PersonalSavingsManage.Application.Transaction.Commands.CreateTransaction;

public class CreateTransactionCommand : IRequest<string>
{
    public decimal Amount { get;  set; }
    public string Type { get; set; } = string.Empty;
}
