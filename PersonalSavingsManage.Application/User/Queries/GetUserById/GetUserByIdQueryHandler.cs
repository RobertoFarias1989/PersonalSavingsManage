using MediatR;
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

        var userDetailsViewModel = UserDetailsViewModel.FromEntity(user);

        return userDetailsViewModel;

    }
}
