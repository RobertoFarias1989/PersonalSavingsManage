using MediatR;
using PersonalSavingsManage.Application.Transaction.ViewModel;
using PersonalSavingsManage.Core.Models;

namespace PersonalSavingsManage.Application.Transaction.Queries.GetTransactionById;

public class GetTransactionByIdQuery : IRequest<ResultViewModel<TransactionDetailsViewModel>>
{
    public GetTransactionByIdQuery(Guid id)
    {
        Id = id;
    }

    public Guid Id { get; private set; }
}
