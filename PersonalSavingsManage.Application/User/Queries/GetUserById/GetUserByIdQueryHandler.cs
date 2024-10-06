using MediatR;
using PersonalSavingsManage.Application.FinancialGoal.ViewModels;
using PersonalSavingsManage.Application.Transaction.ViewModel;
using PersonalSavingsManage.Application.User.ViewModels;
using PersonalSavingsManage.Core.Repositories;

namespace PersonalSavingsManage.Application.User.Queries.GetUserById;

public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserDetailsViewModel>
{
    private readonly IUserRepository _repository;

    public GetUserByIdQueryHandler(IUserRepository repository)
    {
        _repository = repository;
    }

    public async Task<UserDetailsViewModel> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        var user = await _repository.GetByIdAsync(request.Id);

        var financialGoals = user.Goals
            .Select(g => new FinancialGoalViewModel(
                g.Id,
                g.Title,
                g.TargetAmount,
                g.Deadline,
                g.IdealMonthlyContribution,
                g.Status.ToString())).ToList();

        var transactions = user.Transactions
            .Select(t => new TransactionViewModel(
                t.Id,
                t.Amount,
                t.Type.ToString(),
                t.TransactionDate)).ToList();

        var userDetailsViewModel = new UserDetailsViewModel(
               user.Id,
               user.Address.Street,
               user.Address.City,
               user.Address.State,
               user.Address.PostalCode,
               user.Address.Country,           
               user.Email.EmailAddress,
               user.Name.FullName,
               user.Password.PasswordValue,
               user.Role,
               user.IsDeleted,
               user.CreatedAt,
               user.UpdatedAt,
               transactions,
               financialGoals);

        return userDetailsViewModel;

    }
}
