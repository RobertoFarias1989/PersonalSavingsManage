using MediatR;
using PersonalSavingsManage.Application.User.ViewModels;
using PersonalSavingsManage.Core.Models;
using PersonalSavingsManage.Core.Repositories;

namespace PersonalSavingsManage.Application.User.Queries.GetUserById;

public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, ResultViewModel<UserDetailsViewModel>>
{
    private readonly IUserRepository _repository;

    public GetUserByIdQueryHandler(IUserRepository repository)
    {
        _repository = repository;
    }

    public async Task<ResultViewModel<UserDetailsViewModel>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        var user = await _repository.GetByIdAsync(request.Id);

        //var financialGoals = user.Goals
        //    .Select(g => new FinancialGoalViewModel(
        //        g.Id,
        //        g.Title,
        //        g.TargetAmount,
        //        g.Deadline,
        //        g.IdealMonthlyContribution,
        //        g.Status.ToString())).ToList();

        //var financialGoals = user.Goals
        //        .Select(FinancialGoalViewModel.FromEntity).ToList();

        //var transactions = user.Transactions
        //    .Select(t => new TransactionViewModel(
        //        t.Id,
        //        t.Amount,
        //        t.Type.ToString(),
        //        t.TransactionDate)).ToList();

        //var transactions = user.Transactions
        //        .Select(TransactionViewModel.FromEntity).ToList();

        var userDetailsViewModel = UserDetailsViewModel.FromEntity(user);

        return ResultViewModel<UserDetailsViewModel>.Success(userDetailsViewModel);

    }
}
