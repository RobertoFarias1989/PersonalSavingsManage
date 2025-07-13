using MediatR;
using PersonalSavingsManage.Application.Transaction.ViewModel;
using PersonalSavingsManage.Core.Models;
using PersonalSavingsManage.Core.Repositories;

namespace PersonalSavingsManage.Application.Transaction.Queries.GetAllTransactions;

public class GetAllTransactionsQueryHandler : IRequestHandler<GetAllTransactionsQuery, ResultViewModel<List<TransactionViewModel>>>
{
    private readonly ITransactionRepository _repository;

    public GetAllTransactionsQueryHandler(ITransactionRepository repository)
    {
        _repository = repository;
    }

    public async Task<ResultViewModel<List<TransactionViewModel>>> Handle(GetAllTransactionsQuery request, CancellationToken cancellationToken)
    {
        var transactions = await _repository.GetAllAsync();

        //var transactionsViewModel = transactions
        //    .Select(t => new TransactionViewModel(
        //        t.Id,
        //        t.Amount,
        //        t.Type.ToString(),
        //        t.TransactionDate)).ToList();

        var transactionsViewModel = transactions
           .Select(TransactionViewModel.FromEntity).ToList();

        return ResultViewModel<List<TransactionViewModel>>.Success(transactionsViewModel);
    }
}
