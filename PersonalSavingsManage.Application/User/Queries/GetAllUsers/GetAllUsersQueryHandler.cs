using MediatR;
using PersonalSavingsManage.Application.User.ViewModels;
using PersonalSavingsManage.Core.Models;
using PersonalSavingsManage.Core.Repositories;

namespace PersonalSavingsManage.Application.User.Queries.GetAllUsers;

public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, ResultViewModel<List<UserViewModel>>>
{
    private readonly IUserRepository _repository;

    public GetAllUsersQueryHandler(IUserRepository repository)
    {
        _repository = repository;
    }

    public async Task<ResultViewModel<List<UserViewModel>>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
    {
        var users = await _repository.GetAllAsync();

        //var usersViewModel = users
        //    .Select(u => new UserViewModel(
        //        u.Id,
        //        u.Address.Street,
        //        u.Address.City,
        //        u.Address.State,
        //        u.Address.PostalCode,
        //        u.Address.Country,       
        //        u.Email.EmailAddress,
        //        u.Name.FullName,
        //        u.Password.PasswordValue,
        //        u.Role))
        //    .ToList();

        var usersViewModel = users
            .Select(UserViewModel.FromEntity)
            .ToList();

        return ResultViewModel<List<UserViewModel>>.Success(usersViewModel);
    }
}
