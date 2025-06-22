using MediatR;
using PersonalSavingsManage.Application.Transaction.ViewModel;
using PersonalSavingsManage.Core.Models;

namespace PersonalSavingsManage.Application.Transaction.Queries.GetTransactionById;

public class GetTransactionByIdQuery : IRequest<ResultViewModel<TransactionDetailsViewModel>>
{
    public GetTransactionByIdQuery(string id)
    {
        Id = id;
    }

    public string Id { get; private set; }
}
