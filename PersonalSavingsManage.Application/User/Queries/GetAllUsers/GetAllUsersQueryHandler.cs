using MediatR;
using PersonalSavingsManage.Application.User.ViewModels;
using PersonalSavingsManage.Core.Models;
using PersonalSavingsManage.Core.Repositories;

namespace PersonalSavingsManage.Application.User.Queries.GetAllUsers;

public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, ResultViewModel<List<UserViewModel>>>
{
    private readonly IUserRepository _userRepository;

    public GetAllUsersQueryHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<ResultViewModel<List<UserViewModel>>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
    {
        var users = await _userRepository.GetAllAsync();

        var usersViewModel = users
            .Select(UserViewModel.FromEntity)
            .ToList();

        return ResultViewModel<List<UserViewModel>>.Success(usersViewModel);
    }
}
