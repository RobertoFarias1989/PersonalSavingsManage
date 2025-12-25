using MediatR;
using PersonalSavingsManage.Application.Transaction.ViewModel;
using PersonalSavingsManage.Core.Models;
using PersonalSavingsManage.Core.Repositories;

namespace PersonalSavingsManage.Application.Transaction.Queries.GetAllTransactions;

public class GetAllTransactionsQueryHandler : IRequestHandler<GetAllTransactionsQuery, ResultViewModel<List<TransactionViewModel>>>
{
    private readonly ITransactionRepository _transactionRepository;

    public GetAllTransactionsQueryHandler(ITransactionRepository transactionRepository)
    {
        _transactionRepository = transactionRepository;
    }

    public async Task<ResultViewModel<List<TransactionViewModel>>> Handle(GetAllTransactionsQuery request, CancellationToken cancellationToken)
    {
        var transactions = await _transactionRepository.GetAllAsync();

        var transactionsViewModel = transactions
            .Select(TransactionViewModel.FromEntity).ToList();

        return ResultViewModel<List<TransactionViewModel>>.Success(transactionsViewModel);
    }
}
