using MediatR;
using PersonalSavingsManage.Application.Transaction.ViewModel;
using PersonalSavingsManage.Core.Models;

namespace PersonalSavingsManage.Application.Transaction.Queries.GetAllTransactions;

public class GetAllTransactionsQuery : IRequest<ResultViewModel<List<TransactionViewModel>>>
{
}
