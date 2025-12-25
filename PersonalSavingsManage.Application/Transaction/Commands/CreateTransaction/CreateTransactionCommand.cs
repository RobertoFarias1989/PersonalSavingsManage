using MediatR;
using PersonalSavingsManage.Core.Models;

namespace PersonalSavingsManage.Application.Transaction.Commands.CreateTransaction;

public class CreateTransactionCommand : IRequest<ResultViewModel<int>>
{
    public decimal Amount { get;  set; }
    public string Type { get; set; } = string.Empty;
    public int IdUser { get;  set; }
    public int IdGoal { get;  set; }
}
