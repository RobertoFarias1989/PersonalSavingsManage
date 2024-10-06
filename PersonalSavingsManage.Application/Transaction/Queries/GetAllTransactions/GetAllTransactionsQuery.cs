using MediatR;
using PersonalSavingsManage.Application.Transaction.ViewModel;

namespace PersonalSavingsManage.Application.Transaction.Queries.GetAllTransactions;

public class GetAllTransactionsQuery : IRequest<List<TransactionViewModel>>
{
}
