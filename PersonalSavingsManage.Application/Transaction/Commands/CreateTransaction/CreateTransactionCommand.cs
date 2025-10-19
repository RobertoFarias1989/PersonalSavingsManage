using MediatR;
using PersonalSavingsManage.Core.Models;

namespace PersonalSavingsManage.Application.Transaction.Commands.CreateTransaction;

public class CreateTransactionCommand : IRequest<ResultViewModel<Guid>>
{
    public decimal Amount { get;  set; }
    public string Type { get; set; } = string.Empty;
}
