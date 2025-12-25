using MediatR;
using PersonalSavingsManage.Application.User.ViewModels;
using PersonalSavingsManage.Core.Models;
using PersonalSavingsManage.Core.Repositories;

namespace PersonalSavingsManage.Application.User.Queries.GetUserById;

public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, ResultViewModel<UserDetailsViewModel>>
{
    private readonly IUserRepository _userRepository;

    public GetUserByIdQueryHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<ResultViewModel<UserDetailsViewModel>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(request.Id);

        var userDetailsViewModel = UserDetailsViewModel.FromEntity(user);

        return ResultViewModel<UserDetailsViewModel>.Success(userDetailsViewModel);

    }
}
