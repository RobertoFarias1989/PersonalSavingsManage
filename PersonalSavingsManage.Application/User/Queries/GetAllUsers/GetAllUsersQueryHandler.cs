using MediatR;
using PersonalSavingsManage.Application.User.ViewModels;
using PersonalSavingsManage.Core.Repositories;

namespace PersonalSavingsManage.Application.User.Queries.GetAllUsers;

public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, List<UserViewModel>>
{
    private readonly IUserRepository _repository;

    public GetAllUsersQueryHandler(IUserRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<UserViewModel>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
    {
        var users = await _repository.GetAllAsync();

        var usersViewModel = users
            .Select(u => new UserViewModel(
                u.Id,
                u.Address.Street,
                u.Address.City,
                u.Address.State,
                u.Address.PostalCode,
                u.Address.Country,       
                u.Email.EmailAddress,
                u.Name.FullName,
                u.Password.PasswordValue,
                u.Role))
            .ToList();

        return usersViewModel;
    }
}
