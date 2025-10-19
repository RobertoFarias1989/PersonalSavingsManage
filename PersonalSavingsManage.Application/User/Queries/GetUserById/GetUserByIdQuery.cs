using MediatR;
using PersonalSavingsManage.Application.User.ViewModels;
using PersonalSavingsManage.Core.Models;

namespace PersonalSavingsManage.Application.User.Queries.GetUserById;

public class GetUserByIdQuery : IRequest<ResultViewModel<UserDetailsViewModel>>
{
    public GetUserByIdQuery(Guid id)
    {
        Id = id;
    }

    public Guid Id { get; private set; }
}
