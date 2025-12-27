using MediatR;
using PersonalSavingsManage.Core.Models;

namespace PersonalSavingsManage.Application.Transaction.Commands.UpdateTransaction;

public class UpdateTransactionCommand : IRequest<ResultViewModel<Unit>>
{
    public int Id { get;  set; }
    public decimal Amount { get; set; }
    public string Type { get; set; } = string.Empty;
}
