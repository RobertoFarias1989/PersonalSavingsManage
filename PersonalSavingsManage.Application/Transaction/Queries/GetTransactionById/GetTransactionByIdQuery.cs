using MediatR;
using PersonalSavingsManage.Application.Transaction.ViewModel;

namespace PersonalSavingsManage.Application.Transaction.Queries.GetTransactionById;

public class GetTransactionByIdQuery : IRequest<TransactionDetailsViewModel>
{
    public GetTransactionByIdQuery(string id)
    {
        Id = id;
    }

    public string Id { get; private set; }
}
