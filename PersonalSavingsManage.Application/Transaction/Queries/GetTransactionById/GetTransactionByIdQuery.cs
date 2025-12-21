using MediatR;
using PersonalSavingsManage.Application.Transaction.ViewModel;

namespace PersonalSavingsManage.Application.Transaction.Queries.GetTransactionById;

public class GetTransactionByIdQuery : IRequest<TransactionDetailsViewModel>
{
    public GetTransactionByIdQuery(int id)
    {
        Id = id;
    }

    public int Id { get; private set; }
}
