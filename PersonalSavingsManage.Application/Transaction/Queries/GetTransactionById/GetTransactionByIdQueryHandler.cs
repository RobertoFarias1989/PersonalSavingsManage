using MediatR;
using PersonalSavingsManage.Application.Transaction.ViewModel;
using PersonalSavingsManage.Core.Repositories;

namespace PersonalSavingsManage.Application.Transaction.Queries.GetTransactionById;

public class GetTransactionByIdQueryHandler : IRequestHandler<GetTransactionByIdQuery, TransactionDetailsViewModel>
{
    private readonly ITransactionRepository _repository;

    public GetTransactionByIdQueryHandler(ITransactionRepository repository)
    {
        _repository = repository;
    }

    public async Task<TransactionDetailsViewModel> Handle(GetTransactionByIdQuery request, CancellationToken cancellationToken)
    {
        var transaction = await _repository.GetByIdAsync(request.Id);

        var transactionDetailsViewModel = TransactionDetailsViewModel.FromEntity(transaction);

        return transactionDetailsViewModel;
    }
}
